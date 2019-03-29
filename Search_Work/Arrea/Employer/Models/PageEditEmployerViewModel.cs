using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Employer.Models
{
    public class PageEditEmployerViewModel
    {

    public Guid Id { get; set; }
    public string LastName { get; set; }
    public string Name { get; set; }
    public string Comment { get; set; }
    public string Email { get; set; }

    public string PhoneNumber { get; set; }
    public string Photo { get; set; }

    public bool Status { get; set; }
    public string StatusName { get; set; }

    public Guid CompanyId { get; set; }
  }
}
