using Search_Work.Models.ArreaDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
    /// <summary>
    /// Реализованные проекты
    /// </summary>
    public class ImplementedProject
    {
      public Guid Id { get; set; }
      public string NameProgect { get; set; }
      public DateTime DateWorkFrom { get; set; }
      public DateTime DateWorkTo { get; set; }

      public string LinkToProgect { get; set; }

      public Resume Resume { get; set; }
      public Guid ResumeId { get; set; }
    }
}
