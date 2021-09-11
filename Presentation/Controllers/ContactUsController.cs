using DataAccess.Design_Pattern.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Entities.ContactUs;
using Models.Entities.User;
using ParsaPanahpoor.WebSite.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class ContactUsController : Controller
    {
        #region Constructor
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _context;

        public ContactUsController(ILogger<HomeController> logger, IUnitOfWork context)
        {
            _logger = logger;
            _context = context;
        }
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContactUs(ContactUs contact)
        {
            if (ModelState.IsValid)
            {
                _context.contactUsRepository.AddContactUsMessage(contact);
                _context.SaveChangesDB();

                return RedirectToAction("/Home");
            }

            return View(contact);
        }
    }
}
