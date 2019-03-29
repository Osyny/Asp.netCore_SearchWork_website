using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ViewModel.Menu
{
    public class MenuViewModel
  {
    public List<TopMenuLinkViewModel> Links { get; set; }
  }

  public class TopMenuLinkViewModel
  {
    public string Name { get; set; }
    public string Link { get; set; }
  }

}
