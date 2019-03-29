using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Search_Work.Data;
using Search_Work.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        UserManager<ApplicationUser> _userManager;
        private readonly oxana1404 _context;
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, oxana1404 context)
        {
            _roleManager = roleManager;
            _userManager = userManager;

            _context = context;
        }
        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }


        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        public IActionResult UserList() => View(_userManager.Users.ToList());

	   //public async Task<IActionResult> UserList()
	   //{

	   //    var users = _userManager.Users;
	   //    var roles = new List<string>();
	   //    foreach (var user in users.ToList())
	   //    {
	   //        string str = "";
	   //        foreach (var role in _userManager.GetRolesAsync(user))
	   //        {
	   //            str = (str == "") ? role.ToString() : str + " - " + role.ToString();
	   //        }
	   //        roles.Add(str);
	   //    }
	   //    var model = new ListUserViewModel()
	   //    {
	   //        users = users.ToList(),
	   //        roles = roles.ToList()
    //       }
           //var users = _userManager.Users.ToList();
           //  var rolesForUser = await _userManager.GetRolesAsync(userId);

                //       var model = new UsersViewModel
                //{
                // Users = users.Select(u => new List<UserViewModel>()
                // {
                //              new UserViewModel()
                //              {
                //    //  Id = u.Id,
                //      UserName = u.Email,
                //      Roles = _userManager.GetRolesAsync(u.Id).ToString()
                //   }
                // }),
                //};
    //        return View(model);
	   //}

        public async Task<IActionResult> Edit(string userId)
        {
            // получаем пользователя
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            // получаем пользователя
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                // получаем все роли
                var allRoles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
               

                  var cand = _context.Candidates.FirstOrDefault(i => i.AccountUser == user);
                  var emp = _context.Employers.FirstOrDefault(i => i.AccountUser == user);

                  if (cand != null)
                    _context.Candidates.Remove(cand);    
                  else if (emp != null)
                    _context.Employers.Remove(emp);

                var result = await _userManager.DeleteAsync(user);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(UserList));
        }
    }
}
