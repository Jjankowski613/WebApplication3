using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class Privacy : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
