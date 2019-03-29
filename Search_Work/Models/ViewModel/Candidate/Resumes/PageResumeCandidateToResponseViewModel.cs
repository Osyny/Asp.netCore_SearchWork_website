using Microsoft.AspNetCore.Mvc.Rendering;
using Search_Work.Models.ArreaDatabase.Resumes;
using Search_Work.Models.ArreaDatabase.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ViewModel.Candidate.Resumes
{
  public class PageResumeCandidateToResponseViewModel
  {
    public Search_Work.Models.ArreaDatabase.Candidate Candidate { get; set; }
    public Guid CandidateId { get; set; }

    public List<SelectListItem> Resumes { get; set; }
    public Guid ResumeId { get; set; }

    public Vacancy Vacancy { get; set; }
    public string VacancyName { get; set; }
    public Guid VacancyId { get; set; }
  }
}
