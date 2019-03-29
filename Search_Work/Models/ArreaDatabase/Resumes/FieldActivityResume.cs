using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
  /// <summary>
  /// Проміжна таблиця - many to many  Сфера деятельности
  /// </summary>
  public class FieldActivityResume
  {
    public Guid Id { get; set; }
    public Guid FieldActivityId { get; set; }
    public FieldActivity FieldActivity { get; set; }

   
    public Guid ResumeId { get; set; }
    public Resume Resume { get; set; }

  }
}
