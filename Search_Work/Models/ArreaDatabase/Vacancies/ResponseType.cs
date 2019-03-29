using Search_Work.Models.ArreaDatabase.Resumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Vacancies
{
  /// <summary>
  /// 
  /// </summary>
    public class ResponseType
    {

    public Guid Id { get; set; }

    public ICollection<ResponseToVacancy> Responses { get; set; }
  }
}
