using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TestAuthentification.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View(_roleManager.Roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IdentityRole model)
        {
            if(!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult()) {
                _roleManager.CreateAsync(model).GetAwaiter().GetResult();  
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
