using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Search_Work.Models;
using Search_Work.Models.ArreaDatabase;
using Search_Work.Models.ArreaDatabase.Resumes;
using Search_Work.Models.ArreaDatabase.Vacancies;

namespace Search_Work.Data
{
    public class oxana1404 : IdentityDbContext<ApplicationUser>
    {
        public oxana1404(DbContextOptions<oxana1404> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Employer> Employers { get; set; }
    
      public DbSet<Contact> Contacts { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public DbSet<FieldActivity> FieldActivities { get; set; }
    public DbSet<Vacancy> Vacancies { get; set; }
    public DbSet<Resume> Resumes { get; set; } 

    public DbSet<FieldActivityResume> FieldsActivityResume { get; set; }

    public DbSet<ResponseToVacancy> ResponsesToVacancy { get; set; }
    public DbSet<ResponseType> ResponsesType { get; set; }

    public DbSet<ResponseToResume> ResponsesToResume { get; set; }
    public DbSet<ResponseTypeToResume> ResponsesTypeToResume { get; set; }


    public DbSet<FamilyStatus> FamilyStatuses { get; set; }
    public DbSet<Children> Childrens { get; set; }

    public DbSet<FormTraining> FormTrainings { get; set; }
    public DbSet<LevelLanguage> LevelLanguages { get; set; }
    public DbSet<LevelTechnologyPossession> LevelTechnologyPossessions { get; set; }

    public DbSet<LevelEducation> LevelEducations { get; set; }
    public DbSet<EmploymentType> Employments { get; set; }


    public DbSet<Education> Educations { get; set; }
    public DbSet<ForeignLanguage> ForeignLanguages { get; set; }

    public DbSet<Experience> Experiences { get; set; }
    public DbSet<ImplementedProject> ImplementedProjects { get; set; }
    public DbSet<TrainingAndCource> TrainingAndCources { get; set; }
    public DbSet<SoftWare> SoftWares { get; set; }
    public DbSet<Award> Awards { get; set; }
    public DbSet<Publication> Publications { get; set; }

    //public DbSet<Recomendation> Recomendations { get; set; }
    //public DbSet<Video> Videos { get; set; }
    //public DbSet<Documentation> Documentations { get; set; }

    public DbSet<AditinalInfo> AditinalInfos { get; set; }

    public DbSet<ViewPage> ViewsPages { get; set; }

    public DbSet<ShowResume> ShowsResume { get; set; }
    public DbSet<SavedResume> SavedResumes { get; set; }

    public DbSet<SavedVacancy> SavedVacancies { get; set; }

    public DbSet<RecommendedVacancy> RecommendedVacancies { get; set; }

    public DbSet<ExperienceOfWork> ExperienceOfWorks { get; set; }
    public DbSet<PaternSearchResume> PaternSearchResumes { get; set; }

    public DbSet<PaternSearchVacancy> PaternSearchVacancies { get; set; }
   
  }
}
