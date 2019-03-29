using Search_Work.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{/// <summary>
/// 
/// </summary>
    public class ResponseTypeToResume
    {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<ResponseToResume> Resumes { get; set; }
  }
}
