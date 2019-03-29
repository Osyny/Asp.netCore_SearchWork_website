using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Search_Work.Arrea.Candidate.Models;
using Search_Work.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Search_Work.Models.Pagination;
using Search_Work.Models.ArreaDatabase.Vacancies;
using Search_Work.Models.ArreaDatabase;
using Search_Work.Models.ArreaDatabase.Resumes;
using Microsoft.AspNetCore.Identity;
using Search_Work.Models;
using Search_Work.Helpers;
using Search_Work.Models.DefaultData;

namespace Search_Work.Arrea.Candidate.Controllers
{
    public class VacancyController : Controller
    {
        private readonly oxana1404 db;
        private readonly UserManager<ApplicationUser> _userManager;

        public VacancyController(oxana1404 db, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            _userManager = userManager;
        }


        public ActionResult RecommendedVacancy(int currentPage = 1)
        {

            // TOdo  Long load

            var user = HttpContext.User.Identity.Name;


            var candidate = db.Candidates
              .Include(c => c.AccountUser).FirstOrDefault(c => c.AccountUser.Email == user);

            //  var dataSavedResume = comp.SavedResumes.Select(x => x.DateSaved).Where();

            var candidateName = candidate.Name;


            var allVacancy = db.Vacancies
              .Include(vac => vac.RecommendedVacancies)
              .Include(v => v.City)
               .Include(v => v.Employer).ThenInclude(e => e.Company)
              .Where(v => v.RecommendedVacancies.FirstOrDefault(x => x.CandidateId == candidate.Id) != null);



            const int skipCount = 5;
            Decimal decResumeCount = allVacancy.Count();
            Decimal decCountPages = Math.Ceiling(decResumeCount / skipCount);

            int countPages = Decimal.ToInt32(decCountPages);


            if (currentPage > countPages)
            {
                currentPage = 1;
            }

            var recommendedVacancy = new List<VacancyViewModel>();


            recommendedVacancy.AddRange(allVacancy.Skip(skipCount * currentPage - skipCount)
                .Take(skipCount).ToList()
                .Select(vac => new VacancyViewModel()
                {

              // toDo isCheced
              //IsCheced = 
              // toDo ActionWhithFavorite
              //ActionWhithFavorite = 
              Id = vac.Id,
                    VacancyName = vac.Name,
                    Salary = vac.Wage,

                    CityName = vac.City?.Name,
                    CompanyName = vac.Employer.Company.Name,

                    DateSaved = vac.RecommendedVacancies.Where(i => i.CandidateId == candidate.Id).Select(x => x.DateSaved)
                            .FirstOrDefault(), //candidate.RecommendedVacancies.Where(i => i.VacancyId == vac.Id).Select(x => x.DateSaved),

              CompanyLogoUrl = vac.Employer?.Company?.CompanyLogoUrl,
              //toDo VideoUrl
              //VideoUrl =
              Link = Url.Action("AboutVacancy", "Vacancy", new { vacancyId = vac.Id, Area = "" }),
              //ToDo LinkFavorites Resume
              //ChekedFavorites = 

          }));



            var model = new PageRecommendedVacancyViewModel()
            {

                CandidateName = candidateName,
                CandidateId = candidate.Id,

                Vacancies = recommendedVacancy,
                Pagination = new CataloguePaginationViewModel()
                {
                    CurrentPage = currentPage,
                    DisplayOnPage = skipCount,
                    TotalCount = countPages,

                    ActionName = "RecommendedVacancy",
                    ControllerName = "Vacancy",
                    ObjectParameter = new Dictionary<string, string>
                    {
                        {
                            "candidateId", candidate.Id.ToString()
                        }
                    }
                }
            };
            return View("/Arrea/Candidate/Views/Candidat/RecommendedVacancy.cshtml", model);
        }

