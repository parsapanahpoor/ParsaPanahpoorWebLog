using DataAccess.Design_Pattern.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Areas.Admin.Controllers
{
    public class SlidersController : Controller
    {
        private readonly IUnitOfWork _context;

        public SlidersController(IUnitOfWork context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
