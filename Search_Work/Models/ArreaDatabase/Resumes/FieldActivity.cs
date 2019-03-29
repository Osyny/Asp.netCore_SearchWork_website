using Search_Work.Models.ArreaDatabase.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
  /// <summary>
  /// Сфера діяльності
  /// </summary>
  public class FieldActivity
  {

    public FieldActivity()
    {
      Resumes = new List<FieldActivityResume>();
    }
    public Guid Id { get; set; }
    public string Name { get; set; }


    public ICollection<Vacancy> Vacancies { get; set; }
    //public PaternSearch PaternSearch { get; set; }

  

    //// ---------------------------- RESUME - many to many --------------------------------
   
    public ICollection<FieldActivityResume> Resumes { get; set; }

  
  }
}
