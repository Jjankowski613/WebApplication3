using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication3.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class RatingsController : Controller
{
    private readonly MovieService _movieService;
    private static List<UserRating> userRatings = new List<UserRating>();

    public RatingsController(MovieService movieService)
    {
        _movieService = movieService;
    }

    public IActionResult Index()
    {
        var movies = _movieService.GetAllMovies().Select(m => new MovieRating
        {
            Id = m.Id,
            Title = m.Title,
            AverageRating = userRatings.Where(r => r.Id == m.Id).Average(r => (double?)r.Rating) ?? 0,
            NumberOfRatings = userRatings.Count(r => r.Id == m.Id),
            ImageUrl = m.ImageUrl,

        }).ToList();

        return View(movies);
    }

    [HttpPost]
    public IActionResult RateMovie(int MovieId, int rating)
    {
        if (rating < 1 || rating > 5)
        {
            return BadRequest("Rating must be between 1 and 5.");
        }

        var movie = _movieService.GetMovieById(MovieId);
        if (movie == null)
        {
            return NotFound("Movie not found.");
        }

        userRatings.Add(new UserRating { Id = MovieId, UserId = 1, Rating = rating });

        TempData["SuccessMessage"] = "Dziękujemy za ocenę filmu!";
        return RedirectToAction(actionName: "MovieDetails", controllerName: "Repertuar", new { id = MovieId });
    }
}
    