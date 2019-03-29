using Search_Work.Arrea.Candidate.Models;
using Search_Work.Models.ViewModel;
using Search_Work.Models.ViewModel.Home.Resumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Employer.Models
{
  public class CreateVacancyViewModel
  {

   

      //public Guid EmployerId { get; set; }
      public string EmploerName { get; set; }
      public DateTime DateCreate { get; set; }

      public string Name { get; set; }
      public int Salary { get; set; }
      public string EmailContactPerson { get; set; }
      public string PhoneNumberContactPerson { get; set; }
      public string ContactPerson { get; set; }

      public List<CityViewModel> Cities { get; set; }
      public Guid CityId { get; set; }

      public List<FieldActivityViewModel> Fields { get; set; }
      public Guid FieldActivityId { get; set; }


      public List<EmploymentViewModel> Employments { get; set; }
      public Guid EmploymentId { get; set; }

      public List<ExperienceOfWorkViewModel> ExperienceOfWorks { get; set; }
      public Guid ExperienceOfWorkId { get; set; }

      public string Description { get; set; }
      public string Responsibilitie { get; set; }
      public string Requirement { get; set; }
      public string ForeignLanguages { get; set; }
      public string AdditionalRequirements { get; set; }


      public bool UseCompanyContact { get; set; }
      public bool UsePersonalContact { get; set; }
    }

    public class ExperienceOfWorkViewModel
    {
      public Guid Id { get; set; }
      public string NameField { get; set; }
    }
  }

