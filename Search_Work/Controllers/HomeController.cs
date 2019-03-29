using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Search_Work.Data;
using Search_Work.Models;
using Search_Work.Models.ViewModel.Home;

namespace Search_Work.Controllers
{
  public class HomeController : Controller
  {
    private UserManager<ApplicationUser> userManager;
    oxana1404 db;
    RoleManager<IdentityRole> _roleManager;

    public HomeController(oxana1404 db, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
    {
      this.userManager = userManager;
      this.db = db;
      _roleManager = roleManager;
    }
    //public IActionResult Index()
    //{
    //  var users = userManager.Users.ToList();
    //  ViewBag.UsersCount = users.Count;

    //  return View();
    //}

    public IActionResult About()
    {
      var roles = _roleManager.Roles.ToList();
      var user = new ApplicationUser { UserName = HttpContext.User.Identity.Name };


      var emp = db.Employers.Include(e => e.Company)
  .Include(e => e.AccountUser)
  .FirstOrDefault(e => e.AccountUser.UserName == HttpContext.User.Identity.Name);

      var candidate = db.Candidates.Include(c => c.AccountUser).FirstOrDefault(c => c.Email == HttpContext.User.Identity.Name
      || c.AccountUser.UserName == user.UserName);



      var model = new ProfileViewModel();

      if (emp != null)
      {
        ViewBag.Employee = emp;
        model.Employer = emp == null ? null : emp;
        model.Company = emp.Company == null ? null : emp.Company;
        //model.Employers = emp.Company.Employers == null ? null : emp.Company.Employers;
      }
      else if (candidate != null)
      {
        ViewBag.Candidate = candidate;
        model.Candidate = candidate == null ? null : candidate;
      }


      return View(model);
    }


    public IActionResult Contact()
    {
      ViewData["Message"] = "Your contact page.";

      return View();
    }

    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> Index()
    {
      var users = userManager.Users.ToList();
      ViewBag.UsersCount = users.Count;

      var day = DateTime.Now.AddMonths(-3);

      // Vacancies
      var allVacancy = db.Vacancies.Include(v => v.City)
        .Include(v => v.Employer).ThenInclude(e => e.Company)
        .OrderByDescending(v => v.DatePublication).ToList();

      var newVacancies = new List<NewVacancyViewModel>();

      try
      {
        newVacancies.AddRange(allVacancy.Select(vacncy => new NewVacancyViewModel()
        {
          VacancyId = vacncy.Id,
          VacancyName = vacncy.Name,
          CityName = vacncy.City?.Name,
          Salary = vacncy.Wage,
          CompanyName = vacncy.Employer?.Company?.Name,
          Post = vacncy.Name

        }));
      }
      catch (Exception e)
      {
        var t = e;
      }



      var cities = db.Cities.Include(v => v.Vacancies).ToList();

      var vacanciesBYCityName = new List<VacancyByCityViewModel>();

      vacanciesBYCityName.AddRange(cities.Take(24).Select(city => new VacancyByCityViewModel()
      {
        CityId = city.Id,
        CityName = city.Name
      }));

      var vacanciesFromTopCompany = new List<VacancyFromTopCompanyViewModel>();



      vacanciesFromTopCompany.AddRange(allVacancy.Where(vac => vac.Employer.Company != null).Select(vacancy => new VacancyFromTopCompanyViewModel()
      {
        CompanyName = vacancy.Employer?.Company?.Name,
        CompanyId = vacancy.Employer?.Company == null ? Guid.Empty : vacancy.Employer.CompanyId.Value,
        CompanyLogoUrl = vacancy.Employer?.Company.CompanyLogoUrl

      }));

      var compList = db.Companies.Include(c => c.Employers).ThenInclude(e => e.Vacancies)
     /*   .Where(c => c.Employers.Any(e => e.Vacancies.Count > 0) != null)*/.ToList();

      List<Models.ArreaDatabase.Company> compVacancies = new List<Models.ArreaDatabase.Company>();
      foreach (var com in compList)
      {
        foreach (var e in com.Employers)
        {
          if (e != null)
          {

            if (e.Vacancies.Count > 0)
            {
              compVacancies.Add(com);
            }
          }
        }
      }

      var topCompany = new List<VacancyFromTopCompanyViewModel>();
      topCompany.AddRange(compVacancies.Take(16).Select(c => new VacancyFromTopCompanyViewModel()
      {
        CompanyName = c.Name,
        CompanyId = c.Id,
        CompanyLogoUrl = c.CompanyLogoUrl
      }));



       var fielsdActivity = db.FieldActivities.Include(v => v.Vacancies).ToList();


      var vacanciesByFieldActivity = new List<VacancyByFieldViewModel>();
      vacanciesByFieldActivity.AddRange(fielsdActivity.Select(field => new VacancyByFieldViewModel()
      {
        FieldName = field.Name,
        FieldId = field.Id
      }));

      var countVacTopCompany = vacanciesFromTopCompany;
      vacanciesFromTopCompany = vacanciesFromTopCompany.ToList();

      var model = new HomePageViewModel()
      {
        NewVacancies = newVacancies,
        VacanciesByCity = vacanciesBYCityName,
        VacanciesFromTopCompanies = topCompany, //vacanciesFromTopCompany,
        VacanciesByFieldActivity = vacanciesByFieldActivity
      };
      return View("/Views/Home/Index.cshtml", model);
    }
  }
}
