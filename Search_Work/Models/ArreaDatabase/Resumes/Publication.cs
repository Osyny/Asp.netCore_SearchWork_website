using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
  /// <summary>
  /// Публікації
  /// </summary>
  public class Publication
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string SiteEdition { get; set; }

    public Resume Resume { get; set; }
    public Guid ResumeId { get; set; }
  }
}
