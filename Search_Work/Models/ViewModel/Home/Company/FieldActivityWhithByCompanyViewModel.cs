using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ViewModel.Home.Company
{
    public class FieldActivityWhithByCompanyViewModel
    {
    public Guid FieldActivityId { get; set; }
    public string FieldActivityName { get; set; }
  }

  
    public class PageCompaniesByFeldViewModel
  {
    public List<FieldActivityWhithByCompanyViewModel> CompaniesByFeld { get; set; }
  }
}
