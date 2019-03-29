using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ViewModel.Home.Company
{
    public class OpenVacancyCompanyViewModel
    {
        public string VacancyName { get; set; }
        public string FieldActivityName { get; set; }
        public int Salary { get; set; }
        public string CompanyName { get; set; }
        public string CityName { get; set; }

        public string Link { get; set; }
    }

    public class CompanyPageViewModel
    {
        public Guid CompanyId { get; set; }

        public string Name { get; set; }
        public string Site { get; set; }
        public string Description { get; set; }
        public string Linkedin { get; set; }
        public string CompanyLogoUrl { get; set; }

        public List<CityCompanyViewModel> Cities { get; set; }
        public Guid CityId { get; set; }

        public List<OpenVacancyCompanyViewModel> CompanyOpenVacancies { get; set; }

        public Guid SelectedFilterCity { get; set; }
    }

    public class CityCompanyViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
