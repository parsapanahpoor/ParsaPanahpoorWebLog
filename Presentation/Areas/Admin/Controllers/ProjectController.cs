using DataAccess.Design_Pattern.UnitOfWork;
using DataAccess.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Models.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project = Models.Entities.Projects.Project;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProjectController : Controller
    {
        #region Constructor
        private readonly IUnitOfWork _context;
        public ProjectController(IUnitOfWork context)
        {
            _context = context;
        }
        #endregion

        public IActionResult Index()
        {
            return View(_context.ProjectRepository.GetAllProjects());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProjectsViewModls project, IFormFile imgBlogUp)
        {
            if (ModelState.IsValid)
            {
                _context.ProjectRepository.AddProject(project, imgBlogUp);
                _context.SaveChangesDB();

                return Redirect("/Admin/Project/Index?Create=true");
            }
            return View(project);
        }

        public IActionResult Edit(int? id, bool Delete = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = _context.ProjectRepository.GetPRojectById((int)id);
            if (slider == null)
            {
                return NotFound();
            }
            if (Delete == true)
            {
                ViewData["Delete"] = true;
            }
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Project project, IFormFile imgBlogUp)
        {
            if (ModelState.IsValid)
            {
                _context.ProjectRepository.UpdateProject(project, imgBlogUp);
                _context.SaveChangesDB();

                return Redirect("/Admin/Project/Index?Edit=true");
            }
            return View(project);
        }

        public IActionResult Delete(int id)
        {
            var projects = _context.ProjectRepository.GetPRojectById(id);
            _context.ProjectRepository.DeleteProject(projects);
            _context.SaveChangesDB();

            return RedirectToAction(nameof(Index));
        }
    }
}
