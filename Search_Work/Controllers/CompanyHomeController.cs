using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Search_Work.Data;
using Search_Work.Models.ArreaDatabase.Vacancies;
using Search_Work.Models.Pagination;
using Search_Work.Models.ViewModel.Home.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Controllers
{
    public class CompanyHomeController : Controller
    {
        private oxana1404 dbContext;
        public CompanyHomeController(oxana1404 dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// AboutCompany
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public ActionResult AboutCompany(Guid? companyId, Guid cityId)
        {

            //cityId = Guid.Empty;

            // Vacancies


            var company = dbContext.Companies.FirstOrDefault(c => c.Id == companyId);

            var companyOpenVacancies = new List<OpenVacancyCompanyViewModel>();


            var vacanciesFilterOpen = dbContext.Vacancies
              .Include(v => v.City).Include(v => v.FieldActivity)
              .Include(v => v.Employer).ThenInclude(e => e.Company)
              .Where(x => x.Employer.Company.Id == companyId).Where(v => v.IsActive).OrderByDescending(v => v.DatePublication);//.GetVacancies(companyId).Where(v => v.IsActive).ToList();

            IEnumerable<Vacancy> vacancies = null;

            if (cityId != Guid.Empty)
            {
                vacancies = vacanciesFilterOpen.Where(r => r.CityId == cityId);
            }
            else
            {
                vacancies = vacanciesFilterOpen;
            }

            companyOpenVacancies.AddRange(vacancies.Take(6).Select(vacancy => new OpenVacancyCompanyViewModel()
            {
                VacancyName = vacancy.Name,
                CompanyName = company.Name,
                CityName = vacancy.City.Name,
                Salary = vacancy.Wage,
                FieldActivityName = vacancy.FieldActivity.Name,
                Link = Url.Action("AboutVacancy", "Vacancy", new { vacancyId = vacancy.Id }),
            }));


            var allCity = dbContext.Cities;
            var cities = new List<CityCompanyViewModel>();
            cities.AddRange(allCity.Select(city => new CityCompanyViewModel()
            {
                Name = city.Name,
                Id = city.Id
            }));



            var model = new CompanyPageViewModel()
            {

                CompanyOpenVacancies = companyOpenVacancies,
                Name = company.Name,
                Site = company.Site,
                // Linkedin = company.Linkedin,
                Description = company.Description,
                Cities = cities,
                CompanyId = companyId.Value,
                CityId = cityId,

                SelectedFilterCity = cityId,

                //toDo LogoUrl  
                CompanyLogoUrl = company.CompanyLogoUrl
            };


            return View("/Views/Home/HomeVacancy/AboutCompany.cshtml", model);
        }

        public ActionResult CompaniesByFieldActivity()
        {

            var fieldsActivity = dbContext.FieldActivities.ToList();

            var companiesByFieldActivity = new List<FieldActivityWhithByCompanyViewModel>();

            companiesByFieldActivity.AddRange(fieldsActivity.Select(fieldActivity => new FieldActivityWhithByCompanyViewModel()
            {
                FieldActivityId = fieldActivity.Id,
                FieldActivityName = fieldActivity.Name
            }));

            var model = new PageCompaniesByFeldViewModel()
            {
                CompaniesByFeld = companiesByFieldActivity
            };
            return View("/Views/Home/HomeCompany/PageCompaniesByFeld.cshtml", model);
        }


        [HttpGet]
        public ActionResult CompanyCatalogByActivityField(Guid fieldActivityId, int currentPage = 1,
                bool isShowOnlyActive = false)
        {

            //var res = this.dbset.Where(x => x.Employers.Any(empl => empl.Vacancies
            //        .FirstOrDefault(vac => vac.FieldActivityId != fieldActivityId
            //        || !isOnlyWithActiveVacancies || vac.IsActive == isOnlyWithActiveVacancies) != null)


            var companies = dbContext.Companies.Include(c => c.Employers).ThenInclude(v => v.Vacancies).ThenInclude(v => v.FieldActivity)
      .Where(c => c.Employers.Any(empl => empl.Vacancies
          .Where(vac => vac.FieldActivity.Id == fieldActivityId
          || vac.IsActive == isShowOnlyActive) != null) && c.Status == true);


            dbContext.FieldActivities.Load();
            dbContext.Vacancies.Load();

            // companyRepo.GetCompanyByFieldActivity(fieldActivityId, isShowOnlyActive);
            var fieldActivity = dbContext.FieldActivities.Include(f => f.Vacancies)
                                   .Include(f => f.Resumes).FirstOrDefault(x => x.Id == fieldActivityId);

            var companyVacancies = new List<CompanyByFieldActivityViewModel>();

            const int skipCount = 6;
            Decimal decCompaniesInFieldActivityCount = companies.Count();
            Decimal decCountPages = Math.Ceiling(decCompaniesInFieldActivityCount / skipCount);

            int countPages = Decimal.ToInt32(decCountPages);
            int companiesInFieldActivityCount = Decimal.ToInt32(decCompaniesInFieldActivityCount);

            if (currentPage > countPages)
            {
                currentPage = 1;
            }



            companyVacancies.AddRange(companies.OrderBy(x => x.Name)
                .Skip(skipCount * currentPage - skipCount)
                .Take(skipCount)
                .ToList()
                .Select(company => new CompanyByFieldActivityViewModel()
                {
                    СompanyId = company.Id,
                    CompanyName = company.Name,
                    CompanyLogoUrl = company.CompanyLogoUrl,
                    // Todo погано рахує VacancyCount
                    VacancyCount = dbContext.Vacancies.Include(i => i.Employer).ThenInclude(i => i.Company)
                    .Include(i => i.FieldActivity)
                            .Where(v => v.FieldActivity.Id == fieldActivityId
                                           && v.Employer.Company.Id == company.Id
                                           && v.IsActive == isShowOnlyActive).Count()
                }));


            var paginationViewModel = new CataloguePaginationViewModel()
            {
                CurrentPage = currentPage,
                DisplayOnPage = skipCount,
                TotalCount = countPages,
                ActionName = "CompanyCatalogByActivityField",
                ControllerName = "CompanyHome",
                ObjectParameter = new Dictionary<string, string> {
                {
                    "fieldActivityId", fieldActivityId.ToString()
                }}
            };


            var model = new CompaniesPageByFieldActivityViewModel()
            {
                FialdActivityName = fieldActivity.Name,
                CompaniesByFieldActivity = companyVacancies,
                ActivityInCategoryCount = companiesInFieldActivityCount,
                Pagination = paginationViewModel,
                IsShowOnlyActive = isShowOnlyActive
            };
            return View("/Views/Home/HomeCompany/CompanyCatalogByActivityField.cshtml", model);
            // return Ok();

        }
    }
}
