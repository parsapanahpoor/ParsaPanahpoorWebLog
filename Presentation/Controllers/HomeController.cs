using DataAccess.Design_Pattern.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ParsaPanahpoor.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _context;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork context)
        {
            _logger = logger;
            _context = context;
        }

        //Welcome Page
        public IActionResult Index()
        {
            var sliders = _context.sliderRepository.GetSldierForShow();
            return View(sliders);
        }


        [Route("/Home")]
        public IActionResult Home()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
