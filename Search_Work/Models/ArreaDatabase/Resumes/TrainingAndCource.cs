using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
  /// <summary>
  /// Тренінги і курси
  /// </summary>
    public class TrainingAndCource
    {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int NumberCertification { get; set; }

    public Resume Resume { get; set; }
    public Guid ResumeId { get; set; }
  }
}
