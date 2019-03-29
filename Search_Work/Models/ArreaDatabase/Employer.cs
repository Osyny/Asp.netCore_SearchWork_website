using Search_Work.Models.ArreaDatabase.Resumes;
using Search_Work.Models.ArreaDatabase.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase
{
  public class Employer
  {
    public Guid Id { get; set; }
    public ApplicationUser AccountUser { get; set; }

    public Contact Contact { get; set; }

    public Company Company { get; set; }
    public Guid? CompanyId { get; set; }

    public ICollection<Vacancy> Vacancies { get; set; }

    public ICollection<ViewPage> ViewPages { get; set; }

  }
}
