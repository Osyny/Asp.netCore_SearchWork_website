using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Search_Work.Data;
using Search_Work.Models.ArreaDatabase.Vacancies;
using Search_Work.Models.ViewModel.Home.Company;
using Search_Work.Views.Home.HomeVacancy;
using Search_Work.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Search_Work.Models.Pagination;
using Search_Work.Models.ArreaDatabase;
using Search_Work.Models.ArreaDatabase.Resumes;
using Search_Work.Models.ViewModel.Candidate.Resumes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Search_Work.Helpers;

namespace Search_Work.Controllers
{
    public class VacancyController : Controller
    {
        private oxana1404 dbContext;
        public VacancyController(oxana1404 dbContext)
        {
            this.dbContext = dbContext;
        }

        public ActionResult Index()
        {
            return Content("");
        }


        public ActionResult AboutVacancy(Guid vacancyId)
        {

            var vacancy = dbContext.Vacancies.Include(v => v.Employer).ThenInclude(e => e.AccountUser)
                                      .Include(v => v.FieldActivity)
                                      .Include(v => v.Employer).ThenInclude(e => e.Company)
                                      .Include(v => v.TypeEmployment)
                                      .Include(v => v.ExperienceOfWork)
                                      .Include(v => v.City)
                                      .FirstOrDefault(v => v.Id == vacancyId);


            // -------------------------------------------------- View -------------------------

           // var viewVacRepo = new ViewPageRepository()


            Candidate candidate = HttpContext.User != null ? 
                dbContext.Candidates.Include(e => e.AccountUser).Include(c => c.Resumes)
              .FirstOrDefault(x => x.AccountUser.UserName == HttpContext.User.Identity.Name) : null;

            var viewVac = new Models.ArreaDatabase.Resumes.ViewPage();

            viewVac.Id = Guid.NewGuid();
            viewVac.Vacancy = vacancy;
            viewVac.DataView = DateTime.Now;
            viewVac.Candidate = candidate;
           // viewVac.ResumeId = null;

            dbContext.ViewsPages.Add(viewVac);
            dbContext.SaveChanges();


            // Similar vacancy
            var vacanciesSimilar = dbContext.Vacancies
              .Include(v => v.Employer).ThenInclude(e => e.Company)
              .Include(v => v.City).ToList();
            Random rnd = new Random();

            int countSimilVacancy = rnd.Next();
            var similarVacancy = new List<SimilarVacanciesViewModel>();

            similarVacancy.AddRange(vacanciesSimilar.Take(5).Select(vacncy => new SimilarVacanciesViewModel()
            {
                VacancyName = vacancy.Name,
                Salary = vacncy.Wage,
                CompanyName = vacncy.Employer?.Company?.Name,
                CityName = vacncy.City?.Name,
                TypeEmployment = vacancy.TypeEmployment,

                Link = Url.Action("AboutVacancy", "Vacancy", new { vacancyId = vacancy.Id }),

            }));

            var model = new PageAboutVacncyViewModel();

            if (candidate != null)
            {
                model.Candidate = candidate;
            }

            model.DateCriate = vacancy.DateCreate;
            model.FieldActivityName = vacancy.FieldActivity.Name;
            model.VacancyName = vacancy.Name;
            model.VacancyId = vacancyId;

            model.Wage = vacancy.Wage;
            model.CompanyName = vacancy.Employer?.Company?.Name;
            model.LinkAllVacancyThisCompany = Url.Action("AboutCompany", "CompanyHome", new { companyId = vacancy.Employer.Company.Id });

            model.CompanyLogoUrl = vacancy.Employer?.Company?.CompanyLogoUrl;
            model.CityName = vacancy.City?.Name;
            model.TypeEmployment = vacancy.TypeEmployment?.Name;
            model.ExperienceOfWork = vacancy.ExperienceOfWork?.NameField;


            model.Site = vacancy.Site;
            model.Linkedin = vacancy.Linkedin;
            model.Fasebook = vacancy.Facebook;

            model.Description = vacancy.Description;
            model.Responsibilities = vacancy.Responsibilities;
            model.Requirement = vacancy.Requirement;
            model.ForeignLanguages = vacancy.ForeignLanguages;
            model.AdditionalRequirements = vacancy.AdditionalRequirements;

            if (vacancy.IsUseCompanyContact)
            {
                // ToDo ContactPerson - Name contact person
                model.ContactPerson = vacancy.Employer.AccountUser.Email;
                model.PhoneNumberPerson = vacancy.Employer.Company.PhoneNumber;
                model.EmailPerson = vacancy.Employer.Company.Email;
            }
            else if (vacancy.IsUsePersonalContact)
            {
                // ??????????????????????????
                model.ContactPerson = vacancy.Employer.Contact.Name;
                model.PhoneNumberPerson = vacancy.Employer.Company.PhoneNumber;
                model.EmailPerson = vacancy.Employer.Contact.Email;
            }
            else
            {
                model.ContactPerson = vacancy.ContactNamePerson;
                model.PhoneNumberPerson = vacancy.PhoneNumberPerson;
                model.EmailPerson = vacancy.EmailPerson;
            }

            //model.PhoneNumberPerson = vacancy.Employer.Company.PhoneNumber;
            //  model.EmailPerson = vacancy.Employer.Company.Email;




            model.SimilarVacancies = similarVacancy;





            return View("/Views/Home/HomeVacancy/PageAboutVacancy.cshtml", model);
        }