        public ActionResult PaternSearchVacancy()
        {

            // IDENTITY USER NAME  HttpContext
            var userName = HttpContext.User.Identity.Name;



            var user = db.ApplicationUsers.Include(a => a.Candidate).ThenInclude(c => c.AccountUser)
                      .FirstOrDefault(x => x.Email == userName);

            var allPaterns = db.PaternSearchVacancies/*.Include(p => p.City)
        .Include(p => p.FieldActivity)*/.ToList();



            var paterns = new List<PaternSearchVacancyViewModel>();



            paterns.AddRange(allPaterns.Select(pat => new PaternSearchVacancyViewModel()
            {

                Id = pat.Id,
                Request = pat.Request != "" ? pat.Request : "",
                FieldActivityName = db.FieldActivities.Include(f => f.Vacancies)
                                   .Include(f => f.Resumes).FirstOrDefault(x => x.Id == pat.FieldActivity)?.Name,
                CityName = db.Cities.ToList().FirstOrDefault(p => p.Id == pat.City)?.Name,


                LinkToResume = Url.Action("VacancyWhithPaternSearch", "Vacancy", new { paternSearchId = pat.Id }),

                Count = FilterVacancyPaternSearch(pat.Id).Count

            }));




            var model = new PagePaternSearchVacancyViewModel()
            {
                CandidateId = user.Candidate.Id,
                Paterns = paterns
            };

            //var filterVacancy = FilterResumesPaternSearch()
            return View("Arrea/Candidate/Views/Candidat/PaternSearchVacancy.cshtml", model);
        }

        public List<Vacancy> FilterVacancyPaternSearch(Guid paternSearchId)
        {

            var patern = db.PaternSearchVacancies.FirstOrDefault(p => p.Id == paternSearchId);

            //Vacancy
            IQueryable<Vacancy> filterVacancies = db.Vacancies;


            //  if (patern.Request != "")
            {
                if (!string.IsNullOrEmpty(patern.Request))
                {
                    filterVacancies = filterVacancies.Include(i => i.Employer)
                        .Where(i => i.Name.Contains(patern.Request));
                }
            }
            var filter = filterVacancies.ToList();

            City city = null;

            if (patern.City != Guid.Empty)
            {
                city = db.Cities.Include(i => i.Vacancies)
                        .Include(i => i.Companies)
                        .Include(i => i.Candidates).FirstOrDefault(c => c.Id == patern.City);

                if (city != null)
                {
                    filterVacancies = filterVacancies.Include(v => v.City)
                        .Where(i => i.City.Id == patern.City);
                }
            }

            filter = filterVacancies.ToList();


            //  if (patern.Salary != 0)
            {
                if (!string.IsNullOrEmpty(patern.Salary.ToString()) && patern.Salary != 0)
                {
                    filterVacancies = filterVacancies.Where(i => i.Wage == patern.Salary);
                }
            }


            ExperienceOfWork experience = null;

            if (patern.ExperienceOfWork != Guid.Empty)
            {
                experience = db.ExperienceOfWorks.Include(e => e.Vacancies).FirstOrDefault(ex => ex.Id == patern.ExperienceOfWork);

                if (experience != null)
                {
                    filterVacancies = filterVacancies.Include(e => e.ExperienceOfWork)
                        .Where(e => e.ExperienceOfWork.Id == patern.ExperienceOfWork);
                }
            }


            EmploymentType employment = null;
            if (patern.Employment != Guid.Empty)
            {
                employment = db.Employments.Include(e => e.Experiences).ThenInclude(e => e.Resume)
                        .Include(i => i.Vacancies).FirstOrDefault(e => e.Vacancies.Select(i => i.Id == patern.Employment) != null);

                if (employment != null)
                {
                    filterVacancies = filterVacancies.Include(e => e.TypeEmployment)
                        .Where(e => e.TypeEmployment.Id == patern.Employment);
                }
            }

            return filterVacancies.Include(i => i.Employer.Company).ToList();

        }

