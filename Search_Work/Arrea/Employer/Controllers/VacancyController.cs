using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Search_Work.Arrea.Candidate.Models;
using Search_Work.Arrea.Employer.Models;
using Search_Work.Data;
using Search_Work.Models.ArreaDatabase.Vacancies;
using Search_Work.Models.DefaultData;
using Search_Work.Models.Helper;
using Search_Work.Models.ViewModel;
using Search_Work.Models.ViewModel.Home.Resumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Search_Work.Arrea.Employer.Models.CreateVacancyViewModel;

namespace Search_Work.Arrea.Employer.Controllers
{
    public class VacancyController : Controller
    {
        private readonly oxana1404 dbContext;

        public VacancyController(oxana1404 context)
        {
            this.dbContext = context;

        }

        // VACANCIES_Employer  ----------------------------------------------------------
        public ActionResult EmploeeVacancies(string filterType = null, string nameVacancy = null)
        {

            var usName = HttpContext.User.Identity.Name;


            List<Vacancy> allVacanciesCandidate = null;
            if (nameVacancy != null)
            {
                allVacanciesCandidate = dbContext.Vacancies.Include(vac => vac.PageViews).ThenInclude(res => res.Vacancy)
                            .Include(resum => resum.Responses).ThenInclude(res => res.Vacancy)
                  .Include(v => v.Employer).ThenInclude(v => v.AccountUser)
                  .Where(v => v.Employer.AccountUser.Email == usName && v.Name == nameVacancy).ToList();

                //.Include(vac => vac.PageViews).Include(vac => vac.Responses).Include(v => v.Employer.AccountUser).Where(x => x.Employer.AccountUser.Email == userName);
            }
            else
            {
                allVacanciesCandidate = dbContext.Vacancies.Include(v => v.City)
                            .Include(vac => vac.PageViews).ThenInclude(res => res.Vacancy)
                            .Include(resum => resum.Responses).ThenInclude(res => res.Vacancy)
                  .Include(v => v.Employer)
                  .ThenInclude(res => res.AccountUser)
                  .Where(v => v.Employer.AccountUser.Email == usName).ToList();
            }


            var count = allVacanciesCandidate.Count();

            // ToDo переделать e.AccountUser.Email на e.AccountUser.FirstName
            var employer = dbContext.Employers.Include(e => e.AccountUser)
                                                .Include(e => e.Company).Include(e => e.Vacancies)
                                        .FirstOrDefault(e => e.AccountUser.Email == usName);


            IEnumerable<Vacancy> vacansiesByFilter = null;

            var vacanciesEmployer = new List<EmployerVacancieViewdel>();

            if (filterType != null)
            {
                switch (filterType)
                {
                    case TypesSortVacancy.DataId:
                        vacansiesByFilter = allVacanciesCandidate.OrderBy(r => r.DateCreate).ToList();
                        break;
                    case TypesSortVacancy.ResponseId:
                        vacansiesByFilter = allVacanciesCandidate.OrderByDescending(r => r.Responses.Count);
                        break;
                    case TypesSortVacancy.NameId:
                        vacansiesByFilter = allVacanciesCandidate.OrderBy(r => r.Name).ToList();
                        break;
                        //ToDo Sort Region - ?????
                        //case TypesSortVacancy.RegionId:
                        //    vacansiesByFilter = allVacanciesCandidate.OrderBy(r => r.Employer.AccountUser.);
                        //    break;
                }

            }
            else
            {
                vacansiesByFilter = allVacanciesCandidate;
            }

            vacanciesEmployer.AddRange(vacansiesByFilter.Select(vac => new EmployerVacancieViewdel()
            {
                VacancyId = vac.Id,

                DateCreate = vac.DateCreate,

                NameVacancies = vac.Name,
                Salary = vac.Wage,
                City = vac.City?.Name,
                DatePublication = vac.DatePublication.ToString("dd/MM/yyyy"),
                Status = vac.Status,
                //// toDo Editor
                //Editor = "Павлов Олександр",

                CountLinkFeeback = vac.Responses.Count(),

                CountLinkNewFeeback = vac.Responses.Count(),

                CountLinkViews = vac.PageViews.Count,// repoResume.GetByVacancyIdWhitViewPage(vac.Id).Count(),//vac.ViewsResume.Count,
                                                     // toDo CountCandidate


            }));


            //
            var model = new PageEmployeeVacanciesViewModel()
            {
                EmployeeVacancies = vacanciesEmployer,
                CompanyId = employer.CompanyId.Value,

                TypeSortFilter = filterType
            };
            return View("/Arrea/Employer/Views/Employee/EmployeeVacancies.cshtml", model);
        }

