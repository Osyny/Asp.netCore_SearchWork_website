using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Search_Work.Arrea.Candidate.Models;
using Search_Work.Data;
using Search_Work.Models;
using Search_Work.Models.ArreaDatabase.Resumes;
using Search_Work.Models.Pagination;
using Search_Work.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Controllers.Arrea.Candidate.Controllers
{
    public class ResumeController : Controller
    {
        private readonly oxana1404 db;
        private readonly UserManager<ApplicationUser> _userManager;
        private IHostingEnvironment _environment;

        public ResumeController(oxana1404 db, UserManager<ApplicationUser> userManager, IHostingEnvironment environment)
        {
            this.db = db;
            this._userManager = userManager;
            _environment = environment;
        }

        public ActionResult Index(Guid? candidateId, string dateFilter = null, int currentPage = 1)
        {
            // IDENTITY USER NAME  HttpContext
            var userName = HttpContext.User.Identity.Name;

            var user = _userManager.Users.FirstOrDefault(i => i.Email == userName);
            var userId = user.Id;



            var allResume = db.Resumes.Include(x => x.ViewsPage)
                                      .Include(i => i.ShowsResume)
                                      .Include(r => r.Candidate).ThenInclude(c => c.AccountUser)
                                      .Include(c => c.Candidate).ThenInclude(c => c.City)
                                      .Where(resume => resume.Candidate.AccountUser.UserName == userName);
            var cand = db.Candidates.Include(r => r.AccountUser).Where(c => c.AccountUser.UserName == user.UserName);
            //  var cand2 = db.Candidates.Where(c => c.AccountUser.Email == User.AddIdentity. && c.AccountUser.UserName == userName);
            const int skipCount = 5;
            Decimal decResumes = allResume.Count();
            Decimal decCountPages = Math.Ceiling(decResumes / skipCount);

            int countPages = Decimal.ToInt32(decCountPages);
            int resumes = Decimal.ToInt32(decResumes);

            if (currentPage > countPages)
            {
                currentPage = 1;
            }

            var resumesCandidate = new List<PageResumeCandidateViewModel>();

            resumesCandidate.AddRange(allResume.OrderBy(r => r.Name)
                .Skip(skipCount * currentPage - skipCount)
                .Take(skipCount)
                .Select(resume => new PageResumeCandidateViewModel()
                {
                    Id = resume.Id,

                    NameResum = resume.Name,
                    Wage = resume.Salary,
                    City = resume.Candidate.City.Name,
              //toDo Comment for resum
              Comment = "Доробити...",
              //todo DatePublicate
              DatePublication = DateTime.Now,

                    DateChange = resume.DateChange,
                    CountShow = resume.ShowsResume.Count,
                    CountView = resume.ViewsPage.Count,
                    Status = resume.IsActiveResume,




                }));


            var paginationViewModel = new CataloguePaginationViewModel()
            {
                CurrentPage = currentPage,
                DisplayOnPage = skipCount,
                TotalCount = countPages,
                ActionName = "Index",
                ControllerName = "Resume",
                ObjectParameter = new Dictionary<string, string>
                {
                    {
                        "userId", userId.ToString()
                    }
                }
            };

            var model = new CandidateResumesViewModel()
            {
                //UserId = userId,
                UserName = userName,
                Resumes = resumesCandidate,
                Pagination = paginationViewModel,
                CurentPage = currentPage,
                // CandidatId = userId

            };
            return View("/Arrea/Candidate/Views/Index.cshtml", model);
        }

      

        public ActionResult Edit(Guid resumeId)
        {
            // IDENTITY USER NAME  HttpContext
            var userName = HttpContext.User.Identity.Name;

            var candidate = db.Candidates.Include(i => i.FamilyStatus)
              .Include(i => i.Children)
              .Include(i => i.Resumes)
              .Include(i => i.AccountUser)
              .FirstOrDefault(x => x.AccountUser.UserName == userName);

            // ------------------------------------------------------------------------------


            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                .Include(r => r.Candidate).ThenInclude(r => r.City)
                .Include(r => r.Candidate).ThenInclude(r => r.FamilyStatus)
                .Include(r => r.Candidate).ThenInclude(r => r.Children)
                .Include(r => r.FieldActivities).ThenInclude(f => f.FieldActivity)
                .Include(r => r.Educations).ThenInclude(r => r.LevelEducation)
                .Include(r => r.Educations).ThenInclude(r => r.FormTraining)
                .Include(r => r.Experiences).ThenInclude(r => r.Employment)
                .Include(r => r.ImplementedProjects)
                .Include(r => r.SoftWares).ThenInclude(r => r.LevelTechnologyPossession)
                .Include(r => r.Awards)
                .Include(r => r.ForeignLanguages).ThenInclude(r => r.LevelLanguage)
                .Include(r => r.TrainingAndCources)
                .Include(r => r.AditinalInfo)
                .Include(r => r.Publications).Include(i => i.ImplementedProjects)
                .FirstOrDefault(i => i.Id == resumeId);



            var childrens = db.Childrens.Include(c => c.Candidates).Select(field => new SelectListItem()
            {
                Value = field.Id.ToString(),
                Text = field.Name
            }).ToList();


            var children = db.Childrens.Include(i => i.Candidates).ThenInclude(i => i.Children)
                                              .FirstOrDefault(f => f.Candidates.Select(i => i.Id == candidate.Id) != null);

            var familyStatuses = db.FamilyStatuses.Include(f => f.Candidates).ThenInclude(f => f.FamilyStatus)
                                           .Include(f => f.Candidates).ThenInclude(f => f.Resumes).Select(f => new SelectListItem()
                                           {
                                               Value = f.Id.ToString(),
                                               Text = f.Name

                                           }).ToList();
            var familyStatuse = resume.Candidate.FamilyStatus; //familyRepo.GetByCandidateId(candidate.Id);

            var fieldsActivity = db.FieldActivities.Include(f => f.Resumes)
                                          .ThenInclude(f => f.Resume.Candidate).Select(field => new FieldActivityViewModel()
                                          {
                                              Name = field.Name,
                                              Id = field.Id

                                          }).ToList();

            // ---------------------------------- Our FieldActivity   ------------------------------------

            var fieldSelect = resume.FieldActivities.Select(res => new FieldActivityViewModel()
            {
                Id = res.FieldActivity.Id,
                Name = res.FieldActivity?.Name

            }).ToList();

            // ----------------------- Education ------------------------------------

            var levelsEducation = db.LevelEducations
                                               .Include(i => i.Educations).ThenInclude(i => i.Resume.Candidate).Select(level => new SelectListItem()
                                               {
                                                   Value = level.Id.ToString(),
                                                   Text = level.Name

                                               }).ToList();



            PageEditResumeViewModel model = new PageEditResumeViewModel()
            {
                ResumeName = resume.Name,
                Id = resumeId,
                FieldsActivityAll = fieldsActivity,
                FieldsActivitySelect = fieldSelect,

                Childrens = childrens,
                ChildrenId = children != null ? children.Id : Guid.Empty,
                ChildrenName = children != null ? children.Name : "",

                FamilyStatuses = familyStatuses,
                FamilyStatusId = familyStatuse != null ? familyStatuse.Id : Guid.Empty,
                FamilyStatusName = familyStatuse != null ? familyStatuse.Name : "",


                CandidateId = resume.Candidate.Id,
                CandidateName = resume.Candidate.Name,



                LastName = resume.Candidate.LastName,
                Surname = resume.Candidate.Surname,
                Sex = resume.Candidate.Sex,
                Birthday = resume.Candidate.Birthday,
                Phone = resume.Candidate.PhoneNumber,
                ////todo Foto
                FotoUrl = resume.Foto,
                Email = resume.Candidate.Email,
                Fasebook = resume.Candidate.Facebook,
              //  Linkedin = candidate.Linkedin,
                Skype = resume.Candidate.Skype,

                Country = resume.Candidate.Country,
                Region = resume.Candidate.Region,
                CityResident = resume.Candidate.City?.Name,
                Street = resume.Candidate.Street,
                ApartmentNumber = resume.Candidate.ApartmentNumber,

                IsActiveResume = resume.IsActiveResume,
                IsAnonymousResume = resume.IsAnonymousResume,
                IsHideContact = resume.IsHideContact,


                Experiences = resume.Experiences?.Select(ex => new ExperienceEditViewModel()
                {

                    Id = ex.Id,
                    NameCompany = ex.NameOrganization,
                    DateWorkFrom = ex.DateWorkFrom,
                    DateWorkTo = ex.DateWorkTo,

                    IsWorkingNow = ex.IsWorkingNow,

                    Employments = db.Employments.Include(i => i.Experiences).ThenInclude(i => i.Resume.Candidate)
                        .Select(emp => new SelectListItem()
                        {
                            Value = emp.Id.ToString(),
                            Text = emp.Name,

                        }).ToList(),

                    EmploymentId = ex.Employment != null ? ex.Employment.Id : Guid.Empty,

                    Position = ex.Position,
                    Task = ex.Task,
                    Progres = ex.Progres

                }).ToList(),

                Educations = resume.Educations?.Select(e => new EducationEditViewModel()
                {
                    Id = e.Id,
                    LevelsEducation = db.LevelEducations
                        .Include(i => i.Educations).ThenInclude(i => i.Resume.Candidate).Select(level => new SelectListItem()
                        {
                            Value = level.Id.ToString(),
                            Text = level.Name

                        }).ToList(),

                    LevelEducationId = e.LevelEducation != null ? e.LevelEducation.Id : Guid.Empty,

                    City = e.City,
                    NameInstitution = e.NameInstitution,
                    Specialization = e.Specialization,

                    FormTrainings = db.FormTrainings
                        .Include(i => i.Educations).ThenInclude(ed => ed.Resume.Candidate).Select(field => new SelectListItem()
                        {
                            Value = field.Id.ToString(),
                            Text = field.Name,

                        }).ToList(),

                    FormTrainingId = e.FormTraining != null ? e.FormTraining.Id : Guid.Empty,

                    DateWorkFrom = e.DateWorkFrom,
                    DateWorkTo = e.DateWorkTo

                }).ToList(),

                ImplementedProjects = resume.ImplementedProjects?.Select(i => new ImplementedProjectViewModel()
                {
                    Id = i != null ? i.Id : Guid.Empty,
                    NameProgect = i.NameProgect,
                    DateWorkFrom = i.DateWorkFrom,
                    DateWorkTo = i.DateWorkTo,
                    LinkToProgect = i.LinkToProgect

                }).ToList(),

                ForeignLanguages = resume.ForeignLanguages?.Select(lenguage => new ForeignLanguageEditViewModel()
                {
                    Id = lenguage != null ? lenguage.Id : Guid.Empty,
                    Name = lenguage.Name,
                    LevelsLanguage = db.LevelLanguages
                        .Include(l => l.ForeignLanguages).ThenInclude(i => i.Resume.Candidate).Select(lev => new SelectListItem()
                        {
                            Value = lev.Id.ToString(),
                            Text = lev.Name
                        }).ToList(),

                    LevelLanguageId = lenguage.LevelLanguage != null ? lenguage.LevelLanguage.Id : Guid.Empty

                }).ToList(),

                TrainingAndCourses = resume.TrainingAndCources?.Select(course => new TrainingAndCourceViewMopdel()
                {
                    Id = course != null ? course.Id : Guid.Empty,
                    Name = course.Name,
                    DateFrom = course.DateFrom,
                    DateTo = course.DateTo,
                    NumberSertifikation = course.NumberCertification

                }).ToList(),

                Softwares = resume.SoftWares?.Select(soft => new SoftwareEditViewModel()
                {
                    Id = soft != null ? soft.Id : Guid.Empty,
                    Name = soft.Name,
                    LevelsSoftWare = db.LevelTechnologyPossessions
                                                .Include(lev => lev.SoftWares).ThenInclude(i => i.Resume.Candidate).Select(lev => new SelectListItem()
                                                {
                                                    Value = lev.Id.ToString(),
                                                    Text = lev.Name

                                                }).ToList(),

                    LevelSoftWareId = soft.LevelTechnologyPossession != null ? soft.LevelTechnologyPossession.Id : Guid.Empty
                }).ToList(),

                Awards = resume.Awards?.Select(award => new AwardViewModel()
                {
                    Id = award != null ? award.Id : Guid.Empty,
                    Name = award.Name != "" ? award.Name : "",
                    Date = award.Date,


                }).ToList(),

                Publications = resume.Publications?.Select(p => new PublicationViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Date = p.Date,
                    SiteEdition = p.SiteEdition

                }).ToList(),




                AditinalInfos = resume.AditinalInfo != null ? resume.AditinalInfo.Text : ""



            };


            //return View("/Arrea/Candidate/Views/EditResume.cshtml", model);
            return View("/Arrea/Candidate/Views/Resumes/EditResumeAdd.cshtml", model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PageEditResumeViewModel model, IFormFile Image)
        {


            Resume updateResume = db.Resumes.Include(r => r.Candidate.AccountUser)
                                                  .Include(r => r.Candidate.City)
                                                    .Include(r => r.Candidate.FamilyStatus)
                                                    .Include(r => r.Candidate.Children)
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
                .FirstOrDefault(r => r.Id == model.Id);

            updateResume.Name = model.ResumeName;

            updateResume.IsAnonymousResume = model.IsAnonymousResume;
            updateResume.IsHideContact = model.IsHideContact;
            updateResume.IsActiveResume = model.IsActiveResume;



            List<FieldActivity> fieldActivities = null;

            if (model.FieldIds != null)
            {

                foreach (var updateFildAct in updateResume.FieldActivities)
                {

                    foreach (var id in model.FieldIds)
                    {
                        var upFieldActiv = db.FieldActivities.Include(f => f.Vacancies)
                                             .Include(f => f.Resumes).FirstOrDefault(x => x.Id == id);


                        updateFildAct.FieldActivity = upFieldActiv;



                    }
                }
            }

            updateResume.Candidate.LastName = model.LastName;
            updateResume.Candidate.Name = model.CandidateName;
            updateResume.Candidate.Surname = model.Surname;

            if (Image != null)
            {
                string name = Image.FileName;
                string path = $"/files/{name}";
                string serverPath = $"{_environment.WebRootPath}{path}";
                FileStream fs = new FileStream(serverPath, FileMode.Create,
                    FileAccess.Write);
                await Image.CopyToAsync(fs);
                fs.Close();
                updateResume.Foto = path;
            }



            updateResume.Candidate.Sex = model.Sex;
            updateResume.Candidate.Birthday = model.Birthday;
            updateResume.Candidate.Email = model.Email;
            updateResume.Candidate.Facebook = model.Fasebook;
            updateResume.Candidate.Linkedin = model.Linkedin;
            updateResume.Candidate.Skype = model.Skype;

            updateResume.Candidate.Country = model.Country;
            updateResume.Candidate.Region = model.Region;
            updateResume.Candidate.City.Name = model.CityResident;
            updateResume.Candidate.Street = model.Street;
            updateResume.Candidate.ApartmentNumber = model.ApartmentNumber;


            var newChildren = db.Childrens.Include(c => c.Candidates)
                      .ThenInclude(can => can.Resumes).FirstOrDefault(c => c.Id == model.ChildrenId);
            updateResume.Candidate.Children = newChildren != null ? newChildren : null;
            //if (newChildren != null)
            //{
            //    updateResume.Candidate.Children = newChildren;
            //}

            // --------------------------------- FamilyStatus ----------------------------

            var newFamilyStatus = db.FamilyStatuses.Include(fam => fam.Candidates)
                                   .ThenInclude(can => can.Resumes).FirstOrDefault(f => f.Id == model.FamilyStatusId);
            updateResume.Candidate.FamilyStatus = newFamilyStatus != null ? newFamilyStatus : null;

            //if (newFamilyStatus != null)
            //{
            //    updateResume.Candidate.FamilyStatus = newFamilyStatus;
            //}

            // ---------------------------------Expirience----------------------------


            if (updateResume.Experiences != null)
            {
                if (model.Experiences != null)
                {
                    foreach (var modelExp in model.Experiences)
                    {
                        var updateExperience = updateResume.Experiences.FirstOrDefault(i => i.Id == modelExp.Id);

                        updateExperience.NameOrganization = modelExp.NameCompany;
                        updateExperience.DateWorkFrom = modelExp.DateWorkFrom;
                        updateExperience.DateWorkTo = modelExp.DateWorkTo;
                        updateExperience.IsWorkingNow = modelExp.IsWorkingNow;

                        // ------------- EMPLOYMENT --------------------------
                        var newEmpl = db.Employments.Include(emp => emp.Experiences).ThenInclude(exp => exp.Resume)
                                                      .FirstOrDefault(e => e.Id == modelExp.EmploymentId);
                        updateExperience.Employment = newEmpl != null ? newEmpl : null;


                        updateExperience.Position = modelExp.Position;

                        updateExperience.Task = modelExp.Task;
                        updateExperience.Progres = modelExp.Progres;

                    }
                }
            }
            // ---------------------------------  Education ----------------------------


            if (updateResume.Educations != null)
            {
                if (model.Educations != null)
                {
                    foreach (var modelEduc in model.Educations)
                    {
                        var updateEduc = updateResume.Educations.FirstOrDefault(e => e.Id == modelEduc.Id);


                        // ------------- LEVEL --------------------------
                        var newLevel = db.LevelEducations.Include(ed => ed.Educations).
                              ThenInclude(l => l.Resume).FirstOrDefault(l => l.Id == modelEduc.LevelEducationId);
                        updateEduc.LevelEducation = newLevel != null ? newLevel : null;

                        updateEduc.City = modelEduc.City;
                        updateEduc.NameInstitution = modelEduc.NameInstitution;
                        updateEduc.Specialization = modelEduc.Specialization;


                        // ------------- FORM_TRAINING  --------------------------
                        var newFormTrain = db.FormTrainings.Include(f => f.Educations).ThenInclude(ed => ed.Resume)
                          .FirstOrDefault(i => i.Id == modelEduc.FormTrainingId);
                        updateEduc.FormTraining = newFormTrain != null ? newFormTrain : null;
                    }
                }

            }

            // ---------------------------------  Implem progect ----------------------------

            if (updateResume.ImplementedProjects != null)
            {
                if (model.ImplementedProjects != null)
                {
                    foreach (var modelProg in model.ImplementedProjects)
                    {
                        var updateProg = updateResume.ImplementedProjects.FirstOrDefault(e => e.Id == modelProg.Id);

                        updateProg.NameProgect = modelProg.NameProgect;
                        updateProg.DateWorkFrom = modelProg.DateWorkFrom;
                        updateProg.DateWorkTo = modelProg.DateWorkTo;
                        updateProg.LinkToProgect = modelProg.LinkToProgect;
                    }
                }
            }



            // ---------------------------------  Lenguages ----------------------------

            if (updateResume.ForeignLanguages != null)
            {
                if (model.ForeignLanguages != null)
                {
                    foreach (var modelLen in model.ForeignLanguages)
                    {

                        var updateLenguage = updateResume.ForeignLanguages.FirstOrDefault(e => e.Id == modelLen.Id);

                        updateLenguage.Name = modelLen.Name;

                        // ------------- LEVEL --------------------------
                        var newLevel = db.LevelLanguages
                          .Include(ed => ed.ForeignLanguages).
                              ThenInclude(l => l.Resume).FirstOrDefault(l => l.Id == modelLen.LevelLanguageId);
                        updateLenguage.LevelLanguage = newLevel != null ? newLevel : null;
                    }
                }
            }


            //// ---------------------------------  Training and course ----------------------------
            if (updateResume.TrainingAndCources != null)
            {
                if (model.TrainingAndCourses != null)
                {
                    foreach (var modelCourse in model.TrainingAndCourses)
                    {
                        var updateCourse = updateResume.TrainingAndCources.FirstOrDefault(e => e.Id == modelCourse.Id);

                        updateCourse.Name = modelCourse.Name;
                        updateCourse.DateFrom = modelCourse.DateFrom;
                        updateCourse.DateTo = modelCourse.DateTo;
                        updateCourse.NumberCertification = modelCourse.NumberSertifikation;
                    }
                }
            }


            //// ---------------------------------  SoftWear ----------------------------

            // var repoLevSoft = new LevelTechnologyPossessionRepository(this.dbContext);

            if (updateResume.SoftWares != null)
            {
                if (model.Softwares != null)
                {
                    foreach (var modelSoftWere in model.Softwares)
                    {
                        var updateSoftWare = updateResume.SoftWares.FirstOrDefault(e => e.Id == modelSoftWere.Id);

                        updateSoftWare.Name = modelSoftWere.Name;

                        //--------------- ------------- LEVEL --------------------------
                        var newlevelSoft = db.LevelTechnologyPossessions
                              .Include(i => i.SoftWares).ThenInclude(i => i.Resume.Candidate).FirstOrDefault(l => l.Id == modelSoftWere.Id);
                        updateSoftWare.LevelTechnologyPossession = newlevelSoft != null ? newlevelSoft : null;

                    }
                }
            }


            //// ---------------------------------  Awards ----------------------------

            if (updateResume.Awards != null)
            {
                if (model.Awards != null)
                {
                    foreach (var modelAward in model.Awards)
                    {
                        var updateAward = updateResume.Awards.FirstOrDefault(e => e.Id == modelAward.Id);

                        updateAward.Name = modelAward.Name;
                        updateAward.Date = modelAward.Date;
                        updateAward.SiteUrlEdition = modelAward.SiteUrlEdition;

                    }
                }
            }

            //// ---------------------------------  Publication ----------------------------

            //if (model.Publications != null)
            //{
            //  foreach (var modelPublic in model.Publications)
            //  {
            //    var updatePublic = updateResume.Publications.FirstOrDefault(e => e.Id == modelPublic.Id);

            //    updatePublic.Name = modelPublic.Name;
            //    updatePublic.Date = modelPublic.Date;
            //    updatePublic.SiteEdition = modelPublic.SiteEdition;

            //  }
            //}

            //// ---------------------------------  Recomendation ----------------------------



            if (!string.IsNullOrEmpty(model.AditinalInfos))
            {
                if (updateResume.AditinalInfo == null)
                {
                    updateResume.AditinalInfo = new AditinalInfo()
                    {
                        Id = Guid.NewGuid(),
                        Text = model.AditinalInfos,
                        Resume = updateResume
                    };
                }
                else
                {
                    updateResume.AditinalInfo.Text = model.AditinalInfos;
                }
            }
            //else
            //{
            //    updateResume.AditinalInfo.Text = null;
            //}

            updateResume.DateChange = DateTime.Now;

            db.Resumes.Update(updateResume);
            db.SaveChanges();

            return RedirectToAction(nameof(Edit), new { resumeId = updateResume.Id });
        }

        // ----------------------------------- View Resume --------------------------
        public ActionResult ViewsResume(Guid resumeId)
        {


            var resume = db.Resumes.FirstOrDefault(x => x.Id == resumeId);


            var views = db.ViewsPages.Include(i => i.Employer).ThenInclude(i => i.Company)
                                         .Where(x => x.ResumeId == resumeId);

            //var viewsResume = repoView.GetById(resumeId);

            var viewsCount = views.Count();
            var viewList = new List<ViewPageViewModel>();

            viewList.AddRange(views.ToList().Select(view => new ViewPageViewModel()
            {
                Id = view.Resume.Id,
                Name = ViewerName(view),

                Date = view.DataView.ToString("dd/MM/yyyy")

            }));

            var model = new PageViewsListViewModel()
            {
                ResumeName = resume.Name,
                Views = viewList
            };
            return View("/Arrea/Candidate/Views/Resumes/ViewsResume.cshtml", model);
        }

        private string ViewerName(ViewPage view)
        {
            if (view.Employer == null)
                return "Гість";

            return view.Employer.Company.Name;

        }
    }
}
