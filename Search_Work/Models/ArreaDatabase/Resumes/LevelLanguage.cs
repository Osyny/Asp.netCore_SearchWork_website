using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
  /// <summary>
  /// Рівень знання іноземних мов
  /// </summary>
    public class LevelLanguage
    {
      public Guid Id { get; set; }
      public string Name { get; set; }

      public List<ForeignLanguage> ForeignLanguages { get; set; }
  }
}
