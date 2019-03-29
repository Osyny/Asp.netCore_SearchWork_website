using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Search_Work.Models.ArreaDatabase.Vacancies;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
    /// <summary>
    /// Відповідь на вакансію
    /// </summary>
    public class ResponseToVacancy
    {
      public Guid Id { get; set; }

      public Vacancy Vacancy { get; set; }
      public Guid VacancyId { get; set; }

      public Resume Resume { get; set; }
      public Guid ResumeId { get; set; }

    

      public DateTime DataResponse { get; set; }


    public Guid? ResponseTypeId { get; set; }
    public ResponseType ResponseType { get; set; }
  }
}
