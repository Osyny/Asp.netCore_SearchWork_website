using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Search_Work.Models.ArreaDatabase.Resumes;
using Search_Work.Models.ViewModel;
using Search_Work.Models.ViewModel.Home.Resumes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Candidate.Models
{
    public class PageEditResumeViewModel
    {
        public Guid CandidateId { get; set; }

        public string ResumeName { get; set; }
        public Guid Id { get; set; }

        public string FotoUrl { get; set; }
        // public Int32 ID { get; set; }

        public string CandidateName { get; set; }
        public string LastName { get; set; }

        public string Surname { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }
        public List<CityViewModel> Cities { get; set; }
        //public string City { get; set; }

        public string CityResident { get; set; }

        public List<FieldActivityViewModel> FieldsActivityAll { get; set; }
        public List<FieldActivityViewModel> FieldsActivitySelect { get; set; }
        public Guid FieldId { get; set; }
        public List<Guid> FieldIds { get; set; }


        public string Country { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
        public string ApartmentNumber { get; set; }

        public List<SelectListItem> FamilyStatuses { get; set; }
        public Guid FamilyStatusId { get; set; }
        public string FamilyStatusName { get; set; }

        public List<SelectListItem> Childrens { get; set; }
        public Guid ChildrenId { get; set; }
        public string ChildrenName { get; set; }

        public string Fasebook { get; set; }
        public string Linkedin { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }


        public List<ExperienceEditViewModel> Experiences { get; set; }
        public List<ImplementedProjectViewModel> ImplementedProjects { get; set; }
        public List<EducationEditViewModel> Educations { get; set; }
        public List<ForeignLanguageEditViewModel> ForeignLanguages { get; set; }
        public List<TrainingAndCourceViewMopdel> TrainingAndCourses { get; set; }
        public List<SoftwareEditViewModel> Softwares { get; set; }
        public List<AwardViewModel> Awards { get; set; }
        public List<PublicationViewModel> Publications { get; set; }
        public List<RecomendationViewModel> Recomendations { get; set; }
        public List<VideoPresentationViewModel> VideoPresentations { get; set; }
        public List<DocumentationViewModel> Documentations { get; set; }

        public string AditinalInfos { get; set; }


        public bool IsAnonymousResume { get; set; }
        public bool IsHideContact { get; set; }
        public bool IsActiveResume { get; set; }

    }

    public class ExperienceEditViewModel
    {
        public Guid Id { get; set; }
        public string NameCompany { get; set; }
        public DateTime DateWorkFrom { get; set; }
        public DateTime DateWorkTo { get; set; }
        public string YearsWork
        {
            get
            {
                var dif = (DateTime.Now - DateWorkFrom).Days;

                DateTime year = new DateTime().AddDays(dif);

                return year.ToString("yy");
            }
        }

        public bool IsWorkingNow { get; set; }

        public string Position { get; set; }

        public List<SelectListItem> Employments { get; set; }
        public Guid EmploymentId { get; set; }

        public string Task { get; set; }
        public string Progres { get; set; }
    }

    public class EducationEditViewModel
    {
        public Guid Id { get; set; }
        public string NameInstitution { get; set; }

        public List<SelectListItem> LevelsEducation { get; set; }
        public Guid LevelEducationId { get; set; }
        public LevelEducation LevelEducation { get; set; }

        //   public List<SpecializationViewModel> Specializations { get; set; }
        public string Specialization { get; set; }
        public string City { get; set; }

        public List<SelectListItem> FormTrainings { get; set; }
        public Guid FormTrainingId { get; set; }

        public DateTime DateWorkFrom { get; set; }
        public DateTime DateWorkTo { get; set; }

        public string YearsWork
        {

            get
            {
                var dif = (DateTime.Now - DateWorkFrom).Days;

                DateTime year = new DateTime().AddDays(dif);

                return year.ToString("yy");
            }
        }

    }

    public class ForeignLanguageEditViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<SelectListItem> LevelsLanguage { get; set; }
        public Guid LevelLanguageId { get; set; }
        public string LevelLanguage { get; set; }
    }

    public class SoftwareEditViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<SelectListItem> LevelsSoftWare { get; set; }
        public Guid LevelSoftWareId { get; set; }
        public string LevelSoftWare { get; set; }
    }
}



