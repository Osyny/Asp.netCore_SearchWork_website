using Search_Work.Models.ArreaDatabase.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
  /// <summary>
  /// Рекомендовані вакансії кандидату
  /// </summary>
    public class RecommendedVacancy
    {
    public Guid Id { get; set; }


    public DateTime DateSaved { get; set; }

    public Candidate Candidate { get; set; }
    public Guid CandidateId { get; set; }


    public Vacancy Vacancy { get; set; }
    public Guid VacancyId { get; set; }
  }
}
