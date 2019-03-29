using Search_Work.Models.ArreaDatabase.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
    /// <summary>
    /// Зайнятість
    /// </summary>
    public class EmploymentType
    {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<Experience> Experiences { get; set; }

    public List<Vacancy> Vacancies { get; set; }

  }
}
