using Search_Work.Data;
using Search_Work.Models.ArreaDatabase.Resumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Vacancies
{
  public class Vacancy
  {
    public Vacancy()
    {
      RecommendedVacancies = new List<RecommendedVacancy>();
      PageViews = new List<ViewPage>();
    }


    // public string Post { get; set; }
    // public string Test { get; set; }
    //public string LogoUrl { get; set; }

    public Guid Id { get; set; }
    public string Name { get; set; }

    public int Wage { get; set; }

    public Guid CityId { get; set; }
    public City City { get; set; }

    public DateTime DateCreate { get; set; }

    public string Description { get; set; }
    public string Requirement { get; set; }
    public string Responsibilities { get; set; }
    public string ForeignLanguages { get; set; }
    public string AdditionalRequirements { get; set; }

    public EmploymentType TypeEmployment { get; set; }
    public Guid TypeEmploymentId { get; set; }


    public ExperienceOfWork ExperienceOfWork { get; set; }
    public Guid ExperienceOfWorkId { get; set; }


    public string ContactNamePerson { get; set; }
    public string PhoneNumberPerson { get; set; }
    public string EmailPerson { get; set; }

    public bool IsUseCompanyContact { get; set; }
    public bool IsUsePersonalContact { get; set; }



    public string Site { get; set; }
    public string Facebook { get; set; }
    public string Linkedin { get; set; }

    public Guid FieldActivityId { get; set; }
    public FieldActivity FieldActivity { get; set; }

    public Guid EmployerId { get; set; }
    public Employer Employer { get; set; }

    public List<ResponseToResume> Responses { get; set; }
    public List<ResponseToVacancy> ResponsesVacansy { get; set; }


    public bool IsActive { get; set; }
    public string Status { get; set; }

    public DateTime DatePublication { get; set; }

    public ICollection<ViewPage> PageViews { get; set; }

    public ICollection<RecommendedVacancy> RecommendedVacancies { get; set; }

    public ICollection<SavedVacancy> SavedVacancies { get; set; }
  }
}
