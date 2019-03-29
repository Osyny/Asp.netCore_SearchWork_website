using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Employer.Models
{
  public class ResumeViewModel
  {
    public Guid Id { get; set; }

    public Guid SavedResumeId { get; set; }
    public string NameResume { get; set; }

    public string ActionWhithFavorite { get; set; }
    public bool IsCheced { get; set; }

    public string FotoUrl { get; set; }

    public string VideoUrl { get; set; }
    public int Salary { get; set; }

    public DateTime Birthday { get; set; }


    public string Age
    {
      get
      {
        var dif = (DateTime.Now - Birthday).Days;

        DateTime year = new DateTime().AddDays(dif);

        return year.ToString("yy");
      }
    }

    public DateTime Date { get; set; }

    public List<CityNameViewModel> Cities { get; set; }

    public string LinkPageResum { get; set; }

    public string ChekedFavorites { get; set; }


  }
  public class CityNameViewModel
  {
    public string CityName { get; set; }
  }
}
