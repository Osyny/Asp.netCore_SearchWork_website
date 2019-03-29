
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Search_Work.Data;
using Search_Work.Models;
using Search_Work.Models.ViewModel.Employer;

namespace Search_Work.Arrea.Employer
    {
        public class EmployersController : Controller
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly oxana1404 db;

            public EmployersController(
                UserManager<ApplicationUser> userManager,
                RoleManager<IdentityRole> roleManager, oxana1404 db)
            {
                _userManager = userManager;
                this.db = db;
            }

            public IActionResult Index()
            {

                return View();
            }
            public IActionResult Create()
            {
                var model = new CreateEmployerViewModel();
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> Create(CreateEmployerViewModel model)
            {
                var user1 = _userManager.GetUserName(User);

                var user = new ApplicationUser() { Email = HttpContext.User.Identity.Name };
                var user2 = new ApplicationUser() { UserName = user1, Email = user1 };

                var u = user;
                var u2 = user2;

                var newEmployer = new Search_Work.Models.ArreaDatabase.Employer();
                newEmployer.Id = Guid.NewGuid();
                newEmployer.AccountUser = user;

                //Create Role
                // await _userManager.AddToRoleAsync(u, "Employer");
                await _userManager.AddToRoleAsync(u2, "Employer");
                //  await _userManager.AddToRoleAsync(user, "Employer");

                db.Employers.Add(newEmployer);
                await db.SaveChangesAsync();

                return RedirectToAction(nameof(PageIsExistCompany), new { empId = newEmployer.Id });
            }

            public IActionResult PageIsExistCompany(Guid? Id)
            {
                var emp = db.Employers.Include(e => e.Company).Include(e => e.AccountUser)
                .FirstOrDefault(e => e.Id == Id);

                var model = new PageIsExistCompanyViewModel()
                {
                    Employer = emp,
                };
                return View(model);
            }

            public IActionResult SearchCompanyName(Guid? Id)
            {
                var emp = db.Employers.Include(e => e.Company)
                    .Include(e => e.AccountUser).FirstOrDefault(e => e.Id == Id);

                // var company = db.Companies.FirstOrDefault(t => t.Employers.Select(e => e.Id == empId).FirstOrDefault());


                var model = new SearchCompanyNameViewModel()
                {
                    NameEmp = emp.AccountUser.Email,
                    EmpId= emp.Id,
                    Companies = db.Companies.Select(e => new SelectListItem
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name

                    }).ToList(),
                };
                return View(model);
            }

              [HttpPost]
              public async Task<IActionResult> SearchCompanyName(SearchCompanyNameViewModel model)
              {
                  var emp = db.Employers.Include(i => i.Company)
                      .Include(i => i.AccountUser).FirstOrDefault(e => e.Id == model.EmpId);

                  var company = await db.Companies
                    .Include(c => c.City)
                    .FirstOrDefaultAsync(m => m.Id == model.CompanyId);

                    if(emp.Company == null)
                    {
                          emp.Company = company;

                          db.Employers.Update(emp);
                          await db.SaveChangesAsync();
                    }


            //return RedirectToAction("EditEmployee", "Search_Work.Arrea.Employer.Controllers.Employee", new { employerId = emp.Id }); 
            return RedirectToAction("Edit", "Companies", new { id = company.Id, empId = emp.Id} );


        }

        // GET: Emploees/Details/5
        public async Task<IActionResult> Details(Guid? id)
              {
                  if (id == null)
                  {
                      return NotFound();
                  }

                  var emp = await db.Employers
                      .SingleOrDefaultAsync(e => e.Id == id);
                  if (emp == null)
                  {
                      return NotFound();
                  }

                  return View(emp);
              }
        }
    }



