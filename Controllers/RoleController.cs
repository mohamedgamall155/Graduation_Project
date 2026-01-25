using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projectweb.ViewModel;
using System.Threading.Tasks;

namespace projectweb.Controllers
{
    [Authorize( Roles="Admin")]
    public class RoleController : Controller
    {
        public RoleManager<IdentityRole> _Role { get; }

        public RoleController( RoleManager<IdentityRole> Role)
        {
            _Role = Role;
        }


        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel Role)
        {
            if (ModelState.IsValid == true) 
            {
                IdentityRole role = new IdentityRole() {Name=Role.RoleType};
               var result= await _Role.CreateAsync(role);
                if (result.Succeeded)
                {
                    return View();
                }
                else 
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                        
                    }
                }
            }
            return View(Role);
        }
    }
}
