using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Search_Work.Arrea.Candidate.Models.Resume;
using Search_Work.Data;
using Search_Work.Models;
using Search_Work.Models.ArreaDatabase.Resumes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Candidate.Controllers
{
    public class EditResumeController : Controller
    {
        private readonly oxana1404 db;

        private IHostingEnvironment _environment;

        public EditResumeController(oxana1404 db, IHostingEnvironment environment)
        {
            this.db = db;
            //this._userManager = userManager;
            _environment = environment;
        }

        // Сфера діяльності
        public ActionResult AddFieldActivitiy(Guid resumeId)
        {
            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                        .Include(r => r.FieldActivities)
                       .FirstOrDefault(i => i.Id == resumeId);

            var model = new AddResumeFieldActivitiesViewModel()
            {
                Resume = resume,

            };

            model.FieldActivities = db.FieldActivities.Include(f => f.Resumes)
                                                        .Select(e => new SelectListItem()
                                                        {
                                                            Value = e.Id.ToString(),
                                                            Text = e.Name
                                                        }).ToList();


            return View("/Arrea/Candidate/Views/Resumes/EditResume/AddFieldActivities.cshtml", model);

        }

        [HttpPost]
        public ActionResult AddFieldActivitiy(AddResumeFieldActivitiesViewModel model)
        {
            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                        .Include(r => r.FieldActivities).ThenInclude(r => r.FieldActivity)
                       .FirstOrDefault(i => i.Id == model.ResumeId);

            var fieldActivity = db.FieldActivities.FirstOrDefault(e => e.Id == model.FieldActivityId);

            var newFieldActivity = new FieldActivityResume()
            {
                Id = Guid.NewGuid(),
                Resume = resume,
                FieldActivity = fieldActivity,
                
            };
            resume.DateChange = DateTime.Now;
            // newExp.EmploymentId = employment.Id;


            resume.FieldActivities.Add(newFieldActivity);
            db.Update(resume);
            db.SaveChanges();

            return RedirectToAction("Edit", "Resume", new { resumeId = model.ResumeId });
        }

        // Досвід роботи 
        public ActionResult AddExperiences(Guid resumeId)
        {
            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                        .Include(r => r.Experiences).ThenInclude(r => r.Employment)
                       .FirstOrDefault(i => i.Id == resumeId);



            var model = new AddResumeExpiriensViewModel()
            {
                Resume = resume,

            };
            model.Employments = db.Employments.Include(e => e.Experiences)
                                                        .ThenInclude(f => f.Resume).Select(e => new SelectListItem()
                                                        {
                                                            Value = e.Id.ToString(),
                                                            Text = e.Name
                                                        }).ToList();

            return View("/Arrea/Candidate/Views/Resumes/EditResume/AddExperiences.cshtml", model);
        }

        [HttpPost]
        public ActionResult AddExperiences(AddResumeExpiriensViewModel model)
        {
            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                        .Include(r => r.Experiences).ThenInclude(r => r.Employment)
                       .FirstOrDefault(i => i.Id == model.ResumeId);

            var employment = db.Employments.FirstOrDefault(e => e.Id == model.EmploymentId);

            var newExp = new Experience()
            {
                Id = Guid.NewGuid(),
                Resume = resume,
                DateWorkFrom = model.DateWorkFrom,
                DateWorkTo = model.DateWorkTo,
                IsWorkingNow = model.IsWorkingNow,

                Employment = employment,
                Position = model.Position,
                Task = model.Task,
                Progres = model.Progres

            };

            resume.DateChange = DateTime.Now;


            resume.Experiences.Add(newExp);
            db.Update(resume);
            db.SaveChanges();

            return RedirectToAction("Edit", "Resume", new { resumeId = model.ResumeId });
        }
        // Реализованные проекты
        public ActionResult AddImplementedProjects(Guid resumeId)
        {
            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                        .Include(r => r.ImplementedProjects)
                       .FirstOrDefault(i => i.Id == resumeId);

            var model = new AddResumeImplementsProgectViewModel()
            {
                Resume = resume,
            };

            return View("/Arrea/Candidate/Views/Resumes/EditResume/AddImplementedProjects.cshtml", model);

        }

        [HttpPost]
        public ActionResult AddImplementedProjects(AddResumeImplementsProgectViewModel model)
        {

            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                   .Include(r => r.ImplementedProjects)
                  .FirstOrDefault(i => i.Id == model.ResumeId);

            var impProgect = db.ImplementedProjects.Include(e => e.Resume).FirstOrDefault(e => e.Id == model.Id);

            var newImplementProgect = new ImplementedProject()
            {
                Id = Guid.NewGuid(),
                NameProgect = model.NameProgect,
                DateWorkFrom = model.DateWorkFrom,
                DateWorkTo = model.DateWorkTo,
                LinkToProgect = model.LinkToProgect,

                Resume = resume,

            };

            resume.DateChange = DateTime.Now;
            resume.ImplementedProjects.Add(newImplementProgect);
            db.Update(resume);
            db.SaveChanges();

            return RedirectToAction("Edit", "Resume", new { resumeId = resume.Id });
        }

        // Образование
        public ActionResult AddEducation(Guid resumeId)
        {
            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                        .Include(r => r.Educations).ThenInclude(e => e.LevelEducation)
                        .Include(r => r.Educations).ThenInclude(e => e.FormTraining)
                       .FirstOrDefault(i => i.Id == resumeId);



            var model = new AddResumeEducationViewModel()
            {
                Resume = resume
            };
            model.LevelEducations = db.LevelEducations.Include(f => f.Educations)
                                                           .ThenInclude(f => f.Resume).Select(level => new SelectListItem()
                                                           {
                                                               Value = level.Id.ToString(),
                                                               Text = level.Name
                                                           }).ToList();
            model.FormTrainings = db.FormTrainings.Include(f => f.Educations)
                                                   .ThenInclude(f => f.Resume).Select(form => new SelectListItem()
                                                   {
                                                       Text = form.Name,
                                                       Value = form.Id.ToString()
                                                   }).ToList();

            return View("/Arrea/Candidate/Views/Resumes/EditResume/AddEducation.cshtml", model);

        }

        [HttpPost]
        public ActionResult AddEducation(AddResumeEducationViewModel model)
        {

            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                         .Include(r => r.Educations).ThenInclude(e => e.LevelEducation)
                         .Include(r => r.Educations).ThenInclude(e => e.FormTraining)
                        .FirstOrDefault(i => i.Id == model.ResumeId);

            var formTr = db.FormTrainings.Include(e => e.Educations).FirstOrDefault(e => e.Id == model.FormTrainingId);
            var lev = db.LevelEducations.Include(e => e.Educations).FirstOrDefault(e => e.Id == model.LevelEducationId);

            var newEducation = new Education()
            {
                Id = Guid.NewGuid(),

                LevelEducation = lev,
                NameInstitution = model.NameInstitution,
                City = model.City,
                DateWorkFrom = model.DateWorkFrom,
                DateWorkTo = model.DateWorkTo,
                FormTraining = formTr,

                Resume = resume,

            };
            resume.DateChange = DateTime.Now;

            resume.Educations.Add(newEducation);
            db.Update(resume);
            db.SaveChanges();

            return RedirectToAction("Edit", "Resume", new { resumeId = resume.Id });
        }

        // Знание іноземних мов
        public ActionResult AddForeignLanguage(Guid resumeId)
        {
            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                        .Include(r => r.ForeignLanguages)
                       .FirstOrDefault(i => i.Id == resumeId);

            var model = new AddResumeForeignLanguageViewModel()
            {
                Resume = resume,

            };
            model.LevelLanguage = db.LevelLanguages.Select(level => new SelectListItem()
            {
                Value = level.Id.ToString(),
                Text = level.Name
            }).ToList();
            return View("/Arrea/Candidate/Views/Resumes/EditResume/AddForeignLanguage.cshtml", model);

        }

        [HttpPost]
        public ActionResult AddForeignLanguage(AddResumeForeignLanguageViewModel model)
        {

            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                   .Include(r => r.ForeignLanguages)
                  .FirstOrDefault(i => i.Id == model.ResumeId);

            var levelLen = db.LevelLanguages.Include(e => e.ForeignLanguages).FirstOrDefault(e => e.Id == model.LevelLanguageId);

            var newForeignLanguages = new ForeignLanguage()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                LevelLanguage = levelLen,

                Resume = resume,

            };
            resume.DateChange = DateTime.Now;

            resume.ForeignLanguages.Add(newForeignLanguages);
            db.Update(resume);
            db.SaveChanges();

            return RedirectToAction("Edit", "Resume", new { resumeId = resume.Id });
        }


        // Тренинги и курсы
        public ActionResult AddTrainCourse(Guid resumeId)
        {
            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                        .Include(r => r.TrainingAndCources)
                       .FirstOrDefault(i => i.Id == resumeId);

            var model = new AddResumeTrainingAndCourcesViewModel()
            {
                Resume = resume,
            };

            return View("/Arrea/Candidate/Views/Resumes/EditResume/AddTrainingAndCources.cshtml", model);

        }

        [HttpPost]
        public ActionResult AddTrainCourse(AddResumeTrainingAndCourcesViewModel model)
        {

            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                   .Include(r => r.TrainingAndCources)
                  .FirstOrDefault(i => i.Id == model.ResumeId);

            // var trainCourse = db.TrainingAndCources.Include(e => e.Resume).FirstOrDefault(e => e.Id == model.Id);

            var newTrainCourse = new TrainingAndCource()
            {
                Id = Guid.NewGuid(),
                DateFrom = model.DateFrom,
                DateTo = model.DateTo,
                Name = model.Name,
                NumberCertification = model.NumberCertification,

                Resume = resume,

            };
            resume.DateChange = DateTime.Now;
            resume.TrainingAndCources.Add(newTrainCourse);
            db.Update(resume);
            db.SaveChanges();

            return RedirectToAction("Edit", "Resume", new { resumeId = resume.Id });
        }

        // Владение программным обеспечением и технологиями
        public ActionResult AddSoftWares(Guid resumeId)
        {
            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                        .Include(r => r.SoftWares)
                       .FirstOrDefault(i => i.Id == resumeId);

            var model = new AddResumeAddSoftWaresViewModel()
            {
                Resume = resume,
            };

            model.LevelTechnologyPossessions = db.LevelTechnologyPossessions.Include(f => f.SoftWares)
                                                   .ThenInclude(f => f.Resume).Select(form => new SelectListItem()
                                                   {
                                                       Text = form.Name,
                                                       Value = form.Id.ToString()
                                                   }).ToList();


            return View("/Arrea/Candidate/Views/Resumes/EditResume/AddAddSoftwares.cshtml", model);

        }

        [HttpPost]
        public ActionResult AddSoftWares(AddResumeAddSoftWaresViewModel model)
        {

            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                   .Include(r => r.TrainingAndCources)
                  .FirstOrDefault(i => i.Id == model.ResumeId);

            var level = db.LevelTechnologyPossessions.Include(e => e.SoftWares).FirstOrDefault(e => e.Id == model.LevelTechnologyPossessionId);

            var newSoftWare = new SoftWare()
            {
                Id = Guid.NewGuid(),

                Name = model.Name,
                LevelTechnologyPossession = level,


                Resume = resume,

            };

            resume.DateChange = DateTime.Now;

            resume.SoftWares.Add(newSoftWare);
            db.Update(resume);
            db.SaveChanges();

            return RedirectToAction("Edit", "Resume", new { resumeId = resume.Id });
        }

        // Нагороди
        public ActionResult AddAward(Guid resumeId)
        {
            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                        .Include(r => r.Awards)
                       .FirstOrDefault(i => i.Id == resumeId);

            var model = new AddResumeAwardViewModel()
            {
                Resume = resume,
            };


            return View("/Arrea/Candidate/Views/Resumes/EditResume/AddAward.cshtml", model);

        }

        [HttpPost]
        public ActionResult AddAward(AddResumeAwardViewModel model)
        {

            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                   .Include(r => r.TrainingAndCources)
                  .FirstOrDefault(i => i.Id == model.ResumeId);



            var newAward = new Award()
            {
                Id = Guid.NewGuid(),

                Name = model.Name,

                Resume = resume,

            };
            resume.DateChange = DateTime.Now;

            resume.Awards.Add(newAward);
            db.Update(resume);
            db.SaveChanges();

            return RedirectToAction("Edit", "Resume", new { resumeId = resume.Id });
        }

        // Додаткова інформація
        public ActionResult AddAditionInformation(Guid resumeId)
        {
            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                        .Include(r => r.AditinalInfo)
                       .FirstOrDefault(i => i.Id == resumeId);

            var model = new AddInformationViewModel()
            {
                Resume = resume,
            };


            return View("/Arrea/Candidate/Views/Resumes/EditResume/AddInformation.cshtml", model);

        }

        [HttpPost]
        public ActionResult AddAditionInformation(AddInformationViewModel model)
        {

            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                   .Include(r => r.AditinalInfo)
                  .FirstOrDefault(i => i.Id == model.ResumeId);



            var aditinalInfo = new AditinalInfo()
            {
                Id = Guid.NewGuid(),

                Text = model.Text,

                Resume = resume,

            };
            resume.DateChange = DateTime.Now;

            resume.AditinalInfo = aditinalInfo;
            db.Update(resume);
            db.SaveChanges();

            return RedirectToAction("Edit", "Resume", new { resumeId = resume.Id });
        }

        public ActionResult DeleteResume(Guid resumeId)
        {

            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                   .FirstOrDefault(i => i.Id == resumeId);

            db.Resumes.Remove(resume);
            db.SaveChanges();

            return RedirectToAction("Index", "Resume", new
            {
                candidateId = resume.CandidateId
            });
        }



        // --------------- EDIT -------------
        // EditFieldActivity and NameRes
        public ActionResult EditFieldActivity(Guid resumeId, Guid fieldActId)
        {
            var resume = db.Resumes.Include(r => r.FieldActivities)
                       .FirstOrDefault(i => i.FieldActivities.Where(f => f.FieldActivityId == fieldActId) != null);

            var field = db.FieldActivities.Include(f => f.Resumes).FirstOrDefault(i => i.Id == fieldActId);

            var model = new EditFieldActivityViewModel()
            {
                FieldActivityId = field.Id,
                Resume = resume,
                FieldActivityName = field.Name
            };
            model.FieldActivities = db.FieldActivities.Include(f => f.Resumes)
                                                        .Select(e => new SelectListItem()
                                                        {
                                                            Value = e.Id.ToString(),
                                                            Text = e.Name
                                                        }).ToList();


            return View("/Arrea/Candidate/Views/Resumes/EditResume/EditFieldActivity.cshtml", model);

        }

        [HttpPost]
        public ActionResult EditFieldActivity(EditFieldActivityViewModel model)
        {
            var fildAct = db.FieldActivities.Include(f => f.Resumes).FirstOrDefault(i => i.Id == model.FieldActivityId);

            var resumeUpdate = db.Resumes.Include(r => r.FieldActivities)
                        .FirstOrDefault(i => i.FieldActivities.Where(f => f.FieldActivityId == model.FieldActivityId) != null);
            var upFieldResume = resumeUpdate.FieldActivities.FirstOrDefault(f => f.FieldActivityId == fildAct.Id);



            if (model.FieldActivityId != null)
            {


                upFieldResume.FieldActivity = fildAct;




            }

            resumeUpdate.DateChange = DateTime.Now;

            db.FieldsActivityResume.Update(upFieldResume);
            db.Resumes.Update(resumeUpdate);
            db.SaveChanges();

            return RedirectToAction("Edit", "Resume", new { resumeId = resumeUpdate.Id });
        }

        public ActionResult EditAvatarActivResume(Guid resumeId)
        {
            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                        .FirstOrDefault(i => i.Id == resumeId);
            var model = new EditAvatarActivResViewModel()
            {
                Id = resume.Id,
                ResumeName = resume.Name,
                Email = resume.Candidate.Email,
                Foto = resume.Foto,
                IsActiveResume = resume.IsActiveResume,
                IsAnonymousResume = resume.IsAnonymousResume
            };

            return View("/Arrea/Candidate/Views/Resumes/EditResume/EditAvatarActivResume.cshtml", model);
        }
        [HttpPost]
        public async Task<ActionResult> EditAvatarActivResume(EditAvatarActivResViewModel model, IFormFile Image)
        {
            var updateResume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                  .FirstOrDefault(i => i.Id == model.Id);

            if ((updateResume.IsActiveResume == false && model.IsActiveResume == true)
                || (updateResume.IsActiveResume == true && model.IsActiveResume == false))
            {
                updateResume.IsActiveResume = model.IsActiveResume;
            }
            if ((updateResume.IsAnonymousResume == false && model.IsAnonymousResume == true)
                || (updateResume.IsAnonymousResume == true && model.IsAnonymousResume == false))
            {
                updateResume.IsAnonymousResume = model.IsAnonymousResume;
            }



            if (model.ResumeName != null)
                updateResume.Name = model.ResumeName;


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

            updateResume.DateChange = DateTime.Now;

            db.Resumes.Update(updateResume);
            db.SaveChanges();

            return RedirectToAction("Edit", "Resume", new { resumeId = updateResume.Id });
        }

        public ActionResult EditContactInfo(Guid resumeId)
        {
            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                .Include(r => r.Candidate).ThenInclude(r => r.FamilyStatus)
                .Include(r => r.Candidate).ThenInclude(r => r.Children)
                .Include(r => r.Candidate).ThenInclude(r => r.City)
                  .FirstOrDefault(i => i.Id == resumeId);

            var famStatus = db.FamilyStatuses
                .Include(f => f.Candidates).ThenInclude(can => can.Resumes).ToList();
            var model = new EditContactInfoViewModel()
            {
                Id = resume.Id,
                ResumeName = resume.Name,
                Email = resume.Candidate.Email,
                Surname = resume.Candidate.Surname,
                Name = resume.Candidate.Name,
                FatherName = resume.Candidate.Name,
                Sex = resume.Candidate.Sex,
                Birthday = resume.Candidate.Birthday,
                Phone = resume.Candidate.PhoneNumber,
                Facebook = resume.Candidate.Facebook,
                Skype = resume.Candidate.Skype,

                Country = resume.Candidate.Country,
                Region = resume.Candidate.Region,
                CityResident = resume.Candidate.City?.Name,
                Street = resume.Candidate.Street

            };

            model.FamilyStatuses = db.FamilyStatuses
                .Include(f => f.Candidates).ThenInclude(can => can.Resumes).Select(e => new SelectListItem()
                {
                    Value = e.Id.ToString(),
                    Text = e.Name
                }).ToList();
            model.Childrens = db.Childrens
                .Include(f => f.Candidates).ThenInclude(can => can.Resumes).Select(e => new SelectListItem()
                {
                    Value = e.Id.ToString(),
                    Text = e.Name
                }).ToList();
  

            return View("/Arrea/Candidate/Views/Resumes/EditResume/EditContactInfo.cshtml", model);
        }
        [HttpPost]
        public ActionResult EditContactInfo(EditContactInfoViewModel model)
        {
            var updateResume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                .Include(r => r.Candidate).ThenInclude(r => r.FamilyStatus)
                .Include(r => r.Candidate).ThenInclude(r => r.Children)
                  .FirstOrDefault(i => i.Id == model.Id);


            updateResume.Candidate.Surname = model.Surname;

            updateResume.Candidate.Name = model.Name;

            updateResume.Candidate.LastName = model.FatherName;

            updateResume.Candidate.Sex = model.Sex;

            
            if (model.Birthday != DateTime.MinValue)
                updateResume.Candidate.Birthday = model.Birthday;

            updateResume.Candidate.PhoneNumber = model.Phone;
            updateResume.Candidate.Email = model.Email;
            updateResume.Candidate.Facebook = model.Facebook;
            updateResume.Candidate.Skype = model.Skype;
      

            if (model.ChildrenId != null)
            {
                var c = db.Childrens.FirstOrDefault(ch => ch.Id == model.ChildrenId);
                updateResume.Candidate.Children = c;
            }
            if (model.FamilyStatusId != null)
            {
                var famStatus = db.FamilyStatuses.FirstOrDefault(f => f.Id == model.FamilyStatusId);
                updateResume.Candidate.FamilyStatus = famStatus;
            }

            updateResume.DateChange = DateTime.Now;

            db.Resumes.Update(updateResume);
            db.SaveChanges();

            return RedirectToAction("Edit", "Resume", new { resumeId = updateResume.Id });
        }

        public ActionResult EditExpiriance( Guid exId)
        {
            var resume = db.Resumes.Include(r => r.Experiences).ThenInclude(e => e.Employment)
                       .FirstOrDefault(i => i.Experiences.Where(f => f.Id == exId) != null);

            var exp = db.Experiences.Include(f => f.Employment).FirstOrDefault(i => i.Id == exId);
            //var exp = resume.Experiences.FirstOrDefault(e => e.Id == exId);
          
            var model = new EditExperiencesOfWorkViewModel()
            {
                Id = exp.Id,
                Resume = resume,
                ResumeName = resume.Name,
                DateWorkFrom = exp.DateWorkFrom,
                DateWorkTo = exp.DateWorkTo,
                NameOrganization = exp.NameOrganization,

                IsWorkingNow = exp.IsWorkingNow,
                EmploymentName = exp.Employment.Name,
              Position = exp.Position,
              Task = exp.Task,
              Progres = exp.Progres,

                
            };
            model.Employments = db.Employments.Include(f => f.Experiences)
                                                        .Select(e => new SelectListItem()
                                                        {
                                                            Value = e.Id.ToString(),
                                                            Text = e.Name
                                                        }).ToList();


            return View("/Arrea/Candidate/Views/Resumes/EditResume/EditEx.cshtml", model);

        }

        [HttpPost]
        public ActionResult EditExpiriance(EditExperiencesOfWorkViewModel model)
        {
            var upExp = db.Experiences.Include(f => f.Employment).FirstOrDefault(i => i.Id == model.Id);

            var resumeUpdate = db.Resumes.Include(r => r.Experiences)
                        .FirstOrDefault(i => i.Experiences.Where(e => e.Id == upExp.Id) != null);
           // var upExp = resumeUpdate.Experiences.FirstOrDefault(f => f.Id == exp.Id);

            var emp = db.Employments.Include(e => e.Experiences)
                .FirstOrDefault(e => e.Id == model.EmploymentId);



            upExp.NameOrganization = model.NameOrganization;
            upExp.DateWorkFrom = model.DateWorkFrom;
            upExp.DateWorkTo = model.DateWorkTo;

            if ((upExp.IsWorkingNow == false && model.IsWorkingNow == true)
                || (upExp.IsWorkingNow == true && model.IsWorkingNow == false))
            {
                upExp.IsWorkingNow = model.IsWorkingNow;
            }
            upExp.Employment = emp;
            upExp.Position = model.Position;
            upExp.Task = model.Task;
            upExp.Position = model.Position;

            resumeUpdate.DateChange = DateTime.Now;

            db.Experiences.Update(upExp);
            db.Resumes.Update(resumeUpdate);
            db.SaveChanges();

            return RedirectToAction("Edit", "Resume", new { resumeId = resumeUpdate.Id });
        }
        //EditAditionInformation

        public ActionResult EditAditionInformation(Guid resumeId)
        {
            var resume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                .Include(r => r.AditinalInfo)
                  .FirstOrDefault(i => i.Id == resumeId);

            var famStatus = db.FamilyStatuses
                .Include(f => f.Candidates).ThenInclude(can => can.Resumes).ToList();
            var model = new EditAditionInformationViewModel()
            {
                Id = resume.AditinalInfo.Id,
                Text = resume.AditinalInfo.Text,
                Resume = resume,
                ResumeId = resume.Id

            };

       

            return View("/Arrea/Candidate/Views/Resumes/EditResume/EditInfo.cshtml", model);
        }
        [HttpPost]
        public ActionResult EditAditionInformation(EditAditionInformationViewModel model)
        {
            var updateResume = db.Resumes.Include(r => r.Candidate).ThenInclude(r => r.AccountUser)
                .Include(r => r.AditinalInfo)
                  .FirstOrDefault(i => i.Id == model.ResumeId);


            updateResume.AditinalInfo.Text = model.Text;


            updateResume.DateChange = DateTime.Now;

            db.Resumes.Update(updateResume);
            db.SaveChanges();

            return RedirectToAction("Edit", "Resume", new { resumeId = updateResume.Id });
        }

    }
}



