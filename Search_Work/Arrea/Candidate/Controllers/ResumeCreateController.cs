using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Search_Work.Arrea.Candidate.Models.Resume;
using Search_Work.Controllers.Arrea.Candidate.Controllers;
using Search_Work.Data;
using Search_Work.Models;
using Search_Work.Models.ArreaDatabase.Resumes;
using Search_Work.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Candidate.Controllers
{
    public class ResumeCreateController : Controller
    {
        private readonly oxana1404 db;
        private readonly UserManager<ApplicationUser> _userManager;
        private IHostingEnvironment _environment;

        public ResumeCreateController(oxana1404 db, UserManager<ApplicationUser> userManager, IHostingEnvironment environment)
        {
            this.db = db;
            this._userManager = userManager;
            _environment = environment;
        }




        public ActionResult AddResume()
        {
            // IDENTITY USER NAME  HttpContext
            var userName = HttpContext.User.Identity.Name;

            var candidate = db.Candidates.Include(c => c.AccountUser)
              .FirstOrDefault(x => x.AccountUser.UserName == userName);

            var fieldsActivity = db.FieldActivities.Select(field => new FieldActivityViewModel()
            {
                Name = field.Name,
                Id = field.Id
            }).ToList();

            var model = new Models.Resume.AddResumeViewModel()
            {
                CandidateId = candidate.Id,
                FieldsActivity = fieldsActivity
            };

            return View("/Arrea/Candidate/Views/Resumes/AddResume.cshtml", model);
        }

        [HttpPost]
        public async Task<ActionResult> AddResume(AddResumeViewModel model, IFormFile Image)
        {
            var candidate = db.Candidates.Include(c => c.AccountUser)
              .FirstOrDefault(x => x.Id == model.CandidateId);

            var newResume = new Resume()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                // FieldActivities.
            };
            FieldActivityResume fieldActResume = null;

            var fieldActivity = db.FieldActivities.FirstOrDefault(f => f.Id == model.FieldId);
            if (fieldActivity != null)
            {
                fieldActResume = new FieldActivityResume()
                {
                    Resume = newResume,
                    Id = Guid.NewGuid(),
                    FieldActivity = fieldActivity,
                };
            }

            newResume.Candidate = candidate;

            if (Image != null)
            {
                string name = Image.FileName;
                string path = $"/files/{name}";
                string serverPath = $"{_environment.WebRootPath}{path}";
                FileStream fs = new FileStream(serverPath, FileMode.Create,
                    FileAccess.Write);
                await Image.CopyToAsync(fs);
                fs.Close();
                newResume.Foto = path;
            }


            newResume.Salary = model.Salary;

            // Todo AnonimResume  IsAnonymousResume

            newResume.Candidate.LastName = model.LastName;
            newResume.Candidate.Name = model.Name;

            newResume.Candidate.Surname = model.Surname;
            newResume.Candidate.Sex = model.Sex;
            newResume.Candidate.Birthday = model.Birthday;
            // Todo Phones ????
            newResume.Candidate.PhoneNumber = model.Phone;
            newResume.Candidate.Email = model.Email;
            newResume.Candidate.Facebook = model.Fasebook;
            newResume.Candidate.Linkedin = model.Linkedin;
            newResume.Candidate.Skype = model.Skype;

            newResume.DateCreate = DateTime.Now;
            newResume.DateChange = DateTime.Now;


            newResume.Candidate.Country = model.Country;
            newResume.Candidate.Region = model.Region;
            // newResume.Candidate.City = city;
            newResume.Candidate.Street = model.Street;
            newResume.Candidate.ApartmentNumber = model.ApartmentNumber;

            db.Resumes.Add(newResume);
            db.SaveChanges();

            return RedirectToAction(nameof(ResumeController.Edit), "Resume", new { resumeId = newResume.Id });

            // return Redirect("Edit", "Resume", new { resumeId  == newResume.Id});
        }
    }
}
