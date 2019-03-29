using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
    /// <summary>
    /// Форма обучения
    /// </summary>
    public class FormTraining
    {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<Education> Educations { get; set; }
  }
}
