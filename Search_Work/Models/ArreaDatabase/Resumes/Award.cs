using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
  /// <summary>
  /// Награды
  /// </summary>
  public class Award
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string SiteUrlEdition { get; set; }

    public Resume Resume { get; set; }
    public Guid ResumeId { get; set; }
  }
}
