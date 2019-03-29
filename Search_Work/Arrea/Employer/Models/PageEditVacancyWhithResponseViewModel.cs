using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Employer.Models
{
  public class PageEditVacancyWhithResponseViewModel
  {

    public Guid Id { get; set; }

    public string NameVacancy { get; set; }

    public Guid EmployerId { get; set; }
    public string EmployerName { get; set; }


    public DateTime DateCreate { get; set; }

    public DateTime DatePublication { get; set; }
    public string Status { get; set; }
    public bool IsPublication { get; set; }

    public List<SelectListItem> Cities { get; set; }
    public Guid CityId { get; set; }

    public List<SelectListItem> FieldsActivity { get; set; }
    public Guid FieldId { get; set; }

    public List<SelectListItem> Employments { get; set; }
    public Guid EmploymentId { get; set; }

    public List<SelectListItem> ExperiencesOfWork { get; set; }
    public Guid ExperienceOfWorkId { get; set; }

    public string CityName { get; set; }

    public int Salary { get; set; }


    public string Description { get; set; }
    public string Requirement { get; set; }
    public string Responsibilities { get; set; }
    public string ForeignLanguages { get; set; }
    public string AdditionalRequirements { get; set; }

    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string ContactPerson { get; set; }


    public bool UseCompanyContact { get; set; }
    public bool UsePersonalContact { get; set; }
  }
}
