using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Peak.Discoun.ViewModels;

namespace Peak.Discoun.Controllers.Account
{
   [Authorize(Roles = "admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> _userManager;
 

        public AdministrationController(RoleManager<IdentityRole> roleManager , UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this._userManager = userManager;
        }
    

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                // We just need to specify a unique role name to create a new role
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                // Saves the role in the underlying AspNetRoles table
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "product");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> CreateUserRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                // We just need to specify a unique role name to create a new role
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                // Saves the role in the underlying AspNetRoles table
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "product");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }


      /*  [HttpGet]
        [AllowAnonymous]
       
        public async Task<ActionResult> addAdmin()
        {
          

            var user = await _userManager.FindByNameAsync("karimfarjallah1234@gmail.com");
     
       
            await _userManager.AddToRoleAsync(user, "admin");
                return Ok();

        }*/
    }
}
