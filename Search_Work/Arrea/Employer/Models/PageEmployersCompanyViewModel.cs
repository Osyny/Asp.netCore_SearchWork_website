using Search_Work.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Employer.Models
{
    //public class PageEmployersCompanyViewModel
    //{
    //    public List<PageEmployerCompanyViewModel> EmployersCompany { get; set; }

    //    public CataloguePaginationViewModel Pagination { get; set; }

    //    // toDo Pagination ----------------------------------------------------------
    //    public Guid CompanyId { get; set; }
    //    public int CurentPage { get; set; }

    //    public Guid EmployeeId { get; set; }

    //}

    public class PageEmployeesCompanyViewModel
    {
        public List<EmployeViewModel> EmployeesCompany { get; set; }

        public CataloguePaginationViewModel Pagination { get; set; }

      
        public Guid CompanyId { get; set; }
        public int CurentPage { get; set; }

       
    }

    public class EmployeViewModel
    {
        public string NameEmployer { get; set; }
        public Guid EmpId { get; set; }
        public string Comment { get; set; }
        public string Role { get; set; }
        public string Editor { get; set; }

        public string Link { get; set; }
        public bool Status { get; set; }
    }


}
