using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ViewModel.Home.Company
{
  public class PageFieldActivityWhithVacancyViewModel
  {
    public List<FieldActivityWhithViewModel> VacanciesByFieldActivity { get; set; }
  }

  public class FieldActivityWhithViewModel
  {

    public int CountVacancyByFieldActivity { get; set; }
    public Guid FieldActivityId { get; set; }
    public string FieldActivityName { get; set; }
  }
}
