using Microsoft.AspNetCore.Mvc.Rendering;
using Search_Work.Models.ArreaDatabase;
using Search_Work.Models.ArreaDatabase.Resumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Candidate.Models
{
    public class PagePaternSearchVacancyViewModel
    {
        public Guid CandidateId { get; set; }
        public List<PaternSearchVacancyViewModel> Paterns { get; set; }
    }

    public class PaternSearchVacancyViewModel
    {
        public Guid Id { get; set; }

        public string Request { get; set; }
        public int Salary { get; set; }

        public Guid CityId { get; set; }
        public string CityName { get; set; }

        public Guid FieldActivity { get; set; }
        public string FieldActivityName { get; set; }

        // public Guid EmploymentId { get; set; }
        //public string Employment { get; set; }

        //public Guid ExperienceOfWorkId { get; set; }
        //public string ExperienceOfWork { get; set; }

        //ToDo Period ???????????
        public string Period { get; set; }

        public string LinkToResume { get; set; }

        public int Count { get; set; }
    }

    public class AddPaternSearchVacancyViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public string Request { get; set; }
        public int Salary { get; set; }

        public List<SelectListItem> Cities { get; set; }
        public Guid CityId { get; set; }

        public List<SelectListItem> FieldActivity { get; set; }
        public Guid FieldActivityId { get; set; }

        public List<SelectListItem> Employments { get; set; }
        public Guid EmploymentId { get; set; }

        public List<SelectListItem> ExperienceOfWorks { get; set; }
        public Guid ExperienceOfWorkId { get; set; }
    }
}
