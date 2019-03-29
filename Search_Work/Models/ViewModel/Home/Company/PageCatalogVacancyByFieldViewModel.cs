using Search_Work.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ViewModel.Home.Company
{
    public class PageCatalogVacancyByFieldViewModel
    {
    public string FialdActivityName { get; set; }

    public Int32 CountVacancyByFieldActivity { get; set; }

    public List<PageVacancyByFieldViewModel> VacanciesByField { get; set; }

    public CataloguePaginationViewModel Pagination { get; set; }

    public Guid CityId { get; set; }
    public string CityName { get; set; }

    public Guid FieldId { get; set; }
    public int CurrentPage { get; set; }

    public string SelectedFilter { get; set; }
  }

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
