
using Search_Work.Models.ArreaDatabase;
using Search_Work.Models.ArreaDatabase.Resumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
  public class Resume
  {
    public Resume()
    {
      FieldActivities = new List<FieldActivityResume>();
      Experiences = new List<Experience>();
    }

    public Guid Id { get; set; }
    public string Name { get; set; }

    public string Foto { get; set; }
    public string Position { get; set; }
    public int Salary { get; set; }
    public DateTime DateCreate { get; set; }

    public DateTime DateChange { get; set; }

    public Guid CandidateId { get; set; }
    public Candidate Candidate { get; set; }


    public string Description { get; set; }

    public bool IsAnonymousResume { get; set; }
    public bool IsHideContact { get; set; }

    public bool IsActiveResume { get; set; }

    public List<ResponseToVacancy> Responses { get; set; }

    public List<ShowResume> ShowsResume { get; set; }

    public AditinalInfo AditinalInfo { get; set; }


    public ICollection<ImplementedProject> ImplementedProjects { get; set; }
    public ICollection<Education> Educations { get; set; }
    public ICollection<Experience> Experiences { get; set; }
    public ICollection<ForeignLanguage> ForeignLanguages { get; set; }
    public ICollection<TrainingAndCource> TrainingAndCources { get; set; }

    public ICollection<SoftWare> SoftWares { get; set; }
    public ICollection<Award> Awards { get; set; }
    public ICollection<Publication> Publications { get; set; }

   // public ICollection<Recomendation> Recomendations { get; set; }
    //public ICollection<Video> Videos { get; set; }
   // public ICollection<Documentation> Documentations { get; set; }

    public ICollection<ViewPage> ViewsPage { get; set; }
    public ICollection<SavedResume> SavedResumes { get; set; }



    // ------------------------ many to many ------------------------------------
    public ICollection<FieldActivityResume> FieldActivities { get; set; }

    // ------------------------------------------------------------

    
  }
}

