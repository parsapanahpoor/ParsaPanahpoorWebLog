using DataAccess.Design_Pattern.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Entities.Projects;
using ParsaPanahpoor.WebSite.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class PrjectsController : Controller
    {
        #region Constructo
        private readonly IUnitOfWork _context;
        public PrjectsController(IUnitOfWork context)
        {
            _context = context;
        }

        #endregion

        public IActionResult ProductsDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Project project = _context.ProjectRepository.GetPRojectById((int)id);

            return View(project);
        }
    }
}
