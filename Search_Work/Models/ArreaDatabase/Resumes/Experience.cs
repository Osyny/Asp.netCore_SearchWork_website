using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
    /// <summary>
    /// Досвід роботи
    /// </summary>
    public class Experience
    {
    public Guid Id { get; set; }
    public string NameOrganization { get; set; }
    public DateTime DateWorkFrom { get; set; }
    public DateTime DateWorkTo { get; set; }

    public DateTime YearsWork
    {

      get
      {
        var dif = (DateTime.Now - DateWorkFrom).Days;

        DateTime year = new DateTime().AddDays(dif);

        return year;
      }
    }

    public string Position { get; set; }

    public string Task { get; set; }
    public string Progres { get; set; }

    public Resume Resume { get; set; }
    public Guid ResumeId { get; set; }

    public EmploymentType Employment { get; set; }
    public Guid EmploymentId { get; set; }

    public bool IsWorkingNow { get; set; }
  }
}
