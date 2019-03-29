using Search_Work.Models.ArreaDatabase;
using Search_Work.Models.ArreaDatabase.Resumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models
{
  /// <summary>
  /// Додаткова інформація
  /// </summary>
    public class AditinalInfo
    {
    public Guid Id { get; set; }
    public string Text { get; set; }

    public Resume Resume { get; set; }
  }
}
