using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
  /// <summary>
  /// Владение программным обеспечением и технологиями
  /// </summary>
  public class SoftWare
  {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Resume Resume { get; set; }
    public Guid ResumeId { get; set; }

    public LevelTechnologyPossession LevelTechnologyPossession { get; set; }
    public Guid LevelTechnologyPossessionId { get; set; }
  }
}
