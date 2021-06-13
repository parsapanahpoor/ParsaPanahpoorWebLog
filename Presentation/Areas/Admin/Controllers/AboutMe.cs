using DataAccess.Design_Pattern.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Areas.Admin.Controllers
{
    public class AboutMe : Controller
    {
        private readonly IUnitOfWork _context;
        public AboutMe(IUnitOfWork context)
        {
            _context = context;
        }

        public IActionResult Resume()
        {
            return View();
        }
    }
}
