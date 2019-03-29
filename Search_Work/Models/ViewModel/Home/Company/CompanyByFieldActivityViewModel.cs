using Search_Work.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ViewModel.Home.Company
{

  public class CompaniesPageByFieldActivityViewModel
  {
    public string FialdActivityName { get; set; }
    public int ActivityInCategoryCount { get; set; }
    public bool IsShowOnlyActive { get; set; }

    public List<CompanyByFieldActivityViewModel> CompaniesByFieldActivity { get; set; }

    public CataloguePaginationViewModel Pagination { get; set; }
  }

  public class CompanyByFieldActivityViewModel
    {
    public Guid СompanyId { get; set; }
    public string CompanyName { get; set; }
    public string CompanyLogoUrl { get; set; }
    public int VacancyCount { get; set; }
  }
}
