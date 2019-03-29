using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ViewModel.Employer.Company
{
    public class CompaniesListViewModel
    {
        public string Employer { get; set; }
        public List<ArreaDatabase.Company> Companies { get; set; }
    }
}
