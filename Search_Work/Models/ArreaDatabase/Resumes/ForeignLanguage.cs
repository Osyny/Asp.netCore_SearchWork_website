using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
  /// <summary>
  /// Знание иностранных языков
  /// </summary>
    public class ForeignLanguage
    {
      public Guid Id { get; set; }
      public string Name { get; set; }
     
      public LevelLanguage LevelLanguage { get; set; }
      public Guid LevelLanguageId { get; set; }


      public Resume Resume { get; set; }
      public Guid ResumeId { get; set; }
  }
}
