using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // Pobierz dane użytkownika wraz z powiązanymi filmami
        var userRatings = await _dbContext.UserRatings
            .Where(r => r.UserId == userId)
            .Include(r => r.Movie) // Ładujemy powiązane dane o filmach
            .OrderByDescending(r => r.Id)
            .Select(r => new UserRatingViewModel
            {
                Rating = r.Rating,
                MovieTitle = r.Movie != null ? r.Movie.Title : "Brak tytułu"
            })
            .ToListAsync();

        // Zwrócenie listy ocen do widoku
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
