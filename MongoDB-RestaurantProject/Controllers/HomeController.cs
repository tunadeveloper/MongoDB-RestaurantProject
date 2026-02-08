using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Models;

namespace MongoDB_RestaurantProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
