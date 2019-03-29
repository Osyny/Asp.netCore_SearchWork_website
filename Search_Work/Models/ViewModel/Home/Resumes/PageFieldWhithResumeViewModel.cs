using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ViewModel.Home.Resumes
{

  public class PageFieldWhithResumeViewModel
  {
    public List<FieldActivityWhithViewModel> ResumesByFieldActivity { get; set; }
  }


  public class FieldActivityWhithViewModel
  {

    public int CountResumeByFieldActivity { get; set; }
    public Guid FieldActivityId { get; set; }
    public string FieldActivityName { get; set; }
  }

}