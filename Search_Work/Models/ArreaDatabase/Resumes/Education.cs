using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
  /// <summary>
  /// Освіта
  /// </summary>
    public class Education
    {
      public Guid Id { get; set; }

      public string NameInstitution { get; set; }
      public string Specialization { get; set; }
      public string City { get; set; }
      
      public DateTime DateWorkFrom { get; set; }
      public DateTime DateWorkTo { get; set; }

      public Resume Resume { get; set; }
      public Guid ResumeId { get; set; }

      public LevelEducation LevelEducation { get; set; }
      public Guid LevelEducationId { get; set; }


      public FormTraining FormTraining { get; set; }
      public Guid FormTrainingId { get; set; }
  }
}
