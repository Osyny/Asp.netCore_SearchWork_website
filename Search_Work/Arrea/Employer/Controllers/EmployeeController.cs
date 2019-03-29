using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Search_Work.Arrea.Employer.Models;
using Search_Work.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Employer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly oxana1404 dbContext;
        private readonly IHostingEnvironment _environment;

        public EmployeeController(oxana1404 dbContext, IHostingEnvironment environment)
        {
            this.dbContext = dbContext;
            _environment = environment;
        }

        public ActionResult EmployeeCompany(Guid companyId, /*Guid employeeId*/string nameEmp = null)
        {
            // var companyRepo = new CompanyRepository(this.dbContext);
            var company = dbContext.Companies.FirstOrDefault(c => c.Id == companyId);

            var employeers = dbContext.Employers.Include(e => e.Contact)
              .Include(e => e.Company).ThenInclude(e => e.Employers)
              .Include(c => c.Company).Include(i => i.AccountUser)
                                   .Include(e => e.Company).ThenInclude(c => c.City)
                                   .Where(emp => emp.Company.Id == companyId);

            // var emp = empRepo.GetByCompanyId(companyId).Include(e => e.AccountUser).Include(e => e.Company);

            List<Search_Work.Models.ArreaDatabase.Employer> allEmployersByCompany = null;

            if (nameEmp != null)
            {
                // ToDo нахождение сотрудника по имени или фамилии (|| e.AccountUser.FirstName || e.AccountUser.LastName)
                allEmployersByCompany = employeers.Where(e => e.Contact.Name + e.Contact.Surname == nameEmp
                || e.Contact.Name == nameEmp
                || e.Contact.Surname == nameEmp || e.Contact.Email == nameEmp).ToList();
            }
            else
            {
                allEmployersByCompany = employeers.ToList();
            }

            var countEmployersByCompany = allEmployersByCompany.Count();

            //    var emploersCompany = new List<EmployeeCompanyViewModel>();

            //try
            //{
            //    //foreach(var e in allEmployersByCompany)
            //    //{
            //    //  var emp = new PageEmployerCompanyViewModel()
            //    //  {
            //    //    NameEmployer = e.Contact == null ? " " : e.Contact?.Surname + " " + e.Contact?.Name,
            //    //    EmpId = e.Id,
            //    //    //toDo Comment
            //    //    // Comment = "new comment",
            //    //    //toDo Role
            //    //    //Role = employee
            //    //    //toDo Editor
            //    //    //Editor = 

            //    //    Link = Url.Action("EditEmployee", "Employee",
            //    //            new { employerId = e.Id }),
            //    //    Status = e.Contact.Status
            //    //  };
            //    //  emploersCompany.Add(emp);

            //    emploersCompany.AddRange(allEmployersByCompany.ToList().Select(employee =>
            //        new EmployeeCompanyViewModel()
            //        {

            //            NameEmployer = employee.Contact == null ? " " : employee.Contact?.Surname + " " + employee.Contact?.Name,
            //            EmpId = employee.Id,
            //    //toDo Comment
            //    // Comment = "new comment",
            //    //toDo Role
            //    //Role = employee
            //    //toDo Editor
            //    //Editor = 

            //    Link = Url.Action("EditEmployee", "Employee",
            //                new { employerId = employee.Id }),
            //            Status = employee.Contact.Status
            //    // Status = employee.Contact.Status == false ? "Відключений" : "Активний"
            //}));
            //}
            //catch (Exception e)
            //{
            //    var t = e;
            //}

            //var model = new PageEmployeesCompanyViewModel()
            //{
            //    EmployersCompany = emploersCompany,
            //    CompanyId = companyId,

            //    //EmployeeId = emp.Id
            //};

           // var emploersCompany = new List<EmployeeCompanyViewModel>();
            var employeeCompanyList = new List<EmployeViewModel>();



            employeeCompanyList.AddRange(allEmployersByCompany.Select(e => new EmployeViewModel()
            {
                NameEmployer = e.Contact == null ? "" : e.Contact?.Surname + " " + e.Contact?.Name,
                EmpId = e.Id,
               
                Link = Url.Action("EditEmployee", "Employee",
                            new { employerId = e.Id }),
                Status = e.Contact == null ? false : e.Contact.Status

            }).ToList());


            //
            var model = new PageEmployeesCompanyViewModel()
            {
                EmployeesCompany = employeeCompanyList,
                CompanyId =company.Id,

               
            };
            return View("/Arrea/Employer/Views/Employee/EmployersCompany.cshtml", model);
        }


        public ActionResult EditEmployee(Guid employerId)
        {

            var employer = dbContext.Employers
              .Include(e => e.Contact)
              .Include(e => e.AccountUser).FirstOrDefault(e => e.Id == employerId);

            var model = new PageEditEmployerViewModel()
            {
                Id = employer.Id,
                Name = employer.Contact?.Name,
                LastName = employer.Contact?.Surname,
                Photo = employer.Contact?.Avatar,
                PhoneNumber = employer.Contact?.Phone,
                Status = employer.Contact == null ? false : employer.Contact.Status,
                CompanyId = employer.CompanyId.Value
            };
            return View("/Arrea/Employer/Views/Employee/EditEmployee.cshtml", model);
        }

        [HttpPost]
        public async Task<ActionResult> EditEmployee(PageEditEmployerViewModel model, IFormFile Image)
        {
            // var repo = new EmployerRepository(this.dbContext);
            Search_Work.Models.ArreaDatabase.Employer updatEmployer = dbContext.Employers.Include(x => x.AccountUser)
                .FirstOrDefault(e => e.Id == model.Id);

            if (updatEmployer.Contact == null)
            {
                updatEmployer.Contact = new Search_Work.Models.ArreaDatabase.Contact()
                {
                    Id = Guid.NewGuid(),
                };
            }

            try
            {
                if (Image != null)
                {
                    string name = Image.FileName;
                    string path = $"/files/{name}";
                    string serverPath = $"{_environment.WebRootPath}{path}";
                    FileStream fs = new FileStream(serverPath, FileMode.Create,
                        FileAccess.Write);
                    await Image.CopyToAsync(fs);
                    fs.Close();
                    
                    updatEmployer.Contact.Avatar = path;
                }

                updatEmployer.Contact.Surname = model.LastName;
                updatEmployer.Contact.Name = model.Name;
                updatEmployer.Contact.Phone = model.PhoneNumber;
                updatEmployer.Contact.Email = model.Email;
                updatEmployer.Contact.Status = model.Status;

                //toDo model.Доступ
                //toDo model.Назначити редактора
                // toDo model.Публікація вакансій
                // toDo model.Доступ до билинга

                dbContext.Employers.Update(updatEmployer);
                dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(updatEmployer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(EmployeeCompany), new { companyId = model.CompanyId });

        }
        private bool EmployeeExists(Guid id)
        {
            return dbContext.Employers.Any(e => e.Id == id);
        }


    }
}

