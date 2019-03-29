using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Employer.Models
{
  public class EmployerVacancieViewdel
  {
    public string NameVacancies { get; set; }
    public Guid VacancyId { get; set; }

    public int Salary { get; set; }
    public string City { get; set; }

    public string Status { get; set; }
    public string DatePublication { get; set; }
    // 
    public int CountLinkFeeback { get; set; }
    public int CountLinkNewFeeback { get; set; }
    public int CountLinkViews { get; set; }

    public int CountCandidate { get; set; }

    public DateTime DateCreate { get; set; }
  }
}
