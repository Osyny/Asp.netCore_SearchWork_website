using Search_Work.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Candidate.Models
{
    public class PageRecommendedVacancyViewModel
    {
 
      public List<VacancyViewModel> Vacancies { get; set; }


      public CataloguePaginationViewModel Pagination { get; set; }

      public Guid CandidateId { get; set; }

      public string CandidateName { get; set; }
      public int CurentPage { get; set; }
    }

    public class VacancyViewModel
    {
      public Guid Id { get; set; }
      public string VacancyName { get; set; }
      public int Salary { get; set; }
      public string CompanyName { get; set; }
      public string CityName { get; set; }

      public string CompanyLogoUrl { get; set; }

      public DateTime DateSaved { get; set; }

      public string Description { get; set; }
      public string Link { get; set; }

      public string Email { get; set; }
      public string Linkedin { get; set; }
      public string PhoneNumber { get; set; }
    }
  }


