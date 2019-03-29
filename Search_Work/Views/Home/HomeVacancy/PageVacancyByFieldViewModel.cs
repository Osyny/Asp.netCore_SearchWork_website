using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Views.Home.HomeVacancy
{
    public class PageVacancyByFieldViewModel
    {
    public Guid Id { get; set; }
    public string VacancyName { get; set; }
    public int Salary { get; set; }
    public string CompanyName { get; set; }
    public string CityName { get; set; }

    public string CompanyLogoUrl { get; set; }

    public DateTime DateCriate { get; set; }

    public string Description { get; set; }
    public string Link { get; set; }
  }
}
