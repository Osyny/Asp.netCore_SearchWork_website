using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
  /// <summary>
  /// Діти
  /// </summary>
    public class Children
    {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<Candidate> Candidates { get; set; }
  }
}
