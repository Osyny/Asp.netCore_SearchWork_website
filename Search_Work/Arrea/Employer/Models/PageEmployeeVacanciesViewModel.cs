using Search_Work.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Employer.Models
{
    public class PageEmployeeVacanciesViewModel
  {
    public List<EmployerVacancieViewdel> EmployeeVacancies { get; set; }


    public CataloguePaginationViewModel Pagination { get; set; }

    public Guid EmployeeId { get; set; }
    public int CurentPage { get; set; }

    public Guid CompanyId { get; set; }
    public Guid VacancyId { get; set; }

    public string TypeSortFilter { get; set; }

  }

  //public class EmployerVacancieViewdel
  //{
  //  public string NameVacancies { get; set; }
  //  public Guid VacancyId { get; set; }

  //  public int Salary { get; set; }
  //  public string City { get; set; }

  //  public string Status { get; set; }
  //  public string Editor { get; set; }
  //  // 
  //  public int CountLinkFeeback { get; set; }
  //  public int CountLinkNewFeeback { get; set; }
  //  public int CountLinkViews { get; set; }

  //  public int CountCandidate { get; set; }

  //  public DateTime DateCreate { get; set; }
  //}
}
