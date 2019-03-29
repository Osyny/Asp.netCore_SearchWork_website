using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Employer.Models
{
  public class PageAboutCompanyViewModel
  {
    public Guid CompanyId { get; set; }
    public string NameConpany { get; set; }

    public Guid EmployeeId { get; set; }
    public string Address { get; set; }
    public string Requisites { get; set; }

    public string Phone { get; set; }
    public string Email { get; set; }


    public string CompanyLogo { get; set; }
    public string Fasebook { get; set; }
    public string Linkedin { get; set; }
    public string Site { get; set; }

    public string Description { get; set; }
    public string City { get; set; }
    public string Street { get; set; }

    public List<string> Certificates { get; set; }

    public string Status { get; set; }

    
  }
}