        public ActionResult Vacansies()
        {
            var vacanciesField = dbContext.Vacancies
             .Include(v => v.FieldActivity)
                .Include(v => v.Employer).ThenInclude(e => e.Company)
                .Include(v => v.City)
               .ToList().OrderByDescending(v => v.DatePublication);


            var fieldsActivity = dbContext.FieldActivities.Include(f => f.Vacancies)
                                     .Include(f => f.Resumes).ToList();

            var vacanciesByFieldActivity = new List<FieldActivityWhithViewModel>();

            vacanciesByFieldActivity.AddRange(fieldsActivity.Where(x => x.Vacancies.Any()).Select(field => new FieldActivityWhithViewModel()
            {
                FieldActivityName = field.Name,
                FieldActivityId = field.Id,
                CountVacancyByFieldActivity = field.Vacancies.Count
            }));


            var model = new PageFieldActivityWhithVacancyViewModel()
            {

                VacanciesByFieldActivity = vacanciesByFieldActivity,

            };
            return View("/Views/Home/HomeVacancy/Vacansies.cshtml", model);
        }


        /// <summary>
        /// Вакансии по сферам
        /// </summary>
        /// <param name="fieldActivityId"></param>
        /// <param name="cityId"></param>
        /// <param name="dateFilter"></param>
        /// <param name="currentPage"></param>
        /// <returns></returns>VacancyCatalogByActivityField
        public ActionResult VacancyCatalogByActivityField(Guid fieldActivityId, Guid cityId, string dateFilter = null, int currentPage = 1)
        {
            var vacanciesField = dbContext.Vacancies
              .Include(v => v.FieldActivity)
                 .Include(v => v.Employer).ThenInclude(e => e.Company)
                 .Include(v => v.City)
                .Where(x => x.FieldActivityId == fieldActivityId).ToList().OrderByDescending(v => v.DatePublication);



            var fieldActivity = dbContext.FieldActivities.Include(f => f.Vacancies)
                                   .Include(f => f.Resumes).FirstOrDefault(x => x.Id == fieldActivityId);



            var vacanciesByField = new List<Models.ViewModel.Home.Company.PageVacancyByFieldViewModel>();

            // --------------------------- count Pages -----------------------

            int skipCount = 6;

            IEnumerable<Vacancy> vacanciesFieldActyvity = null;

            if (dateFilter != null)
            {
                switch (dateFilter)
                {
                    case FieldsMonth.MonthId:
                        vacanciesFieldActyvity = vacanciesField.Where(v => v.DateCreate > DateTime.Now.AddMonths(-1) && v.DateCreate < DateTime.Now);
                        break;
                    case FieldsMonth.WeеkId:
                        vacanciesFieldActyvity = vacanciesField.Where(v => v.DateCreate > DateTime.Now.AddDays(-7) && v.DateCreate < DateTime.Now);
                        break;
                    case FieldsMonth.DayId:
                        vacanciesFieldActyvity =
                            vacanciesField.Where(v => v.DateCreate > DateTime.Now.AddDays(-2) && v.DateCreate < DateTime.Now);
                        break;
                    default:
                        break;

                }
            }
            else
            {
                vacanciesFieldActyvity = vacanciesField;
            }

            Decimal decCountVacancies = vacanciesFieldActyvity.Count();

            Decimal decCountPage = Math.Ceiling(decCountVacancies / skipCount);

            int countPages = Decimal.ToInt32(decCountPage);
            int countVacancies = Decimal.ToInt32(decCountVacancies);


            if (currentPage > countPages)
            {
                currentPage = 1;
            }


            vacanciesFieldActyvity = vacanciesFieldActyvity.Skip(skipCount * currentPage - skipCount).Take(skipCount);

            vacanciesByField.AddRange(vacanciesFieldActyvity
                /* .Skip(skipCount * currentPage - skipCount)
                 .Take(skipCount)*/
                .Select(vacancy => new Models.ViewModel.Home.Company.PageVacancyByFieldViewModel()
                {
                    Id = vacancy.Id,
                    VacancyName = vacancy.Name,
                    CompanyName = vacancy.Employer?.Company?.Name,
                    CityName = vacancy.City?.Name,
                    Salary = vacancy.Wage,
                    DateCriate = vacancy.DateCreate,
                    CompanyLogoUrl = vacancy.Employer?.Company?.CompanyLogoUrl,
                    Description = vacancy.Description,
                    Link = Url.Action("AboutVacancy", "Vacancy", new { vacancyId = vacancy.Id }),

                }));

            var paginationViewModel = new CataloguePaginationViewModel()
            {
                CurrentPage = currentPage,
                DisplayOnPage = skipCount,
                TotalCount = countPages,
                ActionName = "VacancyCatalogByActivityField",
                ControllerName = "Vacancy",
                ObjectParameter = new Dictionary<string, string> {
                {
                    "fieldActivityId", fieldActivityId.ToString()
                }}
            };


            var model = new PageCatalogVacancyByFieldViewModel()
            {

                FialdActivityName = fieldActivity.Name,
                CountVacancyByFieldActivity = countVacancies,
                VacanciesByField = vacanciesByField,
                Pagination = paginationViewModel,
                FieldId = fieldActivityId,
                CurrentPage = currentPage,

                SelectedFilter = dateFilter,
            };

            return View("/Views/Home/HomeVacancy/CatalogVacancyByFieldActivity.cshtml", model);
        }

