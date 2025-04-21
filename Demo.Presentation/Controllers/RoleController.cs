using Demo.BusinessLogic.DataTransferObjects.EmployeeDataTransferObject;
using Demo.BusinessLogic.Services.DepartmentServices;
using System;
using Demo.DataAccess.Models.IdentityModel;
using Demo.Presentation.ViewModels.EmployeeViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Demo.Presentation.Controllers
{
    public class RoleController(RoleManager<IdentityRole> _roleManager ,UserManager<ApplicationUser> _userManager) : Controller
    {
        #region Index With Search
        [HttpGet]
        public IActionResult Index(string? RoleSearchName)
        {
            var Roles = _roleManager.Roles.AsEnumerable();

            if (!string.IsNullOrEmpty(RoleSearchName))
            {
                Roles = Roles.Where(r => r.Name.Contains(RoleSearchName, StringComparison.OrdinalIgnoreCase));
            }

            var role = Roles.ToList();
            return View(role);
        }
        #endregion

        #region Create Roles
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IdentityRole identityRole)
        {
            if (ModelState.IsValid)
            {
                
                    var newRole = new IdentityRole()
                    {
                        Name = identityRole.Name
                    };

                    var result = _roleManager.CreateAsync(newRole).Result;

                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }                                                                 
            }

            return View(identityRole);
        }
        #endregion

        #region Details
        public IActionResult Details(string Id)
        {
            var Roles_Details = _roleManager.FindByIdAsync(Id).Result;
            return View(Roles_Details);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(string Id)
        {
            var Roles_Edit = _roleManager.FindByIdAsync(Id).Result;
            if (Roles_Edit is not null)
            {
                return View(Roles_Edit);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost]
        public IActionResult Edit(string Id, IdentityRole _identityRole)
        {
            if (!ModelState.IsValid) return View(_identityRole);
            var Role = _roleManager.FindByIdAsync(Id).Result;
            if (Role == null)
                return NotFound();

            
            Role.Name = _identityRole.Name;
          

            var Result = _roleManager.UpdateAsync(Role).Result;
            if (Result.Succeeded)
                return RedirectToAction("Index");
            foreach (var error in Result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(_identityRole);


        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(string Id)
        {
            var Role_Delete = _roleManager.FindByIdAsync(Id).Result;
            return View(Role_Delete);
        }

        [HttpPost]
        public IActionResult Delete(string Id, IdentityRole  _identityRole)
        {
            if (!ModelState.IsValid) return View(_identityRole);
            var Role = _roleManager.FindByIdAsync(Id).Result;
            if (Role == null)
                return NotFound();

            var Result = _roleManager.DeleteAsync(Role).Result;
            if (Result.Succeeded)
                return RedirectToAction("Index");
            foreach (var error in Result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(_identityRole);
        }
        #endregion
    }
}
