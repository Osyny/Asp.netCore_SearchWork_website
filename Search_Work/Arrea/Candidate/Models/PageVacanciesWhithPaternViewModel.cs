using Search_Work.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Candidate.Models
{
    public class PageVacanciesWhithPaternViewModel
    {
    public List<VacancieByPaternViewModel> Vacancies { get; set; }
    public CataloguePaginationViewModel Pagination { get; set; }
  }

  public class VacancieByPaternViewModel
  {
    public string VacancyName { get; set; }
    public Guid Id { get; set; }

    public string LogoUrl { get; set; }

    public DateTime DateCreate { get; set; }

    public string CompanyName { get; set; }
    public int Salary { get; set; }


    public string City { get; set; }

    public string LinkPageVacancy { get; set; }

  }
}

