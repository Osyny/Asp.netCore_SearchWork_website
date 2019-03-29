using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
  /// <summary>
  /// Збережені резюме COMPANY
  /// </summary>
  public class SavedResume
  {
    public Guid Id { get; set; }


    public DateTime DateSaved { get; set; }

    //public Company Company { get; set; }
    //public Guid CompanyId { get; set; }

    public Employer Employer { get; set; }
    public Guid EmployerId { get; set; }


    public Resume Resume { get; set; }
    public Guid ResumeId { get; set; }
  }
}