        public ActionResult Create()
        {


            var cities = dbContext.Cities.Select(city => new CityViewModel()
            {
                CityName = city.Name,
                Id = city.Id
            }).ToList();

            var fieldsActivity = dbContext.FieldActivities.Select(field => new FieldActivityViewModel()
            {
                Name = field.Name,
                Id = field.Id
            }).ToList();


            var employments = dbContext.Employments.Include(v => v.Vacancies).Select(field => new EmploymentViewModel()
            {
                Id = field.Id,
                NameField = field.Name
            }).ToList();


            var listExpOfWork = dbContext.ExperienceOfWorks.Include(v => v.Vacancies).Select(field => new ExperienceOfWorkViewModel()
            {
                Id = field.Id,
                NameField = field.NameField
            }).ToList();

            var model = new CreateVacancyViewModel()
            {
                Cities = cities,
                Fields = fieldsActivity,
                Employments = employments,
                ExperienceOfWorks = listExpOfWork,

                // EmployerId = employer.Id
            };

            return View("/Arrea/Employer/Views/Vacancy/CreateVacancy.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CreateVacancyViewModel model)
        {



            // Employer IDENTITY
            var userName = this.HttpContext.User.Identity.Name;

            var employer = dbContext.Employers.Include(e => e.AccountUser)
              .Include(e => e.Contact)
                                  .Include(e => e.Company)
                                  .Include(e => e.Vacancies).FirstOrDefault(x => x.AccountUser.UserName == userName);


            // ---------------- Company data ----------------------

            //var company = repoComp.GetAll().Include(c => c.Employers).ThenInclude(c => c.Vacancies)
            //                               .ThenInclude(c => c.Employer)
            //                                .FirstOrDefault(comp => comp.Id == employer.CompanyId);


            var city = dbContext.Cities.Include(i => i.Vacancies)
                      .Include(i => i.Companies)
                      .Include(i => i.Candidates).FirstOrDefault(c => c.Id == model.CityId);

            var fieldActivity = dbContext.FieldActivities.Include(f => f.Vacancies)
                                   .Include(f => f.Resumes).FirstOrDefault(x => x.Id == model.FieldActivityId);


            var employment = dbContext.Employments.Include(e => e.Vacancies)
                                             .FirstOrDefault(e => e.Vacancies.Select(i => i.Id == model.EmploymentId) != null);

            var expOfWork = dbContext.ExperienceOfWorks.Include(e => e.Vacancies).FirstOrDefault(ex => ex.Id == model.ExperienceOfWorkId);

            var newVacancy = new Vacancy();

            newVacancy.Id = Guid.NewGuid();
            newVacancy.Name = model.Name;

            newVacancy.Wage = model.Salary;
            newVacancy.DateCreate = DateTime.Now;

            // toDo DataPublication

            if (fieldActivity != null)
                newVacancy.FieldActivity = fieldActivity;

            if (employer != null)
                newVacancy.Employer = employer;

            if (city != null)
                newVacancy.City = city;
            if (employment != null)
                newVacancy.TypeEmployment = employment;
            if (expOfWork != null)
                newVacancy.ExperienceOfWork = expOfWork;

            newVacancy.Description = model.Description;
            newVacancy.Requirement = model.Requirement;
            newVacancy.Responsibilities = model.Responsibilitie;
            newVacancy.ForeignLanguages = model.ForeignLanguages;


            if (model.UseCompanyContact == false && model.UsePersonalContact == false)
            {
                newVacancy.EmailPerson = model.EmailContactPerson;
                newVacancy.PhoneNumberPerson = model.PhoneNumberContactPerson;
                newVacancy.ContactNamePerson = model.ContactPerson;
            }
            else if (model.UsePersonalContact == true)
            {
                newVacancy.ContactNamePerson = employer.Contact.Email;
                newVacancy.PhoneNumberPerson = employer.Contact.Phone;
                newVacancy.EmailPerson = employer.Contact.Email;

                newVacancy.IsUsePersonalContact = model.UsePersonalContact;
            }
            else if (model.UseCompanyContact == true)
            {

                newVacancy.ContactNamePerson = employer.Company.Email;
                newVacancy.PhoneNumberPerson = employer.Company.PhoneNumber;
                newVacancy.EmailPerson = employer.Company.Email;

                newVacancy.IsUseCompanyContact = model.UseCompanyContact;

            }

            newVacancy.Status = "Архів";

            dbContext.Vacancies.Add(newVacancy);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(EditVacancy), new { vacancyId = newVacancy.Id });
        }


        public ActionResult EditVacancy(Guid vacancyId)
        {

            var vacancy = dbContext.Vacancies.Include(v => v.Employer.AccountUser)
                                        .Include(v => v.FieldActivity).Include(v => v.Employer.Company)
                                        .Include(v => v.TypeEmployment)
                                        .Include(v => v.ExperienceOfWork)
                                        .Include(v => v.City)
                            .FirstOrDefault(v => v.Id == vacancyId);


            var cities = dbContext.Cities.Include(f => f.Vacancies).Select(city => new SelectListItem()
            {
                Value = city.Id.ToString(),
                Text = city.Name
            }).ToList();


            var fields = dbContext.FieldActivities.Include(f => f.Vacancies).Select(field => new SelectListItem()
            {
                Value = field.Id.ToString(),
                Text = field.Name
            }).ToList();

            var employments = dbContext.Employments.Include(f => f.Vacancies).Select(emp => new SelectListItem()
            {
                Value = emp.Id.ToString(),
                Text = emp.Name
            }).ToList();


            var experiencesOfWork = dbContext.ExperienceOfWorks.Include(e => e.Vacancies).Select(ex => new SelectListItem()
            {
                Value = ex.Id.ToString(),
                Text = ex.NameField
            }).ToList();


            var employer = vacancy.Employer;

            var model = new PageEditVacancyWhithResponseViewModel();

            model.Id = vacancy.Id;
            model.NameVacancy = vacancy.Name;
            model.Cities = cities;
            model.CityId = vacancy.CityId;

            model.FieldsActivity = fields;
            model.FieldId = vacancy.FieldActivityId;

            model.Employments = employments;
            model.EmploymentId = vacancy.TypeEmployment.Id;

            model.ExperiencesOfWork = experiencesOfWork;
            model.ExperienceOfWorkId = vacancy.ExperienceOfWork.Id;

            model.EmployerName = vacancy.Employer.AccountUser.Email;
            model.EmployerId = vacancy.Employer.Id;

            model.DateCreate = vacancy.DateCreate;

            model.DatePublication = vacancy.DatePublication;
            model.Status = vacancy.Status;

            model.Description = vacancy.Description;
            model.Requirement = vacancy.Requirement;
            model.Responsibilities = vacancy.Responsibilities;
            model.ForeignLanguages = vacancy.ForeignLanguages;
            model.AdditionalRequirements = vacancy.AdditionalRequirements;


            if (vacancy.IsUseCompanyContact || vacancy.IsUsePersonalContact)
            {
                model.PhoneNumber = vacancy.Employer?.Company?.PhoneNumber;
                model.Email = vacancy.Employer?.Company?.Email;
            }
            else
            {
                model.ContactPerson = vacancy.ContactNamePerson;
                model.PhoneNumber = vacancy.PhoneNumberPerson;
                model.Email = vacancy.EmailPerson;
            }


            // }


            return View("/Arrea/Employer/Views/Employee/EditVacancyWhithResponse.cshtml", model);
        }

        [HttpPost]
        public ActionResult EditVacancy(PageEditVacancyWhithResponseViewModel model)
        {

            Vacancy updateVacancy = dbContext.Vacancies.Include(v => v.Employer.AccountUser)
              .Include(v => v.Employer.Company)
              .Include(v => v.City)
              .Include(i => i.TypeEmployment)
              .Include(i => i.ExperienceOfWork)
                                                .FirstOrDefault(i => i.Id == model.Id);

            updateVacancy.Name = model.NameVacancy;


            // --------------------------------- City  ----------------------------
            var newCity = dbContext.Cities.Include(i => i.Vacancies).ThenInclude(i => i.City)
                                            .Include(i => i.Companies).ThenInclude(i => i.City)
                                            .FirstOrDefault(city => city.Id == model.CityId);

            updateVacancy.City = newCity;

            // --------------------------------- FieldActivity  ----------------------------
            var field = dbContext.FieldActivities.Include(i => i.Vacancies)
                                          .FirstOrDefault(f => f.Id == model.FieldId);


            updateVacancy.FieldActivity = field;

            // --------------------------------- Employments  ---------------------------

            var typeEmployment = dbContext.Employments.Include(e => e.Vacancies)
                             .FirstOrDefault(emp => emp.Id == model.EmploymentId);

            updateVacancy.TypeEmployment = typeEmployment;

            // --------------------------------- ExperianceOfWork  ---------------------------

            var experience = dbContext.ExperienceOfWorks.Include(e => e.Vacancies)
                .FirstOrDefault(e => e.Id == model.ExperienceOfWorkId);

            updateVacancy.ExperienceOfWork = experience;

            if (updateVacancy.Status == "Архів" && model.IsPublication == true)
            {
                updateVacancy.Status = "Опублікована";
                updateVacancy.IsActive = true;
            }
            else if (updateVacancy.Status == "Опублікована" && model.IsPublication == true)
            {
                updateVacancy.Status = "Архів";
                updateVacancy.IsActive = false;
            }


            updateVacancy.Description = model.Description;
            updateVacancy.Requirement = model.Requirement;
            updateVacancy.Responsibilities = model.Responsibilities;
            updateVacancy.ForeignLanguages = model.ForeignLanguages;
            updateVacancy.AdditionalRequirements = model.AdditionalRequirements;


            updateVacancy.IsUseCompanyContact = model.UseCompanyContact;
            updateVacancy.IsUsePersonalContact = model.UsePersonalContact;

            //// todo model.Status

            if (model.UseCompanyContact)
            {

                updateVacancy.EmailPerson = updateVacancy.Employer.Company.Email;
                updateVacancy.PhoneNumberPerson = updateVacancy.Employer.Company.PhoneNumber;

                updateVacancy.ContactNamePerson = updateVacancy.Employer.Company.Email;

                updateVacancy.IsUseCompanyContact = true;
            }
            else if (model.UsePersonalContact)
            {
                updateVacancy.EmailPerson = updateVacancy.Employer.Contact.Email;
                updateVacancy.PhoneNumberPerson = updateVacancy.Employer.Contact.Phone;

                updateVacancy.ContactNamePerson = updateVacancy.Employer.Contact.Email;

                updateVacancy.IsUsePersonalContact = true;
            }
            else
            {
                updateVacancy.EmailPerson = model.Email;
                updateVacancy.PhoneNumberPerson = model.PhoneNumber;
                updateVacancy.ContactNamePerson = model.ContactPerson;

            }



            dbContext.Vacancies.Update(updateVacancy);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(EditVacancy), new { vacancyId = updateVacancy.Id });
        }


