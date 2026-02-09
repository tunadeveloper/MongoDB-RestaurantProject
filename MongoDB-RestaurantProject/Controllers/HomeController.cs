using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Models;
using System.Diagnostics;

namespace MongoDB_RestaurantProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
