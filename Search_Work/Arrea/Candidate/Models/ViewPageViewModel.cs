using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Candidate.Models
{

  public class PageViewsListViewModel
  {
    public string ResumeName { get; set; }
    public List<ViewPageViewModel> Views { get; set; }
  }

  public class ViewPageViewModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string Date { get; set; }

  }
}
