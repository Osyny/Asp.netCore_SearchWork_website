using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase.Resumes
{
    public class ShowResume
    {
    public Guid Id { get; set; }

    public Resume Resume { get; set; }
    public Guid ResumeId { get; set; }
  }
}
