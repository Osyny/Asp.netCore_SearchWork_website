using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Search_Work.Data;
using Search_Work.Helpers;
using Search_Work.Models.ArreaDatabase;
using Search_Work.Models.ArreaDatabase.Resumes;
using Search_Work.Models.Helper;
using Search_Work.Models.Pagination;
using Search_Work.Models.ViewModel.Candidate.Resumes;
using Search_Work.Models.ViewModel.Home.Resumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Controllers
{
    public class ResumeHomeController : Controller
    {

        private oxana1404 dbContext;

        public ResumeHomeController(oxana1404 dbContext)
        {
            this.dbContext = dbContext;
        }

        // -----------------------------------------------------------------------------------
        public ActionResult Index()
        {
            //return View("/Views/Shared/InDevelopment.cshtml", new PageInDevelopmentViewModel()
            //{
            //    Title = "Резюме"
            //});

            //Resume        

            var fieldsActivity = dbContext.FieldActivities.Include(f => f.Resumes).ToList();//.Include(i => i.Resumes).Include(y => y.Resumes.).ToList(); 

            var resumesByFieldActivity = new List<FieldActivityWhithViewModel>();
            resumesByFieldActivity.AddRange(fieldsActivity.Select(field => new FieldActivityWhithViewModel()
            {
                FieldActivityId = field.Id,
                FieldActivityName = field.Name,
                CountResumeByFieldActivity = field.Resumes.Count
            }));

            var model = new PageFieldWhithResumeViewModel()
            {
                ResumesByFieldActivity = resumesByFieldActivity,

            };
            return View("/Views/Home/HomeResume/Index.cshtml", model);
        }

        public ActionResult ResumeCatalogByActivityField(Guid fieldActivityId, string filterType = null, string dateFilter = null, int currentPage = 1)
        {
            //var resu
            //  var resumeRepo = new ResumeRepository(this.dbContext);


            var fieldActivity = dbContext.FieldActivities.Include(f => f.Vacancies)
                                   .Include(f => f.Resumes).FirstOrDefault(x => x.Id == fieldActivityId);

            var resumesFieldActivity = dbContext.Resumes
              .Include(r => r.Candidate)
              .Include(r => r.Candidate).ThenInclude(c => c.City)
              .Include(r => r.FieldActivities)
              .Include(r => r.Experiences).ThenInclude(e => e.Employment)
               .Where(resume => resume.FieldActivities.FirstOrDefault(i => i.FieldActivityId == fieldActivityId) != null).ToList();


            // --------------------------- count Pages -----------------------

            var resumesPageByFieldActivity = new List<PageResumeByFieldViewModel>();

            int skipCount = 6;

            IEnumerable<Resume> resumes = null;

            if (dateFilter != null)
            {
                switch (dateFilter)
                {
                    case FieldsMonth.YearId:
                        resumes = resumesFieldActivity.Where(v => v.DateCreate > DateTime.Now.AddYears(-1) && v.DateCreate < DateTime.Now);
                        break;
                    case FieldsMonth.MonthId:
                        resumes = resumesFieldActivity.Where(v => v.DateCreate > DateTime.Now.AddMonths(-1) && v.DateCreate < DateTime.Now);
                        break;
                    case FieldsMonth.WeеkId:
                        resumes = resumesFieldActivity.Where(v => v.DateCreate > DateTime.Now.AddDays(-7) && v.DateCreate < DateTime.Now);
                        break;
                    case FieldsMonth.DayId:
                        resumes = resumesFieldActivity.Where(v => v.DateCreate > DateTime.Now.AddDays(-2) && v.DateCreate < DateTime.Now);
                        break;
                    default:
                        break;

                }
            }

            if (filterType != null)
            {
                switch (filterType)
                {
                    case TypesSortResume.SalaryId:
                        resumes = resumesFieldActivity.OrderBy(r => r.Salary);
                        break;
                    case TypesSortResume.DataId:
                        resumes = resumesFieldActivity.OrderBy(r => r.DateCreate);
                        break;
                }

            }
            else
            {
                resumes = resumesFieldActivity;
            }

            //int countResume = resumesFieldActivity.Count();
            //int countPages = countResume / skipCount;

            Decimal countResume = resumesFieldActivity.Count();

            Decimal decCountPage = Math.Ceiling(countResume / skipCount);

            int countPages = Decimal.ToInt32(decCountPage);



            if (currentPage > countPages)
            {
                currentPage = 1;
            }

            resumes = resumes.Skip(skipCount * currentPage - skipCount).Take(skipCount);

            resumesPageByFieldActivity.AddRange(resumes.ToList()
                .Select(resume => new PageResumeByFieldViewModel()
                {
                    Id = resume.Id,
                    Name = resume.Name,
                    Salary = resume.Salary,
                    DateCreate = resume.DateCreate,
              //toDo Foto 
              //FotoUrl = 
              Birthday = resume.Candidate.Birthday,

                    Cities = new List<CityViewModel>() { new CityViewModel()
                    {
                        CityName = resume.Candidate?.City?.Name
                    }},

                    TypeEmployment = resume.Experiences?.Select(ex => ex.Employment).FirstOrDefault(),
                    Description = resume.Description,

                    LinkPageResum = Url.Action("AboutResume", "ResumeHome", new { resumeId = resume.Id })

                }));

            var model = new PageCatalogResumeByFieldViewModel()
            {
                FieldId = fieldActivityId,
                FialdActivityName = fieldActivity.Name,
                ResumesByField = resumesPageByFieldActivity,
                CountResumeByFieldActivity = Decimal.ToInt32(countResume),

                Pagination = new CataloguePaginationViewModel()
                {
                    CurrentPage = currentPage,
                    DisplayOnPage = skipCount,
                    TotalCount = countPages,
                    ActionName = "ResumeCatalogByActivityField",
                    ControllerName = "ResumeHome",
                    ObjectParameter = new Dictionary<string, string> {
                    {
                        "fieldActivityId", fieldActivityId.ToString()
                    }}
                },

                SelectedFilter = dateFilter,
                TypeSortFilter = filterType
            };
            return View("/Views/Home/HomeResume/CatalogResumeByField.cshtml", model);
        }

        public ActionResult AboutResume(Guid resumeId, Guid? vacancyId)
        {

            var resume = dbContext.Resumes.Include(r => r.Candidate).ThenInclude(c => c.AccountUser)
                                      .Include(r => r.Candidate).ThenInclude(c => c.City)
                                      .Include(r => r.FieldActivities)
                                      .Include(r => r.Educations).ThenInclude(r => r.LevelEducation)
                                      .Include(r => r.Educations).ThenInclude(r => r.FormTraining)
                                      .Include(r => r.Experiences).ThenInclude(r => r.Employment)
                                      .Include(r => r.ImplementedProjects)
                                      .Include(r => r.SoftWares).ThenInclude(r => r.LevelTechnologyPossession)
                                      .Include(r => r.Awards)
                                      .Include(r => r.ForeignLanguages).ThenInclude(r => r.LevelLanguage)
                                      .Include(r => r.TrainingAndCources)
                                      .Include(r => r.AditinalInfo)
                                      .Include(r => r.Publications)
                      .FirstOrDefault(x => x.Id == resumeId);



            var candidateName = $"{ resume.Candidate.Surname } { resume.Candidate.Name } { resume.Candidate.LastName }";

            // Similar resume
            var resumes = dbContext.Resumes.Include(r => r.Candidate).ThenInclude(c => c.AccountUser)
              .Include(r => r.Candidate)
                                      .Include(r => r.Candidate).ThenInclude(c => c.City)
                                      .Include(r => r.Experiences).ToList();
            dbContext.Employments.Load();

            // -------------------------------------------------- View -------------------------


            //var repoViewRes = new ViewPageRepository(this.dbContext);
            //var emplRepo = new EmployerRepository(this.dbContext);


            Employer emp = HttpContext.User != null ? dbContext.Employers.Include(e => e.AccountUser)
                                    .Include(e => e.Company)
                                    .Include(e => e.Vacancies).FirstOrDefault(x => x.AccountUser.UserName == HttpContext.User.Identity.Name) : null;



            ViewPage viewResume = new ViewPage();

            viewResume.Id = Guid.NewGuid();
            viewResume.Resume = resume;
            viewResume.DataView = DateTime.Now;
            viewResume.Employer = emp;

            dbContext.ViewsPages.Add(viewResume);
            dbContext.SaveChanges();






            var similarResumes = new List<SimilarResumeViewModel>();

            similarResumes.AddRange(resumes.Take(6).Select(resum => new SimilarResumeViewModel()
            {
                ResumeName = resum.Name,
                Salary = resum.Salary,
                Birthday = resum.Candidate.Birthday,
                CityName = resum.Candidate.City?.Name,
                TypeEmployment = resum.Experiences.Select(ex => ex.Employment).FirstOrDefault(),

                Link = Url.Action("AboutResume", "ResumeHome", new { resumeId = resume.Id }),

            }));


            string fam = resume.Candidate?.FamilyStatus?.Name;

            // var repoLevel = new LevelEducationRepository(this.dbContext);

            PageAboutResumeViewModel model = new PageAboutResumeViewModel();


            model.NameCanditate = candidateName;
            model.DataCriate = resume.DateCreate;

            model.CityName = resume.Candidate.City?.Name;

            model.IsAnonimus = resume.IsAnonymousResume;

            model.ResumeName = resume.Name;
            model.ResumeId = resumeId;
            model.VacancyId = vacancyId;

            if(emp != null)
            {
                model.EmpViewId = emp.Id;
            }
            

            model.Foto = resume.Foto;

            model.Wage = resume.Salary;


            //if (resume.IsAnonymousResume)
            //{
            //  // Todo resume.IsAnonymousResume
            //}
            //else if (resume.IsHideContact)
            //{
            //  // Todo resume.IsHideContact
            //}

            model.Birthday = resume.Candidate.Birthday;



            model.FamilyStatus = resume.Candidate?.FamilyStatus?.Name;
            model.Children = resume.Candidate?.Children?.Name;

            model.PhoneNumber = resume.Candidate.PhoneNumber;
            model.Email = resume.Candidate.Email;
            model.Linkedin = resume.Candidate.Linkedin;
            model.Fasebook = resume.Candidate.Facebook;
            model.Skype = resume.Candidate.Skype;



            model.Educations = resume.Educations?.Select(e => new EducationViewModel()
            {
                LevelEducation = e.LevelEducation,
                NameInstitution = e.NameInstitution,
                Specialization = e.Specialization,
                DateWorkFrom = e.DateWorkFrom,
                DateWorkTo = e.DateWorkTo
            }).ToList();

            model.Experiences = resume.Experiences?.Select(i => new ExperienceViewModel()
            {
                NameCompany = i.NameOrganization,
                DateWorkFrom = i.DateWorkFrom,
                DateWorkTo = i.DateWorkTo,
                Position = i.Position,
                Task = i.Task,
                Progres = i.Progres
            }).ToList();

            model.ImplementProjects = resume.ImplementedProjects?.Select(proj => new ImplementedProjectViewModel()
            {
                NameProgect = proj.NameProgect,
                DateWorkFrom = proj.DateWorkFrom,
                DateWorkTo = proj.DateWorkTo,
                LinkToProgect = proj.LinkToProgect

            }).ToList();



            model.TrainingAndCources = resume.TrainingAndCources?.Select(сourse => new TrainingAndCourceViewMopdel()
            {
                Name = сourse.Name,
                DateFrom = сourse.DateFrom,
                DateTo = сourse.DateTo,

            }).ToList();

            model.Awards = resume.Awards.Select(award => new AwardViewModel()
            {
                Name = award.Name,
                Date = award.Date
            }).ToList();

            model.Publications = resume.Publications.Select(p => new PublicationViewModel()
            {
                Name = p.Name,
                Date = p.Date
            }).ToList();

            model.Softwares = resume.SoftWares.Select(soft => new SoftwareViewModel()
            {
                Name = soft.Name,
                LevelSoftWare = soft.LevelTechnologyPossession.Name

            }).ToList();
            model.ForeignLanguages = resume.ForeignLanguages.Select(len => new ForeignLanguageViewModel()
            {
                Name = len.Name,
                LevelLanguage = len.LevelLanguage.Name

            }).ToList();

            model.SimilarResume = similarResumes;



            return View("/Views/Home/HomeResume/PageAboutResume.cshtml", model);
        }


        // Todo saveResume click on button in AboutResume
        public ActionResult SaveResumeSubmit(Guid resumeId)
        {

            // Identity User
            var userIdentity = HttpContext.User.Identity.Name;

            var user = dbContext.ApplicationUsers
              .Include(u => u.Employer).FirstOrDefault(u => u.Email == userIdentity);




            var resume = dbContext.Resumes.Include(r => r.Candidate.AccountUser)
                                            .Include(r => r.Candidate.Resumes)
                                             .Include(r => r.Candidate.AccountUser.Employer.Vacancies)
                                           .FirstOrDefault(r => r.Id == resumeId);


            if (user?.Employer != null)
            {
                SavedResume newSavedResume = new SavedResume();

                newSavedResume.Id = Guid.NewGuid();
                newSavedResume.Resume = resume;
                newSavedResume.Employer = user.Employer;
                newSavedResume.DateSaved = DateTime.Now;

                dbContext.SavedResumes.Add(newSavedResume);
                dbContext.SaveChanges();
            }

            var res = new ResultStatusHelper(true)
            {
                Message = $"Resume сохранено",
            };
            return Ok(res);
        }

        // todo ResponseToResumeSubmit click on button in AboutResume 
        public ActionResult ResponseToResumeSubmit(Guid resumeId, Guid VacancyId)
        {
            // Identity User
            var userIdentity = HttpContext.User.Identity.Name;

            var user = dbContext.ApplicationUsers
                .Include(u => u.Employer).FirstOrDefault(u => u.Email == userIdentity);

            var resume = dbContext.Resumes.Include(r => r.Candidate.AccountUser)
                                            .Include(r => r.Candidate.Resumes)
                                            .Include(r => r.Candidate.AccountUser.Employer.Vacancies)
                                            .FirstOrDefault(r => r.Id == resumeId);

            var candidate = dbContext.Candidates.Include(c => c.Resumes)
                                        .FirstOrDefault(c => c.Resumes.Where(r => r.Id == resumeId) != null);


            if (user.Employer != null)
            {
                ResponseToResume newResponseToResume = new ResponseToResume();

                newResponseToResume.Id = Guid.NewGuid();
                newResponseToResume.Resume = resume;

                // todo ?????????   ++ Vacancy 
                var vac = dbContext.Vacancies.FirstOrDefault(v => v.Id == VacancyId);
                newResponseToResume.Vacancy = vac;

                newResponseToResume.DataResponse = DateTime.Now;

                dbContext.ResponsesToResume.Add(newResponseToResume);
                dbContext.SaveChanges();

            }

            var res = new ResultStatusHelper(true)
            {
                Message = $"Отклик добавлен ",
            };
            return Ok(res);
        }

        // Відмовити резюме
        public ActionResult RefuseToResume(Guid resumeId, Guid respTypeId)
        {
            //var resume = dbContext.Resumes.Include(r => r.Candidate.AccountUser)
            //                              .Include(r => r.Candidate.Resumes)
            //                              .Include(r => r.Candidate.AccountUser.Employer.Vacancies)
            //                              .Include(r => r.Responses).ThenInclude(r => r.Vacancy)
            //                              .Include(r => r.Responses).ThenInclude(r => r.ResponseType)
            //                              .FirstOrDefault(r => r.Id == resumeId);

            var respType = dbContext.ResponsesType.FirstOrDefault(i => i.Id == respTypeId);

            //var respToVacancyUpdate = dbContext.ResponsesToResume
            //    .FirstOrDefault(i => i.ResumeId == resumeId);
            var respToVacancyUpdate = dbContext.ResponsesToVacancy
                .Include(r => r.Resume).Include(r => r.Vacancy)
               .FirstOrDefault(i => i.ResumeId == resumeId);

            respToVacancyUpdate.ResponseType = respType;

            dbContext.ResponsesToVacancy.Update(respToVacancyUpdate);
            dbContext.SaveChanges();

            return RedirectToAction("EmploeeVacancies", "Vacancy", new { });
        }


    }
}

