using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
  /// <summary>
  /// Рівень програмного забезпечення
  /// </summary>
    public class LevelTechnologyPossession
    {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<SoftWare> SoftWares { get; set; }
  }
}
