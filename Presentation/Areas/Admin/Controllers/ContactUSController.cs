using DataAccess.Design_Pattern.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entities.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ContactUSController : Controller
    {
        private readonly IUnitOfWork _context;
        public ContactUSController(IUnitOfWork context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<ContactUs> conatct = _context.contactUsRepository.GetAllMessages();

            return View(conatct);
        }

        public IActionResult MessageDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContactUs contact = _context.contactUsRepository.GetContactUsById((int)id);

            return View(contact);
        }
    }
}