        public ActionResult EditDatePublicationSubmit(Guid vacancyId)
        {
            Vacancy updateVacancy = dbContext.Vacancies.Include(v => v.Employer.AccountUser)
              .Include(v => v.Employer.Company)
              .Include(v => v.City)
              .Include(i => i.TypeEmployment)
              .Include(i => i.ExperienceOfWork)
                                                .FirstOrDefault(i => i.Id == vacancyId);

            updateVacancy.DatePublication = DateTime.Now;


            dbContext.Vacancies.Update(updateVacancy);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(EmploeeVacancies));//), new { vacancyId = updateVacancy.Id });
        }

        //public ActionResult EditStatusSubmit(PageEditVacancyWhithResponseViewModel model)
        //{

        //  Vacancy updateVacancy = dbContext.Vacancies.Include(v => v.Employer.AccountUser)
        //    .Include(v => v.Employer.Company)
        //    .Include(v => v.City)
        //    .Include(i => i.TypeEmployment)
        //    .Include(i => i.ExperienceOfWork)
        //                                      .FirstOrDefault(i => i.Id == model.Id);

        //  updateVacancy.Status = model.Status;
        //  dbContext.Vacancies.Update(updateVacancy);
        //  dbContext.SaveChanges();

        //  return RedirectToAction(nameof(EditVacancy), new { vacancyId = updateVacancy.Id });
        //}

