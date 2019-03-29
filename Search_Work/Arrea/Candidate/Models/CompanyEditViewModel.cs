using Search_Work.Models.ArreaDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Search_Work.Arrea.Candidate.Models
{
  public class CompanyEdit1ViewModel
  {
    public CompanyEditViewModel Company { get; set; }
    public Guid EmployeeId { get; set; }
  }

  public class CompanyEditViewModel
  {
    public Guid Id { get; set; }

    public Guid EmployeeId { get; set; }
    public string CompanyName { get; set; }
    public string CompanyLogo { get; set; }
    public List<SelectListItem> Cities { get; set; }
   
    public Guid CityId { get; set; }
    public string CityName { get; set; }

    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Site { get; set; }
    public string Facebook { get; set; }
    public string Adress { get; set; }

    public bool Status { get; set; }

    public List<Search_Work.Models.ArreaDatabase.Employer> Employers { get; set; }
  }
 }
