using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Employer.Models
{
  public class PageEmployerCompanyViewModel
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
