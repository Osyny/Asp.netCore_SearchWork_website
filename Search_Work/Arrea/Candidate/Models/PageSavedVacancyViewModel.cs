using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Candidate.Models
{
    public class PageSavedVacancyViewModel
    {
    public List<SavedVacancyViewModel> Vacannies { get; set; }
  }


  public class SavedVacancyViewModel
  {
    public Guid Id { get; set; }
    public string VacancyName { get; set; }
    public string CompanyName { get; set; }
    public DateTime DataCreate { get; set; }

    public string LinkToVacancy { get; set; }

  }
}

