using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ViewModel.Employer
{
    public class SearchCompanyNameViewModel
    {
        public ArreaDatabase.Employer Employer { get; set; }
        public string NameEmp { get; set; }
        public Guid? EmpId { get; set; }

        public List<SelectListItem> Companies { get; set; }
        public Guid? CompanyId { get; set; }
    }
}
