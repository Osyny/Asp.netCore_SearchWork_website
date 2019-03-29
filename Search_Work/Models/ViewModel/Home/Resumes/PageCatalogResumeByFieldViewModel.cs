using Search_Work.Models.ArreaDatabase.Resumes;
using Search_Work.Models.Pagination;
using Search_Work.Models.ViewModel.Candidate.Resumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ViewModel.Home.Resumes
{
    public class PageCatalogResumeByFieldViewModel
    {
    public string FialdActivityName { get; set; }

    public Int32 CountResumeByFieldActivity { get; set; }

    public List<PageResumeByFieldViewModel> ResumesByField { get; set; }

    public CataloguePaginationViewModel Pagination { get; set; }


    public Guid FieldId { get; set; }
    public int CurrentPage { get; set; }

    public string SelectedFilter { get; set; }
    public string TypeSortFilter { get; set; }
  }

  public class PageResumeByFieldViewModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
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

    public List<CityViewModel> Cities { get; set; }
    public List<EducationViewModel> Educations { get; set; }

    public EmploymentType TypeEmployment { get; set; }
    public string FotoUrl { get; set; }
    public string VideoUrl { get; set; }

    public DateTime DateCreate { get; set; }

    public string Description { get; set; }
    public string LinkPageResum { get; set; }

  }

  public class CityViewModel
  {
    public Guid Id { get; set; }
    public string CityName { get; set; }
  }
}
   