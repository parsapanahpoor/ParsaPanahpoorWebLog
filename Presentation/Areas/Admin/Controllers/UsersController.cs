using DataAccess.Design_Pattern.UnitOfWork;
using DataAccess.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Entities.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Genarator;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _context;


        public UsersController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IUnitOfWork context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        #region UsersManager

        public ActionResult Index(int? id, bool Create = false, bool Edit = false, bool Delete = false)
        {
            ViewBag.Create = Create;
            ViewBag.Edit = Edit;
            ViewBag.Delete = Delete;


            var model = _userManager.Users
                        .Select(u => new IndexViewModel()
                        {
                            Id = u.Id,
                            UserName = u.UserName,
                            Email = u.Email,
                            UserAvatar = u.UserAvatar
                            ,
                            PhoneNumber = u.PhoneNumber,
                            IsActive = u.IsActive
                        }).ToList();
            return View(model);
        }




        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUserFromAdminPanel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Redirect("/Admin/Users/Index?Create=true");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }

        public async Task<ActionResult> Edit(string id, bool Detail = false, bool Delete = false)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var user = await _userManager.FindByIdAsync(id);
            EditUserInAdminPanel editUser = new EditUserInAdminPanel()
            {

                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                UserName = user.UserName,
                Id = user.Id,
                AvatarName = user.UserAvatar



            };
            if (user == null) return NotFound();


            if (Detail == true)
            {

                ViewData["Detail"] = true;

            }
            if (Delete == true)
            {

                ViewData["Delete"] = true;

            }
            return View(editUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditUserInAdminPanel userEdited)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(userEdited.UserName)) return NotFound();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            user.UserName = userEdited.UserName;
            user.PhoneNumber = userEdited.PhoneNumber;
            user.Email = userEdited.Email;

            if (userEdited.UserAvatar != null)
            {


                user.UserAvatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(userEdited.UserAvatar.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/UserAvatar", user.UserAvatar);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    userEdited.UserAvatar.CopyTo(stream);
                }
            }


            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded) return Redirect("/Admin/Users/Index?Edit=true");


            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(user);
        }




        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            user.IsDelete = true;

            var result = await _userManager.UpdateAsync(user);

            return Redirect("/Admin/Users/Index?Delete=true");
        }

        public async Task<IActionResult> LockUser(string Userid, int id)
        {
            var user = await _userManager.FindByIdAsync(Userid);

            if (id == 1)
            {
                user.IsActive = false;

            }
            if (id == 2)
            {
                user.IsActive = true;

            }
            var result = await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }


        #endregion

        #region RolesManager
        [Area("Admin")]

        [HttpGet]
        public async Task<IActionResult> AddUserToRole(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var roles = _roleManager.Roles.ToList();
            var model = new AddUserToRoleViewModel() { UserId = id };

            foreach (var role in roles)
            {
                if (!await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.UserRoles.Add(new UserRolesViewModel()
                    {
                        RoleName = role.Name
                    });
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserToRole(AddUserToRoleViewModel model)
        {
            if (model == null) return NotFound();
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) return NotFound();
            var requestRoles = model.UserRoles.Where(r => r.IsSelected)
                .Select(u => u.RoleName)
                .ToList();
            var result = await _userManager.AddToRolesAsync(user, requestRoles);

            if (result.Succeeded) return RedirectToAction("index");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveUserFromRole(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var roles = _roleManager.Roles.ToList();
            var model = new AddUserToRoleViewModel() { UserId = id };

            foreach (var role in roles)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.UserRoles.Add(new UserRolesViewModel()
                    {
                        RoleName = role.Name
                    });
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUserFromRole(AddUserToRoleViewModel model)
        {
            if (model == null) return NotFound();
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) return NotFound();
            var requestRoles = model.UserRoles.Where(r => r.IsSelected)
                .Select(u => u.RoleName)
                .ToList();
            var result = await _userManager.RemoveFromRolesAsync(user, requestRoles);

            if (result.Succeeded) return RedirectToAction("index");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        #endregion
    }
}
