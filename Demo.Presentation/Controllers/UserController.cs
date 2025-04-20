using Demo.DataAccess.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Demo.Presentation.Controllers
{
    public class UserController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManger) : Controller
    {
        #region Index
        public IActionResult Index()
        {
            var Users = _userManager.Users.ToList();
            return View(Users);
        }
        #endregion


        #region Details Of Users
        [HttpGet]
        public IActionResult Details(string Id)
        {
            var Users_Details = _userManager.FindByIdAsync(Id).Result;
            return View(Users_Details);
        }
        #endregion

        #region Edit Of Users

        [HttpGet]
        public IActionResult Edit(string Id)
        {
            var Users_Edit = _userManager.FindByIdAsync(Id).Result;
            if (Users_Edit is not null)
            {
                return View(Users_Edit);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost]
        public IActionResult Edit(string Id, ApplicationUser applicationUser)
        {
            if (!ModelState.IsValid) return View(applicationUser);
            var User = _userManager.FindByIdAsync(Id).Result;
            if (User == null)
                return NotFound();

            User.FirstName = applicationUser.FirstName;
            User.LastName = applicationUser.LastName;
            User.PhoneNumber = applicationUser.PhoneNumber;

            var Result = _userManager.UpdateAsync(User).Result;
            if (Result.Succeeded)
                return RedirectToAction("Index");
            foreach (var error in Result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(applicationUser);


        }
        #endregion

        #region Delete Of Users
        [HttpGet]
         public IActionResult Delete(string Id)
        {
            var User_Delete = _userManager.FindByIdAsync(Id).Result;
            return View(User_Delete);
        }  
        
        
        [HttpPost]
         public IActionResult Delete(string Id , ApplicationUser applicationUser)
        {
            if (!ModelState.IsValid) return View(applicationUser);
            var User = _userManager.FindByIdAsync(Id).Result;
            if (User == null)
                return NotFound();

            var Result = _userManager.DeleteAsync(User).Result;
            if (Result.Succeeded)
                return RedirectToAction("Index");
            foreach (var error in Result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(applicationUser);
        }
        #endregion


    }
}
