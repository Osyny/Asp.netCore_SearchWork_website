using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.Pagination
{
    public class CataloguePaginationViewModel
    {
    public int TotalCount { get; set; }

    public int CurrentPage { get; set; }

    public int DisplayOnPage { get; set; } = 5;

    public string ActionName { get; set; }
    public string ControllerName { get; set; }

    public Dictionary<string, string> ObjectParameter { get; set; }
  }
}
