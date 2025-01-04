using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication3.Data;
using WebApplication3.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

[Authorize]
public class RepertuarController : Controller
{
    private readonly MovieService _movieService;
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;
    private static List<UserRating> userRatings = new List<UserRating>();
    private static List<Reservation> reservations = new List<Reservation>();

    public RepertuarController(MovieService movieService, UserManager<IdentityUser> userManager, ApplicationDbContext dbContext)
    {
        _movieService = movieService;
        _userManager = userManager;
        _dbContext = dbContext;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var movies = await _dbContext.Movies
            .Select(movie => new MovieRating
            {
                Id = movie.Id,
                Title = movie.Title,
                ImageUrl = movie.ImageUrl,
                AverageRating = _dbContext.UserRatings
                    .Where(r => r.MovieId == movie.Id)
                    .Average(r => (double?)r.Rating) ?? 0, // Oblicz średnią ocen
                NumberOfRatings = _dbContext.UserRatings
                    .Count(r => r.MovieId == movie.Id) // Liczba ocen
            })
            .ToListAsync();

        return View(movies);
    }


    [AllowAnonymous]
    public async Task<IActionResult> MovieDetails(int id)
    {
        var movie = await _dbContext.Movies
        .FirstOrDefaultAsync(m => m.Id == id);

        if (movie == null)
        {
            return NotFound("Nie znaleziono filmu.");
        }

        // Pobierz dane ocen z bazy danych
        var ratings = _dbContext.UserRatings
            .Where(r => r.MovieId == id)
            .ToList();

        var averageRating = ratings.Any() ? ratings.Average(r => r.Rating) : 0;
        var numberOfRatings = ratings.Count;

        var userId = _userManager.GetUserId(User);
        var hasRated = ratings.Any(r => r.UserId == userId);

        // Przekaż dane do widoku
        ViewData["AverageRating"] = averageRating;
        ViewData["NumberOfRatings"] = numberOfRatings;
        ViewData["HasRated"] = hasRated;

        return View(movie);
    }

    [HttpPost]
    public async Task<IActionResult> RateMovie(int MovieId, int rating)
    {
        if (rating < 1 || rating > 5)
        {
            return BadRequest("Musisz wybrać ocenę");
        }

        var userId = _userManager.GetUserId(User);

        if (_dbContext.UserRatings.Any(r => r.MovieId == MovieId && r.UserId == userId))
        {
            return BadRequest("Już oceniłeś/aś ten film.");
        }

        var userRating = new UserRating
        {
            UserId = userId,
            Rating = rating,
            MovieId = MovieId
        };

        _dbContext.UserRatings.Add(userRating);
        await _dbContext.SaveChangesAsync();

        TempData["ReservationSuccessMessage"] = $"Pomyślnie dodano ocenę";

        return RedirectToAction("MovieDetails", "Repertuar", new { id = MovieId });
    }



    [HttpPost]
    public async Task<IActionResult> Rezerwacja(int MovieID, DateOnly data, TimeOnly time)
    {
        var movie = _movieService.GetMovieById(MovieID);
        if (movie == null)
        {
            return NotFound("Nie znaleziono filmu.");
        }

        var userId = _userManager.GetUserId(User);

        var reservation = new Reservation
        {
            MovieId = MovieID,
            UserId = userId,
            ReservationDate = data,
            ReservationTime = time,
            MovieTitle = movie.Title
        };

        _dbContext.Reservations.Add(reservation);
        await _dbContext.SaveChangesAsync();

        TempData["ReservationSuccessMessage"] = $"Pomyślnie zarezerwowano seans na film '{movie.Title}' na {data:dd-MM-yyyy} {time:HH:mm}";

        return RedirectToAction("MovieDetails", "Repertuar", new { id = MovieID });
    }
    

}
