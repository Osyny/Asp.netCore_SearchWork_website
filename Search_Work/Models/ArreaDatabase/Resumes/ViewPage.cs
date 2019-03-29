using Search_Work.Models.ArreaDatabase.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
  /// <summary>
  /// Перегляли резюме, vacancy
  /// </summary>
  public class ViewPage
  {
    public Guid Id { get; set; }

    public Resume Resume { get; set; }
    public Guid? ResumeId { get; set; }

    public Vacancy Vacancy { get; set; }
    public Guid? VacancyId { get; set; }

    public DateTime DataView { get; set; }

    public Employer Employer { get; set; }
    public Guid? EmployerId { get; set; }

    public Candidate Candidate { get; set; }
    public Guid? CandidateId { get; set; }

  }
}
