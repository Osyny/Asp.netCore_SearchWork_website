using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Controllers
{
    public class AdminController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        public AdminController(RoleManager<IdentityRole> manager)
        {
            _roleManager = manager;
        }

        public IActionResult Roles()
        {
            // var r = _roleManager.
            return View(_roleManager.Roles.ToList());
        }
    }
}