        public ActionResult ResponsesToVacancy(Guid vacancyId)
        {


            var vacancy = dbContext.Vacancies.Include(v => v.Employer.AccountUser)
                                      .Include(v => v.FieldActivity).Include(v => v.Employer.Company)
                                      .Include(v => v.TypeEmployment)
                                      .Include(v => v.ExperienceOfWork)
                                      .FirstOrDefault(v => v.Id == vacancyId);


            var vacancyName = vacancy.Name;

            var allresume = dbContext.Resumes.Include(resum => resum.Responses).ThenInclude(res => res.Vacancy)
              .Where(i => i.Responses.FirstOrDefault(x => x.Vacancy.Id == vacancyId )!= null);
              

            var resumesResponseToVacancy = new List<ResumesResponseToVacancyViewModel>();

            resumesResponseToVacancy.AddRange(allresume.Select(res => new ResumesResponseToVacancyViewModel()
            {

                // toDo isCheced
                //IsCheced = 
                // toDo ActionWhithFavorite
                //ActionWhithFavorite = 
                Id = res.Id,
                NameResume = res.Name,
                Salary = res.Salary,
                Birthday = res.Candidate.Birthday,
                Cities = new List<CityNameViewModel>() { new CityNameViewModel()
                {
                    CityName =res.Candidate == null ? "" : res.Candidate.City.Name
                }},

                FotoUrl = res.Candidate == null ? "" : res.Candidate.Avatar,
                //toDo VideoUrl
                //VideoUrl =
                LinkPageResum = Url.Action("AboutResume", "Resume", new { resumeId = res.Id, Area = "" }),
                //ToDo LinkFavorites Resume
                //ChekedFavorites = 
                Date = res.Responses.Select(r => r.DataResponse).FirstOrDefault(), 
                StatusId = res.Responses.Where(r => r.ResumeId == res.Id && r.VacancyId == vacancyId).Select(r => r.ResponseType.Id).FirstOrDefault()
            }));

            var model = new PageResumeViewModel()
            {
                VacancyId = vacancy.Id,
                VacancyName = vacancyName,
                Resumes = resumesResponseToVacancy
            };
            return View("/Arrea/Employer/Views/Employee/ResponsesToVacancy.cshtml", model);
        }



    }
}
