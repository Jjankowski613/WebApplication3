using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

[Authorize]
public class ReservationController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;

    public ReservationController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
       
        var userId = _userManager.GetUserId(User);

       
        var reservations = _dbContext.Reservations
            .Where(r => r.UserId == userId)
            .OrderByDescending(r => r.ReservationDate)
            .ToList();

        return View(reservations);
    }

    public async Task<IActionResult> UserRatings()
    {
        var userId = _userManager.GetUserId(User);

        // Pobierz oceny użytkownika razem z tytułami filmów
        var userRatings = (from rating in _dbContext.UserRatings
                           join movie in _dbContext.Movies on rating.MovieId equals movie.Id
                           where rating.UserId == userId
                           orderby rating.Id descending
                           select new UserRatingViewModel
                           {
                               Rating = rating.Rating,
                               MovieTitle = movie.Title
                           }).ToList();

        return View(userRatings);
    }



    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = _userManager.GetUserId(User);
        var reservation = _dbContext.Reservations.FirstOrDefault(r => r.Id == id && r.UserId == userId);

        if (reservation == null)
        {
            return NotFound("Nie znaleziono rezerwacji.");
        }

        _dbContext.Reservations.Remove(reservation);
        await _dbContext.SaveChangesAsync();

        TempData["DeleteMessage"] = "Rezerwacja została usunięta.";
        return RedirectToAction("Index");
    }
}