        public ActionResult VacancyCatalogByCityld(Guid cityId, string dateFilter = null, int currentPage = 1)
        {



            var city = dbContext.Cities.Include(i => i.Vacancies)
                      .Include(i => i.Companies)
                      .Include(i => i.Candidates).FirstOrDefault(c => c.Id == cityId);

            var vacanciesCityFilter = dbContext.Vacancies.Include(v => v.Employer).ThenInclude(e => e.Company)
                                                          .Include(v => v.City).Where(v => v.CityId == cityId).ToList()
                                                          .OrderByDescending(v => v.DatePublication);
            var vacanciesByCity = new List<Models.ViewModel.Home.Company.PageVacancyByFieldViewModel>();

            // --------------------------- count Pages -----------------------

            int skipCount = 6;

            IEnumerable<Vacancy> vacanciesCity = null;

            if (dateFilter != null)
            {
                switch (dateFilter)
                {
                    case FieldsMonth.MonthId:
                        vacanciesCity = vacanciesCityFilter.Where(v => v.DateCreate > DateTime.Now.AddMonths(-1) && v.DateCreate < DateTime.Now);
                        break;
                    case FieldsMonth.WeеkId:
                        vacanciesCity = vacanciesCityFilter.Where(v => v.DateCreate > DateTime.Now.AddDays(-7) && v.DateCreate < DateTime.Now);
                        break;
                    case FieldsMonth.DayId:
                        vacanciesCity =
                            vacanciesCityFilter.Where(v => v.DateCreate > DateTime.Now.AddDays(-2) && v.DateCreate < DateTime.Now);
                        break;
                    default:
                        break;

                }
            }
            else
            {
                vacanciesCity = vacanciesCityFilter;
            }

            Decimal decCountVacancies = vacanciesCity.Count();

            Decimal decCountPage = Math.Ceiling(decCountVacancies / skipCount);

            int countPages = Decimal.ToInt32(decCountPage);
            int countVacancies = Decimal.ToInt32(decCountVacancies);


            if (currentPage > countPages)
            {
                currentPage = 1;
            }


            vacanciesCity = vacanciesCity.Skip(skipCount * currentPage - skipCount).Take(skipCount);

            vacanciesByCity.AddRange(vacanciesCity
                .Select(vacancy => new Models.ViewModel.Home.Company.PageVacancyByFieldViewModel()
                {
                    Id = vacancy.Id,
                    VacancyName = vacancy.Name,
                    CompanyName = vacancy.Employer?.Company?.Name,
                    CityName = vacancy.City?.Name,
                    Salary = vacancy.Wage,
                    DateCriate = vacancy.DatePublication,
              // CompanyLogoUrl =
              Description = vacancy.Description,
                    Link = Url.Action("AboutVacancy", "Vacancy", new { vacancyId = vacancy.Id }),

                }));


            var model = new PageCatalogVacancyByFieldViewModel()
            {

                CityName = city.Name,
                CountVacancyByFieldActivity = countVacancies,
                VacanciesByField = vacanciesByCity,

                Pagination = new CataloguePaginationViewModel()
                {
                    CurrentPage = currentPage,
                    DisplayOnPage = skipCount,
                    TotalCount = countPages,
                    ActionName = "VacancyCatalogByCityld",
                    ControllerName = "Vacancy",
                    ObjectParameter = new Dictionary<string, string> {
                    {
                        "cityId", cityId.ToString()
                    }}
                },

                CityId = cityId,
                CurrentPage = currentPage,

                SelectedFilter = dateFilter
            };

            return View("/Views/Home/HomeVacancy/CatalogVacancyByCity.cshtml", model);
        }

