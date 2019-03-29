using Search_Work.Models.ArreaDatabase.Resumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ViewModel.Home.Company
{
    public class PageAboutVacncyViewModel
    {
        public DateTime DateCriate { get; set; }
        public string VacancyName { get; set; }
        public string FieldActivityName { get; set; }
        public Guid VacancyId { get; set; }

        public int Wage { get; set; }
        public string CompanyLogoUrl { get; set; }
        public string CompanyName { get; set; }

        public string LinkAllVacancyThisCompany { get; set; }

        public string CityName { get; set; }

        public string TypeEmployment { get; set; }

        public string ExperienceOfWork { get; set; }


        //public Employment TypeEmployment { get; set; }

        //public ExperienceOfWork ExperienceOfWork { get; set; }

        public string ContactPerson { get; set; }
        public string PhoneNumberPerson { get; set; }
        public string EmailPerson { get; set; }



        public string Site { get; set; }
        public string Linkedin { get; set; }
        public string Fasebook { get; set; }

        public string Description { get; set; }
        public string Requirement { get; set; }
        public string Responsibilities { get; set; }
        public string ForeignLanguages { get; set; }
        public string AdditionalRequirements { get; set; }



        public List<SimilarVacanciesViewModel> SimilarVacancies { get; set; }

        public Search_Work.Models.ArreaDatabase.Candidate Candidate { get; set; }
    }



    public class SimilarVacanciesViewModel
    {

        public Guid Id { get; set; }
        public string VacancyName { get; set; }


        public EmploymentType TypeEmployment { get; set; }
        public int Salary { get; set; }
        public string CompanyName { get; set; }
        public string CityName { get; set; }

        public string Link { get; set; }
    }
}

