using KadariTicketSales.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KadariTicketSales.Controllers
{
    public class HomeController : Controller
    {
        //created by Kadari

        public IActionResult Index()
        {
            return View(); //returns index view
        }
        public IActionResult About()
        {
            return View(); // returns about view
        }

        
    }
}
