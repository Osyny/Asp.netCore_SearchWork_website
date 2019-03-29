using Search_Work.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Employer.Models
{
    public class PageResumeViewModel
    {
        public Guid VacancyId { get; set; }
        public string VacancyName { get; set; }

        public string CompanyName { get; set; }
        public List<ResumesResponseToVacancyViewModel> Resumes { get; set; }

        public CataloguePaginationViewModel Pagination { get; set; }

        public Guid EmployerId { get; set; }
        public int CurrentPage { get; set; }
    }

    public class ResumesResponseToVacancyViewModel
    {
        public Guid Id { get; set; }

        public Guid SavedResumeId { get; set; }
        public string NameResume { get; set; }

        public string ActionWhithFavorite { get; set; }
        public bool IsCheced { get; set; }

        public string FotoUrl { get; set; }

        public string VideoUrl { get; set; }
        public int Salary { get; set; }

        public DateTime Birthday { get; set; }
        public Guid? StatusId { get; set; }

        public string Age
        {
            get
            {
                var dif = (DateTime.Now - Birthday).Days;

                DateTime year = new DateTime().AddDays(dif);

                return year.ToString("yy");
            }
        }

        public DateTime Date { get; set; }

        public List<CityNameViewModel> Cities { get; set; }

        public string LinkPageResum { get; set; }

        public string ChekedFavorites { get; set; }


    }

    public class Page2ResumeViewModel
    {
        public Guid VacancyId { get; set; }
        public string VacancyName { get; set; }

        public string CompanyName { get; set; }
        public List<ResumeViewModel> Resumes { get; set; }

        public CataloguePaginationViewModel Pagination { get; set; }

        public Guid EmployerId { get; set; }
        public int CurrentPage { get; set; }
    }
}