        // Todo saveVacancy click on button in AboutVacancy
        public ActionResult SaveVacancySubmit(Guid vacancyId)
        {
            // Identity User
            var userIdentity = HttpContext.User.Identity.Name;

            var user = dbContext.ApplicationUsers
              .Include(u => u.Employer).FirstOrDefault(u => u.Email == userIdentity);

            var candidate = dbContext.Candidates
                .Include(c => c.AccountUser)
                .FirstOrDefault(c => c.AccountUser.Email == userIdentity);

            var vacancy = dbContext.Vacancies.Include(v => v.Employer.AccountUser.Candidate.Resumes)
                                           .Include(v => v.Employer.Vacancies)
                                           .FirstOrDefault(v => v.Id == vacancyId);

            if (candidate != null)
            {
                SavedVacancy newSavedVacancy = new SavedVacancy();

                newSavedVacancy.Id = Guid.NewGuid();
                newSavedVacancy.Candidate = candidate;

                newSavedVacancy.Vacancy = vacancy;
                newSavedVacancy.DateSaved = DateTime.Now;

                dbContext.SavedVacancies.Add(newSavedVacancy);
                dbContext.SaveChanges();
            }

            var res = new ResultStatusHelper(true)
            {
                Message = $"Вакансия сохранена ",
            };
            return RedirectToAction(nameof(AboutVacancy), new { vacancyId = vacancy.Id});
        }

        // Отклик на вакансію
        // Todo ResponseToVacancy click on button in AboutVacancy
        public ActionResult PageResumesResponseToVacancy(Guid vacancyId)
        {
            // Identity User
            var userIdentity = HttpContext.User.Identity.Name;

            var user = dbContext.ApplicationUsers
              .Include(u => u.Employer).FirstOrDefault(u => u.Email == userIdentity);

            var candidate = dbContext.Candidates.Include(r => r.AccountUser).FirstOrDefault(c => c.AccountUser == user);

            var resumes = dbContext.Resumes.Include(r => r.Candidate).Where(r => r.Candidate.Id == candidate.Id)
                                                   .Select(form => new SelectListItem()
                                                   {
                                                       Text = form.Name,
                                                       Value = form.Id.ToString()
                                                   }).ToList();
            var vac = dbContext.Vacancies.FirstOrDefault(r => r.Id == vacancyId);

            var model = new PageResumeCandidateToResponseViewModel()
            {
                Candidate = candidate,
                CandidateId = candidate.Id,
                Resumes = resumes,
                Vacancy = vac,
                VacancyId = vac.Id
            };

            return View("/Views/Home/HomeVacancy/PageResumeCandidateToResponse.cshtml", model);
        }

        // Отклик на вакансію
        // Todo ResponseToVacancy click on button in AboutVacancy
        [HttpPost]
        public ActionResult ResponseToVacancy(PageResumeCandidateToResponseViewModel model/* Guid vacancyId, Guid resumId*/)
        {
            // Identity User
            var userIdentity = HttpContext.User.Identity.Name;

            var user = dbContext.ApplicationUsers
              .Include(u => u.Employer).FirstOrDefault(u => u.Email == userIdentity);



            var resume = dbContext.Resumes.Include(r => r.Candidate)
                                         .Include(r => r.Candidate.AccountUser)
                                        .FirstOrDefault(r => r.Id == model.ResumeId);


            var vacancy = dbContext.Vacancies.Include(v => v.Employer.AccountUser.Candidate.Resumes)
                                          .Include(v => v.Employer.Vacancies)
                                          .FirstOrDefault(v => v.Id == model.VacancyId);

            // var repoResp = new ResponseRepository(this.dbContext);
            if (user.Candidate != null)
            {
                ResponseToVacancy newResponseToVacancy = new ResponseToVacancy();

                newResponseToVacancy.Id = Guid.NewGuid();


                // ToDo newResponseToVacancy.Resume ++ Resume or ++Candidata


                newResponseToVacancy.Resume = resume;
                newResponseToVacancy.Vacancy = vacancy;
                newResponseToVacancy.DataResponse = DateTime.Now;


                dbContext.ResponsesToVacancy.Add(newResponseToVacancy);
                dbContext.SaveChanges();



                model.Vacancy = vacancy;
                model.VacancyName = vacancy.Name;



                return View("/Views/Home/HomeVacancy/PageResponseAdd.cshtml", model);
            }

            return View("/Views/Home/HomeVacancy/PageResponseError.cshtml", model);
        }

    }
}
