using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Search_Work.Models.ArreaDatabase;

namespace Search_Work.Models.ViewModel.Company
{
  public class CreateCompanyViewModel
  {
      public ArreaDatabase.Employer Employer { get; set; }
     // public Guid? EmployerId { get; set; }

      public List<SelectListItem> Cities { get; set; }
      public Guid? CityId { get; set; }

    public string Name { get; set; }

 
    public string CompanyLogoUrl { get; set; }

    


    public string Description { get; set; }


    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Site { get; set; }
    public string Facebook { get; set; }

    public string Adress { get; set; }

  }
}