        public ActionResult VacancyWhithPaternSearch(Guid paternSearchId, int currentPage = 1)
        {

            var filterVacancies = FilterVacancyPaternSearch(paternSearchId);

            // --------------------------- count Pages -----------------------

            int skipCount = 7;

            Decimal countVacancy = filterVacancies.Count();
            Decimal decCountPage = Math.Ceiling(countVacancy / skipCount);
            int countPages = Decimal.ToInt32(decCountPage);

            if (currentPage > countPages)
            {
                currentPage = 1;
            }

            filterVacancies = filterVacancies.Skip(skipCount * currentPage - skipCount).Take(skipCount).ToList();


            var vacancies = new List<VacancieByPaternViewModel>();

            vacancies.AddRange(filterVacancies.Select(vacancy => new VacancieByPaternViewModel()
            {
                Id = vacancy.Id,
                DateCreate = vacancy.DateCreate,
                VacancyName = vacancy.Name,
                Salary = vacancy.Wage,
                City = vacancy.City.Name,
                LogoUrl = vacancy.Employer.Company.CompanyLogoUrl,
                LinkPageVacancy = Url.Action("AboutVacancy", "Vacancy", new { vacancyId = vacancy.Id, Area = "" }),
                CompanyName = vacancy.Employer.Company.Name

            }));




            var model = new PageVacanciesWhithPaternViewModel()
            {
                Vacancies = vacancies,
                Pagination = new CataloguePaginationViewModel()
                {
                    CurrentPage = currentPage,
                    DisplayOnPage = skipCount,
                    TotalCount = countPages,
                    ActionName = "VacancyWhithPaternSearch",
                    ControllerName = "Vacancy",
                    ObjectParameter = new Dictionary<string, string> {
                    {
                        "paternSearchId", paternSearchId.ToString()
                    }}

                }
            };

            return View("/Arrea/Candidate/Views/Candidat/VacancyWhithPaternSearch.cshtml", model);
        }

