using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
  /// <summary>
  /// Семейное положение
  /// </summary>
  public class FamilyStatus
    {

    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<Candidate> Candidates { get; set; }
  }
}
