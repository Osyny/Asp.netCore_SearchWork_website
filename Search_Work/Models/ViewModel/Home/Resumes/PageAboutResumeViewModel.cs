using Search_Work.Models.ArreaDatabase.Resumes;
using Search_Work.Models.ViewModel.Candidate.Resumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ViewModel.Home.Resumes
{
    public class PageAboutResumeViewModel
    {
        public string NameCanditate { get; set; }
        public DateTime DataCriate { get; set; }

        public string ResumeName { get; set; }
        public Guid ResumeId { get; set; }

        public bool IsAnonimus { get; set; }
        public Guid? VacancyId { get; set; }
        public Guid? EmpViewId { get; set; }

        public int Wage { get; set; }
        public DateTime Birthday { get; set; }


        public string Foto { get; set; }
        //  public List<VideoPresentationViewModel> VideoPresentations { get; set; }
        public string Age
        {
            get
            {

                var dif = (DateTime.Now - Birthday).Days;

                DateTime year = new DateTime().AddDays(dif);

                return year.ToString("yy");
            }
        }


        public string CityName { get; set; }


        public string FamilyStatus { get; set; }
        public string Children { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string Linkedin { get; set; }
        public string Fasebook { get; set; }

        public string TypeEmployment { get; set; }

        public ICollection<EducationViewModel> Educations { get; set; }
        public ICollection<ExperienceViewModel> Experiences { get; set; }
        public List<ImplementedProjectViewModel> ImplementProjects { get; set; }
        public List<RecomendationViewModel> Recomendations { get; set; }

        public List<ForeignLanguageViewModel> ForeignLanguages { get; set; }
        public List<TrainingAndCourceViewMopdel> TrainingAndCources { get; set; }
        public List<SoftwareViewModel> Softwares { get; set; }
        public List<AwardViewModel> Awards { get; set; }
        public List<PublicationViewModel> Publications { get; set; }
        public List<DocumentationViewModel> Documentations { get; set; }


        public List<SimilarResumeViewModel> SimilarResume { get; set; }
    }

    public class SimilarResumeViewModel
    {

        public Guid Id { get; set; }
        public string ResumeName { get; set; }
        public int Salary { get; set; }

        public DateTime Birthday { get; set; }

        public string Age
        {
            get
            {

                var dif = (DateTime.Now - Birthday).Days;

                DateTime year = new DateTime().AddDays(dif);

                return year.ToString("yy"); //(year.Year).ToString();
            }
        }

        public string CityName { get; set; }
        public string Education { get; set; }
        public EmploymentType TypeEmployment { get; set; }

        public string Link { get; set; }

    }
}
