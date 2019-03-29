using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Search_Work.Data;
using Search_Work.Models.ArreaDatabase;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Search_Work.Arrea.Candidate.Models;

namespace Search_Work.Arrea.Employer
{
    public class CompaniesController : Controller
    {
        private readonly oxana1404 _context;
        private IHostingEnvironment _environment;

        public CompaniesController(oxana1404 context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            var oxana1404 = _context.Companies.Include(c => c.City);
            return View(await oxana1404.ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(Guid? id, Guid? empId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = _context.Employers.Include(e => e.Company).ThenInclude(c => c.Employers)
              .Include(e => e.AccountUser).FirstOrDefault(e => e.Id == empId);
            if (empId != null)
                ViewBag.EmpId = emp.Id;

            var company = await _context.Companies
                      .Include(c => c.City)
                      .Include(c => c.Employers)
                      .SingleOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create(Guid? Id)
        {

            var emp = _context.Employers.Include(e => e.Company)
              .Include(e => e.AccountUser).FirstOrDefault(e => e.Id == Id);
            var cities = _context.Cities.Count();

            ViewBag.EmpId = emp.Id;

            ViewData["CityName"] = new SelectList(_context.Cities, "Id", "Name");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CityId,Requirements,Description,PhoneNumber,Email,Site,Facebook,Adress")] Company company, IFormFile Image, Guid? Id)
        {

            var emp = _context.Employers.Include(e => e.Company).ThenInclude(c => c.City)
              .Include(e => e.AccountUser).FirstOrDefault(e => e.Id == Id);
            //if (ModelState.IsValid)
            {
                company.Id = Guid.NewGuid();

                var files = HttpContext.Request.Form.Files;
                if (Image != null)
                {
                    string name = Image.FileName;
                    string path = $"/files/{name}";
                    string serverPath = $"{_environment.WebRootPath}{path}";
                    FileStream fs = new FileStream(serverPath, FileMode.Create,
                        FileAccess.Write);
                    await Image.CopyToAsync(fs);
                    fs.Close();
                    company.CompanyLogoUrl = path;
                }
                company.Employers.Add(emp);

                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", company.CityId);
            return View(company);
        }

        // GET: Companies/Edit/5
        //public IActionResult Edit(Guid? id, Guid? empId)
        //{

        //  var emp = _context.Employers.Include(e => e.Company).ThenInclude(c => c.Employers)
        //    .Include(e => e.AccountUser).FirstOrDefault(e => e.Id == empId);

        //  if (empId != null)
        //    ViewBag.EmpId = emp.Id;

        //  if (id == null)
        //  {
        //    return NotFound();
        //  }

        //  var company = _context.Companies.Include(c => c.City)
        //  .Include(c => c.Employers).FirstOrDefault(m => m.Id == id);
        //  ICollection<Models.ArreaDatabase.Employer> i = company.Employers;
        //  ViewBag.CompanyEmployers = i;

        //  if (company == null)
        //  {
        //    return NotFound();
        //  }

        //  //var model = new CandidateViewModel()
        //  //{
        //  //  Company = company,
        //  //  EmployeeId = emp

        //  //};

        //  ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", company.CityId);
        //  return View(company);
        //}

        public IActionResult Edit(Guid? id, Guid? empId)
        {

            var emp = _context.Employers.Include(e => e.Company).ThenInclude(c => c.Employers)
              .Include(e => e.AccountUser).FirstOrDefault(e => e.Id == empId);

            if (empId != null)
                ViewBag.EmpId = emp.Id;

            if (id == null)
            {
                return NotFound();
            }

            var company = _context.Companies.Include(c => c.City)
            .Include(c => c.Employers)
            .FirstOrDefault(m => m.Id == id);

            var employers = company.Employers.ToList();
            // ViewBag.CompanyEmployers = i;

            if (company == null)
            {
                return NotFound();
            }

            var cities = _context.Cities.Include(c => c.Companies).Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name

            }).ToList();

            var model = new CompanyEditViewModel()
            {
                Id = company.Id,
                CompanyName = company.Name,
                EmployeeId = emp.Id,

                CompanyLogo = company.CompanyLogoUrl,
                CityName = company.City?.Name,
                Cities = cities,

                Description = company.Description,
                Email = company.Email,
                Facebook = company.Facebook,
                Site = company.Site,
                PhoneNumber = company.PhoneNumber,
                Employers = employers,
                Adress = company.Adress,

                Status = company.Status == null ? false : company.Status.Value

            };

            // ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", company.CityId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CompanyEditViewModel model, IFormFile Image)
        {
            var companyUpdate = _context.Companies.Include(c => c.City)
           .Include(c => c.Employers).FirstOrDefault(m => m.Id == model.Id);

            var emplCompany = companyUpdate.Employers.FirstOrDefault(e => e.Id == model.EmployeeId);
            var city = _context.Cities.Include(c => c.Companies)
              .FirstOrDefault(c => c.Id == model.CityId);

            //if (ModelState.IsValid)
            {
                Search_Work.Models.ArreaDatabase.Employer emp = null;
                try
                {
                    if (Image != null)
                    {
                        string name = Image.FileName;
                        string path = $"/files/{name}";
                        string serverPath = $"{_environment.WebRootPath}{path}";
                        FileStream fs = new FileStream(serverPath, FileMode.Create,
                            FileAccess.Write);
                        await Image.CopyToAsync(fs);
                        fs.Close();
                        companyUpdate.CompanyLogoUrl = path;
                    }

                    emp = _context.Employers.Include(e => e.Company)
                                   .Include(e => e.AccountUser).FirstOrDefault(e => e.Id == model.EmployeeId);


                    //     if(companyEmployers == null)
                    if (!companyUpdate.Employers.Contains(emp))
                    {

                        companyUpdate.Employers.Add(emp);

                    }


                    companyUpdate.Name = model.CompanyName;
                    companyUpdate.City = city;
                    //companyUpdate.Requirements = model.Re
                    companyUpdate.Description = model.Description;
                    companyUpdate.PhoneNumber = model.PhoneNumber;
                    companyUpdate.Email = model.Email;
                    companyUpdate.Site = model.Site;
                    companyUpdate.Facebook = model.Facebook;
                    companyUpdate.Adress = model.Adress;
                    // companyUpdate.Employers = model.Employers;

                    if ((companyUpdate.Status == false && model.Status == true) ||
                        (companyUpdate.Status == true && model.Status == false))
                    {
                        companyUpdate.Status = model.Status;
                    }

                    _context.Companies.Update(companyUpdate);
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Details), new { id = companyUpdate.Id, empId = emplCompany.Id });

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(companyUpdate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        //return RedirectToAction("Logout", "Account");
                        return RedirectToAction(nameof(Details), new { id = companyUpdate.Id, empId = emplCompany.Id });
                    }
                }
                //return RedirectToAction(nameof(Details), new { id = company.Id, empId = empId });
            }
            // return RedirectToAction(nameof(Details), new { id = companyUpdate.Id, empId = emplCompany.Id });

        }
        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,CityId,Description,PhoneNumber,Email,Site,Facebook,Adress, Employers")] Company comp, IFormFile Image, Guid? empId, ICollection<Models.ArreaDatabase.Employer> cE)
        //{
        // // var company = _context.Companies.Include(c => c.City)
        // //.Include(c => c.Employers).FirstOrDefault(m => m.Id == id);


        //  if (id != comp.Id)
        //  {
        //    return NotFound();
        //  }

        //  //if (ModelState.IsValid)
        //  {
        //    Models.ArreaDatabase.Employer emp = null;
        //    try
        //    {
        //      if (Image != null)
        //      {
        //        string name = Image.FileName;
        //        string path = $"/files/{name}";
        //        string serverPath = $"{_environment.WebRootPath}{path}";
        //        FileStream fs = new FileStream(serverPath, FileMode.Create,
        //            FileAccess.Write);
        //        await Image.CopyToAsync(fs);
        //        fs.Close();
        //        comp.CompanyLogoUrl = path;
        //      }
        //      if (empId != null)
        //      {
        //        emp = _context.Employers.Include(e => e.Company)
        //                       .Include(e => e.AccountUser).FirstOrDefault(e => e.Id == empId);
        //        //var comp = _context.Companies.Include(c => c.City)
        //        //  .Include(c => c.Employers).FirstOrDefault(c => c.Id == company.Id);
        //        //var empCompany = emp.Company  //comp.Employers.FirstOrDefault(c => c.Id == emp.Id);

        //   //     if(companyEmployers == null)
        //        if (!comp.Employers.Contains(emp))
        //        {

        //          comp.Employers.Add(emp);

        //        }

        //      }
        //     // comp. = comp;
        //      //_context.Companies.Update(comp);
        //      await _context.SaveChangesAsync();

        //      return RedirectToAction(nameof(Details), new { id = comp.Id, empId = empId });

        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //      if (!CompanyExists(comp.Id))
        //      {
        //        return NotFound();
        //      }
        //      else
        //      {
        //        throw;
        //      }
        //    }
        //    //return RedirectToAction(nameof(Details), new { id = company.Id, empId = empId });
        //  }
        //  ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", comp.CityId);
        //  return View(comp);

        //}

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .Include(c => c.City)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var company = await _context.Companies.SingleOrDefaultAsync(m => m.Id == id);
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(Guid id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
