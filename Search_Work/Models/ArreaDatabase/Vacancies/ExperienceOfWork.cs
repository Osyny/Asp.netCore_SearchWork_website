using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Vacancies
{
  /// <summary>
  /// Опыт работы
  /// </summary>
  public class ExperienceOfWork
  {
    public Guid Id { get; set; }
    public string NameField { get; set; }

    public List<Vacancy> Vacancies { get; set; }
  }
}
