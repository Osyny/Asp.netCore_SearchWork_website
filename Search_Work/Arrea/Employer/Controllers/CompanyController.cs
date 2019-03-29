using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Search_Work.Arrea.Employer.Models;
using Search_Work.Data;
using Search_Work.Models.ArreaDatabase.Resumes;
using Search_Work.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Employer.Controllers
{
  public class CompanyController : Controller
  {
    private oxana1404 dbContext;

    public CompanyController(oxana1404 dbContext)
    {
      this.dbContext = dbContext;
    }


    public ActionResult ProfileCompany()
    {
      var usName = HttpContext.User.Identity.Name;
      //var repo = new EmployerRepository(this.dbContext);
      //var employer = repo.GetByAccountUserName(usName);
      //var companyId 


      var company = dbContext.Companies
        .Include(e => e.Employers).ThenInclude(e => e.AccountUser)
        .Include(c => c.City)
        .FirstOrDefault(x => x.Employers.FirstOrDefault(i => i.AccountUser.Email == usName) != null);

      var emp = dbContext.Employers.Include(e => e.Company)
        .Include(e => e.AccountUser).FirstOrDefault(e => e.AccountUser.UserName == usName);

      var city = company.City == null ? "Немає" : company.City.Name;
      var address = company.Adress == null ? "Немає" : company.Adress;
      var fullAdress = $"{city}, {company.Adress}";

      var model = new PageAboutCompanyViewModel()
      {
        CompanyId = company.Id,
        EmployeeId = emp.Id,
        NameConpany = company.Name,
        Address = fullAdress,
        // Street = company.
        // toDo Recvisite
        // Requisites = company
        Phone = company.PhoneNumber,
        Email = company.Email,
        Fasebook = company.Facebook,
        CompanyLogo = company.CompanyLogoUrl,
        Description = company.Description,

        Site = company.Site,
        // toDo Certificates
        //Certificates = 
        Status = company.Status == false ? "Не активно" : "Активно"

      };

      return View("/Arrea/Employer/Views/Company/PageAboutCompany.cshtml", model);
    }

    // Сохраненные резюме
    public ActionResult SavedResume(int currentPage = 1)
    {

      var user = HttpContext.User.Identity.Name;

      var employer = dbContext.Employers.Include(i => i.AccountUser)
                .Include(e => e.Vacancies)
                .FirstOrDefault(x => x.AccountUser.Email == user);
      var cand = dbContext.Candidates.Include(i => i.AccountUser)
        .FirstOrDefault(c => c.AccountUser.UserName == user);


      var allresume = dbContext.Resumes
        .Include(resum => resum.SavedResumes).ThenInclude(r => r.Resume)
        .Include(resum => resum.SavedResumes).ThenInclude(r => r.Employer)
                .Include(i => i.Candidate).ThenInclude(c => c.City)
                .Where(i => i.SavedResumes
                .FirstOrDefault(x => x.Employer.Id == employer.Id) != null);
      //repoRes.GetByEmployerIdWhitSaveResume(employer.Id);

 

      var count = allresume.Count();

      const int skipCount = 4;
      Decimal decResumeCount = allresume.Count();
      Decimal decCountPages = Math.Ceiling(decResumeCount / skipCount);

      int countPages = Decimal.ToInt32(decCountPages);

      int resumeCount = Decimal.ToInt32(decResumeCount);

      if (currentPage > countPages)
      {
        currentPage = 1;
      }
      var savResum = dbContext.SavedResumes.Where(sr => sr.EmployerId == employer.Id).ToList();

      var resumesSaved = new List<ResumeViewModel>();


      resumesSaved.AddRange(allresume.Skip(skipCount * currentPage - skipCount)
              .Take(skipCount).ToList()
              .Select(res => new ResumeViewModel()
              {

                // toDo isCheced
                //IsCheced = 
                // toDo ActionWhithFavorite
                //ActionWhithFavorite = 
                Id = res.Id,
                NameResume = res.Candidate?.Name,
                Salary = res.Salary,
                Birthday = res.Candidate.Birthday,
                Cities = new List<CityNameViewModel>() { new CityNameViewModel()
                {
                    CityName = res.Candidate?.City?.Name
                }},

                Date = res.SavedResumes.FirstOrDefault(r => r.ResumeId == res.Id).DateSaved,
                SavedResumeId = res.SavedResumes.FirstOrDefault(r => r.ResumeId == res.Id).Id,

                FotoUrl = res.Candidate?.Avatar,

                LinkPageResum = Url.Action("AboutResume", "Resume", new { resumeId = res.Id })
                //ToDo LinkFavorites Resume
                //ChekedFavorites = 

              }));




      var model = new Page2ResumeViewModel()
      {

        EmployerId = employer.Id,
        Resumes = resumesSaved,
        Pagination = new CataloguePaginationViewModel()
        {
          CurrentPage = currentPage,
          DisplayOnPage = skipCount,
          TotalCount = countPages,
          ActionName = "SavedResume",
          ControllerName = "Company",
          ObjectParameter = new Dictionary<string, string> {
                    {
                        "employerId", employer.Id.ToString()
                    }}
        }
      };
      return View("/Arrea/Employer/Views/Company/SavedResumeVacancy.cshtml", model);
    }

    [HttpGet]
    public ActionResult DeleteSaveResume(Guid saveResumeId)
    {

      var savResum = dbContext.SavedResumes.FirstOrDefault(sr => sr.Id == saveResumeId);
     
      if (savResum == null)
      {
        return NotFound();
      }
      dbContext.SavedResumes.Remove(savResum);
      // dbContext.SaveChanges();

      return RedirectToAction(nameof(SavedResume));
    }

    [HttpPost]
    public ActionResult DeleteSaveResumeSubmit()
    {
      return RedirectToAction(nameof(SavedResume));
    }
  }
}

