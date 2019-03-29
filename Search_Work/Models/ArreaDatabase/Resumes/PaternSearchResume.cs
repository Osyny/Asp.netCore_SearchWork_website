using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
  /// <summary>
  /// Шаблон пошуку резюме
  /// </summary>
    public class PaternSearchResume
    {
    public Guid Id { get; set; }

    public string Request { get; set; }
    public int Salary { get; set; }

    public Guid City { get; set; }

    public Guid FieldActivity { get; set; }

    public Guid Education { get; set; }

    public Guid Employment { get; set; }

    public Guid ExperienceOfWork { get; set; }



    public bool IsInName { get; set; }
    public bool IsLiteTestPassed { get; set; }
  }
}
