using Microsoft.AspNetCore.Mvc.Rendering;
using Search_Work.Models.ArreaDatabase.Resumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Candidate.Models.Resume
{
    public class AddResumeExpiriensViewModel
    {
        public Guid Id { get; set; }
        public string NameOrganization { get; set; }
        public DateTime DateWorkFrom { get; set; }
        public DateTime DateWorkTo { get; set; }

        //public DateTime YearsWork
        //{

        //  get
        //  {
        //    var dif = (DateTime.Now - DateWorkFrom).Days;

        //    DateTime year = new DateTime().AddDays(dif);

        //    return year;
        //  }
        //}

        public string Position { get; set; }

        public string Task { get; set; }
        public string Progres { get; set; }

        public Search_Work.Models.ArreaDatabase.Resumes.Resume Resume { get; set; }
        public Guid ResumeId { get; set; }

        public List<SelectListItem> Employments { get; set; }
        public Guid EmploymentId { get; set; }

        public bool IsWorkingNow { get; set; }
    }

    public class AddResumeFieldActivitiesViewModel
    {
        public Guid Id { get; set; }
        public Search_Work.Models.ArreaDatabase.Resumes.Resume Resume { get; set; }
        public Guid ResumeId { get; set; }

        public List<SelectListItem> FieldActivities { get; set; }
        public Guid FieldActivityId { get; set; }
    }

    public class AddResumeImplementsProgectViewModel
    {
        public Guid Id { get; set; }
        public string NameProgect { get; set; }
        public DateTime DateWorkFrom { get; set; }
        public DateTime DateWorkTo { get; set; }

        public string LinkToProgect { get; set; }

        public Search_Work.Models.ArreaDatabase.Resumes.Resume Resume { get; set; }
        public Guid ResumeId { get; set; }
    }

    public class AddResumeEducationViewModel
    {
        public Guid Id { get; set; }

        public string NameInstitution { get; set; }
        public string Specialization { get; set; }
        public string City { get; set; }

        public DateTime DateWorkFrom { get; set; }
        public DateTime DateWorkTo { get; set; }

        public Search_Work.Models.ArreaDatabase.Resumes.Resume Resume { get; set; }
        public Guid ResumeId { get; set; }

        public List<SelectListItem> LevelEducations { get; set; }
        public Guid LevelEducationId { get; set; }


        public List<SelectListItem> FormTrainings { get; set; }
        public Guid FormTrainingId { get; set; }
    }

    public class AddResumeForeignLanguageViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<SelectListItem> LevelLanguage { get; set; }
        public Guid LevelLanguageId { get; set; }



        public Search_Work.Models.ArreaDatabase.Resumes.Resume Resume { get; set; }
        public Guid ResumeId { get; set; }

    }

    public class AddResumeTrainingAndCourcesViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int NumberCertification { get; set; }

        public Search_Work.Models.ArreaDatabase.Resumes.Resume Resume { get; set; }
        public Guid ResumeId { get; set; }
    }

    public class AddResumeAddSoftWaresViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Search_Work.Models.ArreaDatabase.Resumes.Resume Resume { get; set; }
        public Guid ResumeId { get; set; }

        public List<SelectListItem> LevelTechnologyPossessions { get; set; }
        public Guid LevelTechnologyPossessionId { get; set; }
    }

    public class AddResumeAwardViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string SiteUrlEdition { get; set; }

        public Search_Work.Models.ArreaDatabase.Resumes.Resume Resume { get; set; }
        public Guid ResumeId { get; set; }
    }

    public class AddInformationViewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        
        public Search_Work.Models.ArreaDatabase.Resumes.Resume Resume { get; set; }
        public Guid ResumeId { get; set; }
    }

    //====================== Edit ======================= 

    public class EditFieldActivityViewModel
    {
        public Guid Id { get; set; }

        public Search_Work.Models.ArreaDatabase.Resumes.Resume Resume { get; set; }
        public Guid ResumeId { get; set; }

        public List<SelectListItem> FieldActivities { get; set; }
        public Guid FieldActivityId { get; set; }
        public string FieldActivityName { get; set; }
    }

    public class EditAvatarActivResViewModel
    {
        public Search_Work.Models.ArreaDatabase.Resumes.Resume Resume { get; set; }
        public Guid Id { get; set; }
        public string ResumeName { get; set; }
        public string Email { get; set; }


        public string Foto { get; set; }
        public bool IsActiveResume { get; set; }
        public bool IsAnonymousResume { get; set; }
    }

    public class EditContactInfoViewModel
    {
        public Search_Work.Models.ArreaDatabase.Resumes.Resume Resume { get; set; }
        public Guid Id { get; set; }

        public string ResumeName { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Skype { get; set; }


        public string Country { get; set; }
        public string Region { get; set; }
        public string CityResident { get; set; }
        public string Street { get; set; }

        public List<SelectListItem> FamilyStatuses { get; set; }
        public Guid FamilyStatusId { get; set; }
        public string FamilyStatusName { get; set; }

        public List<SelectListItem> Childrens { get; set; }
        public Guid ChildrenId { get; set; }
        public string ChildrenStatus { get; set; }

    }

    public class EditExperiencesOfWorkViewModel
    {
        public Guid Id { get; set; }
        public Search_Work.Models.ArreaDatabase.Resumes.Resume Resume { get; set; }
        public Guid ResumeId { get; set; }

        public string ResumeName { get; set; }
        public string Email { get; set; }

        public string NameOrganization { get; set; }
        public DateTime DateWorkFrom { get; set; }
        public DateTime DateWorkTo { get; set; }

        //public DateTime YearsWork
        //{

        //  get
        //  {
        //    var dif = (DateTime.Now - DateWorkFrom).Days;

        //    DateTime year = new DateTime().AddDays(dif);

        //    return year;
        //  }
        //}

        public string Position { get; set; }

        public string Task { get; set; }
        public string Progres { get; set; }

        public List<SelectListItem> Employments { get; set; }
        public Guid EmploymentId { get; set; }
        public string EmploymentName { get; set; }


        public bool IsWorkingNow { get; set; }

    }

    public class EditAditionInformationViewModel
    {
        public Guid Id { get; set; }
        public Search_Work.Models.ArreaDatabase.Resumes.Resume Resume { get; set; }
        public Guid ResumeId { get; set; }

        public string Text { get; set; }
    }

}
