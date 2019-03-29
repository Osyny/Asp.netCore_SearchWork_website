using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ViewModel.Home
{
  public class HomePageViewModel
  {
    public List<VacancyFromTopCompanyViewModel> VacanciesFromTopCompanies { get; set; }

    public List<NewVacancyViewModel> NewVacancies { get; set; }

    public List<VacancyByFieldViewModel> VacanciesByFieldActivity { get; set; }

    public List<VacancyByCityViewModel> VacanciesByCity { get; set; }
  }

  public class NewVacancyViewModel
  {
    public Guid VacancyId { get; set; }
    public string VacancyName { get; set; }

    public string Post { get; set; }
    public int Salary { get; set; }
    public string CompanyName { get; set; }
    public string CityName { get; set; }
  }


  public class VacancyByFieldViewModel
  {
    public string FieldName { get; set; }

    public Guid FieldId { get; set; }
  }


  public class VacancyByCityViewModel
  {
    public string CityName { get; set; }

    public Guid CityId { get; set; }
  }


  public class VacancyFromTopCompanyViewModel
  {

    public Guid CompanyId { get; set; }
    public string CompanyName { get; set; }

    public string CompanyLogoUrl { get; set; }
    public string CompanyShortDesc { get; set; }


  }
}

