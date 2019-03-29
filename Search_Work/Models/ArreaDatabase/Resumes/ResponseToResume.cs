using Search_Work.Models.ArreaDatabase.Resumes;
using Search_Work.Models.ArreaDatabase.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
  public class ResponseToResume
  {
    public Guid Id { get; set; }

    public Vacancy Vacancy { get; set; }
    public Guid VacancyId { get; set; }

    //public Employer Employer { get; set; }
    //public Guid EmplloyerId { get; set; }


    public Resume Resume { get; set; }
    public Guid ResumeId { get; set; }

    public DateTime DataResponse { get; set; }

    public Guid? ResponseTypeToResumeId { get; set; }
    public ResponseTypeToResume ResponseTypeToResume { get; set; }
  }
}