        public ActionResult AddPaternSearchVacancy()
        {
            var user = HttpContext.User.Identity.Name;

            var model = new AddPaternSearchVacancyViewModel()
            {
                UserName = user, 
           
            };

            model.Cities = db.Cities.Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            }).ToList();
            model.FieldActivity = db.FieldActivities.Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            }).ToList();
            model.ExperienceOfWorks = db.ExperienceOfWorks.Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.NameField,
            }).ToList();
            model.Employments = db.Employments.Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            }).ToList();
            return View("/Arrea/Candidate/Views/Candidat/AddPaternSearchVacancy.cshtml", model);
        }

        [HttpPost]
        public ActionResult AddPaternSearchVacancy(AddPaternSearchVacancyViewModel model)
        {
            var fieldAct = db.FieldActivities.Include(f => f.Vacancies).FirstOrDefault(f => f.Id == model.FieldActivityId);
            var city = db.Cities.Include(c => c.Vacancies).FirstOrDefault(c => c.Id == model.Id);
            var employment = db.Employments.Include(e => e.Vacancies).FirstOrDefault(e => e.Id == model.EmploymentId);
            var exOfWork = db.ExperienceOfWorks.Include(e => e.Vacancies).FirstOrDefault(e => e.Id == model.ExperienceOfWorkId);

            var newPaternSearch = new PaternSearchVacancy()
            {
                Id = Guid.NewGuid(),
                Request = model.Request,
                Salary = model.Salary,
                City = city == null ? Guid.Empty : city.Id,
                Employment = employment == null ? Guid.Empty : employment.Id,
                FieldActivity = fieldAct == null ? Guid.Empty : fieldAct.Id,
                ExperienceOfWork = exOfWork == null ? Guid.Empty : exOfWork.Id,
            };

            db.PaternSearchVacancies.Add(newPaternSearch);
            db.SaveChanges();

            return RedirectToAction(nameof(PaternSearchVacancy));
        }

        //[HttpPost]
        //public ActionResult PaternSearchVacancySubmit(AddPaternSearchVacancyViewModel model)
        //{

        //    var newPaternSearchVacancy = new PaternSearchVacancy()
        //    {
        //        Id = Guid.NewGuid(),
        //        //City

        //    };
        //    return View("/Arrea/Candidate/Views/Candidat/MessAddPaternSearchVacancy.cshtml");
        //}

        //  Отклики на отправленные резюме ResponsesVacansy
        public ActionResult ResponsesToResume()
        {

            // IDENTITY USER NAME  HttpContext
            var userName = HttpContext.User.Identity.Name;

            var user = _userManager.Users.Include(u => u.Candidate).FirstOrDefault(i => i.Email == userName);


            var allVacancy = db.Vacancies.Include(v => v.ResponsesVacansy)
                .ThenInclude(v => v.ResponseType)
                .Include(v => v.ResponsesVacansy)
                .ThenInclude(v => v.ResponseType)
                .Include(v => v.ResponsesVacansy)
                .ThenInclude(v => v.Resume)
                .Include(v => v.Employer)
                .ThenInclude(v => v.Company)
              .Where(i => i.ResponsesVacansy.FirstOrDefault(x => x.Resume.CandidateId == user.Candidate.Id) != null);

            //// var repoRespToResum = new ResponseToResumeRepository(this.dbContext);


            var vacancies = new List<DataResponseToResumeViewModel>();



            vacancies.AddRange(allVacancy.Select(vac => new DataResponseToResumeViewModel()
            {
                Id = vac.Id,
                CompanyName = vac.Employer.Company.Name,
                VacancyName = vac.Name,
                DataCreate = vac.DateCreate,

                ResumeRespList = vac.ResponsesVacansy.Select(resp => new ResumeRespViewModel()
                {
                   // DataCreate = resp.DateCreate,
                    DataSend = resp.DataResponse,// vac.ResponsesVacansy.Select(i => i.DataResponse).FirstOrDefault(),
                    Status = resp.ResponseTypeId == ResponseTypeIdDefault.Denide ? "Відмовлено" : "Переглянуто"// vac.ResponsesVacansy.Where(re => re.VacancyId == vac.Id).Select(r => r.ResponseType.Id).FirstOrDefault()
                                                                                                               //repoRespToResum.GetByVacId(vac.Id).DataResponse})

                }).ToList()
            }));

            var model = new ResponseToResumeViewModel()
            {
                Vacannies = vacancies
            };

            return View("/Arrea/Candidate/Views/Resumes/ResponsesToResume.cshtml", model);


        }

        public ActionResult SavedVacancy()
        {
            // IDENTITY USER NAME  HttpContext
            var userName = HttpContext.User.Identity.Name;

            var user = _userManager.Users.Include(u => u.Candidate).FirstOrDefault(i => i.Email == userName);

            var allVacancy = db.Vacancies.Include(v => v.SavedVacancies).ThenInclude(v => v.Vacancy)
                                      .Include(v => v.Employer)
                                      .Where(v => v.SavedVacancies.FirstOrDefault(s => s.CandidateId == user.Candidate.Id) != null);

            var vacancies = new List<SavedVacancyViewModel>();

            vacancies.AddRange(allVacancy.Select(vacancy => new SavedVacancyViewModel()
            {
                Id = vacancy.Id,
                CompanyName = vacancy.Employer.Company.Name,
                VacancyName = vacancy.Name,
                DataCreate = vacancy.DateCreate,
                LinkToVacancy = Url.Action("AboutVacancy", "Vacancy", new { vacancyId = vacancy.Id, Area = "" })

            }));
            var model = new PageSavedVacancyViewModel()
            {
                Vacannies = vacancies
            };

            return View("/Arrea/Candidate/Views/Resumes/SavedVacancy.cshtml", model);
        }

        public ActionResult DeleteSavedVacancy(Guid id)
        {
            // IDENTITY USER NAME  HttpContext
            var userName = HttpContext.User.Identity.Name;

            var user = _userManager.Users.Include(u => u.Candidate).FirstOrDefault(i => i.Email == userName);

            var savVacancy = db.SavedVacancies.Include(v => v.Vacancy).FirstOrDefault(v => v.VacancyId == id);

            db.SavedVacancies.Remove(savVacancy);
      
            db.SaveChanges();
     

            return RedirectToAction(nameof(SavedVacancy));
        }
    }
}
