using Microsoft.AspNetCore.Mvc.Rendering;
using Search_Work.Models.ArreaDatabase.Resumes;
using Search_Work.Models.ViewModel;
using Search_Work.Models.ViewModel.Home.Resumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Candidate.Models
{
    public class PageNewResumeViewModel
  {
    public Guid CandidateId { get; set; }

    public string FotoUrl { get; set; }
    // public Int32 ID { get; set; }
    public string LastName { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Sex { get; set; }
    public DateTime Birthday { get; set; }

    public string Country { get; set; }
    public string Region { get; set; }

    public int Salary { get; set; }

    //public string City { get; set; }
    public string Street { get; set; }
    public string ApartmentNumber { get; set; }

    public List<CityViewModel> Cities { get; set; }
    public Guid CityId { get; set; }


    public List<FieldActivityViewModel> FieldsActivity { get; set; }
    public Guid FieldId { get; set; }

    public List<FamilyStatusViewModel> FamilyStatuses { get; set; }
    public Guid FamilyStatusId { get; set; }

    public List<ChildrenViewModel> Childrens { get; set; }
    public Guid ChildId { get; set; }


    public string Fasebook { get; set; }
    public string Linkedin { get; set; }
    public List<PhoneNumberViewModel> Phones { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Skype { get; set; }

    public List<ExperienceViewModel> Experiences { get; set; }
    public List<SelectListItem> DictioneryTypeEmp { get; set; }

    public List<ImplementedProjectViewModel> ImplementedProjects { get; set; }

    public List<EducationViewModel> Educations { get; set; }
    public List<SelectListItem> DictioneryTypeLevEducation { get; set; }
    public List<SelectListItem> DictioneryTypeFormTrain { get; set; }

    public List<ForeignLanguageViewModel> ForeignLanguages { get; set; }
    public List<SelectListItem> DictionaryLevelLanguage { get; set; }


    public List<TrainingAndCourceViewMopdel> TrainingsAndCource { get; set; }

    public List<SoftwareViewModel> SoftWares { get; set; }
    public List<SelectListItem> DictioneryLevelTechnologyPossession { get; set; }

    public List<AwardViewModel> Awards { get; set; }
    public List<PublicationViewModel> Publications { get; set; }

    public List<RecomendationViewModel> Recomendations { get; set; }

    public List<VideoPresentationViewModel> VideoPresentations { get; set; }


    //toDo Documentation
    public List<DocumentationViewModel> Documentations { get; set; }

    public string AdditionalInformation { get; set; }


    public bool IsAnonymousResume { get; set; }
    public bool IsHideContact { get; set; }
  }

  public class ExperienceViewModel
  {
    public Guid Id { get; set; }
    public string NameCompany { get; set; }
    public DateTime DateWorkFrom { get; set; }
    public DateTime DateWorkTo { get; set; }
    public string YearsWork
    {
      get
      {
        var dif = (DateWorkTo - DateWorkFrom).Days;

        DateTime year = new DateTime().AddDays(dif);

        var m = DateWorkTo.Month - DateWorkFrom.Month;

        return year.ToString($"{m} міс yy років");
      }
    }

    public string Position { get; set; }

    public List<EmploymentViewModel> Employments { get; set; }
    public Guid EmploymentId { get; set; }

    public string Task { get; set; }
    public string Progres { get; set; }

    public string LinkSiteCompany { get; set; }
    public string CityName { get; set; }

  }

  public class EmploymentViewModel
  {
    public Guid Id { get; set; }
    public string NameField { get; set; }

  }

  public class FamilyStatusViewModel
  {
    public Guid Id { get; set; }
    public string NameField { get; set; }

  }

  public class PhoneNumberViewModel
  {
    public Guid Id { get; set; }
    public string Number { get; set; }

  }

  public class ChildrenViewModel
  {
    public Guid Id { get; set; }
    public string FieldName { get; set; }

  }

  public class ImplementedProjectViewModel
  {
    public Guid Id { get; set; }
    public string NameProgect { get; set; }
    public DateTime DateWorkFrom { get; set; }
    public DateTime DateWorkTo { get; set; }

    public string YearsWork
    {
      get
      {
        var dif = (DateWorkTo - DateWorkFrom).Days;

        DateTime year = new DateTime().AddDays(dif);

        var m = DateWorkTo.Month - DateWorkFrom.Month;

        return year.ToString($"{m} міс yy років");
      }
    }

    public string LinkToProgect { get; set; }
  }

  public class EducationViewModel
  {
    public Guid Id { get; set; }

    public string NameInstitution { get; set; }

    public List<LevelEducationViewModel> LevelsEducation { get; set; }
    public Guid LevelEducationId { get; set; }
    public LevelEducation LevelEducation { get; set; }

    //   public List<SpecializationViewModel> Specializations { get; set; }
    public string Specialization { get; set; }
    public string City { get; set; }

    public List<FormTrainingViewModel> FormTrainings { get; set; }
    public Guid FormTrainingId { get; set; }

    public DateTime DateWorkFrom { get; set; }
    public DateTime DateWorkTo { get; set; }

    public string YearsWork
    {
      //(lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year);

      get
      {


        var dif = (DateWorkTo - DateWorkFrom).Days;

        DateTime year = new DateTime().AddDays(dif);

        var g = $"{year.Month} міс {year.Year} років";

        var m = DateWorkTo.Month - DateWorkFrom.Month;

        return year.ToString($"{m} міс yy років");


      }

    }

  }

  public class SpecializationViewModel
  {
    public Guid Id { get; set; }
    public string NameField { get; set; }


  }

  public class LevelEducationViewModel
  {
    public Guid Id { get; set; }
    public string NameField { get; set; }

  }

  public class FormTrainingViewModel
  {
    public Guid Id { get; set; }
    public string NameField { get; set; }

  }

  public class AwardViewModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string SiteUrlEdition { get; set; }
  }

  public class PublicationViewModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string SiteEdition { get; set; }
  }

  public class TrainingAndCourceViewMopdel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }

    public string MounseWork
    {

      get
      {
        var dif = (DateTo - DateFrom).Days;

        DateTime mounse = new DateTime().AddDays(dif);

        return mounse.ToString("m");
      }
    }
    public int NumberSertifikation { get; set; }
  }

  public class VideoPresentationViewModel
  {
    public Guid Id { get; set; }
    public string VideoUrl { get; set; }

  }

  public class RecomendationViewModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string NameCompany { get; set; }
    public string Link { get; set; }

    public string ShortRecomendation { get; set; }

    public string ScanRecomendation { get; set; }

  }

  public class ForeignLanguageViewModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<LevelLanguageViewModel> LevelsLanguage { get; set; }
    public Guid LevelLanguageId { get; set; }
    public string LevelLanguage { get; set; }
  }

  public class LevelLanguageViewModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }

  }

  public class SoftwareViewModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<LevelSoftWareViewModel> LevelsSoftWare { get; set; }
    public Guid LevelSoftWareId { get; set; }
    public string LevelSoftWare { get; set; }
  }

  public class LevelSoftWareViewModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }

  }

  public class DocumentationViewModel
  {
    public Guid Id { get; set; }
    public string NameFile { get; set; }
    public string TypeFile { get; set; }

  }
}

