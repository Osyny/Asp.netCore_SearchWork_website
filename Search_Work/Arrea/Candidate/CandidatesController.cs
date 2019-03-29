using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Search_Work.Data;
using Search_Work.Models.ArreaDatabase;

namespace Search_Work.Arrea.Candidate
{
    public class CandidatesController : Controller
    {
        private readonly oxana1404 _context;
        private IHostingEnvironment _environment;

        public CandidatesController(oxana1404 context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            var oxana1404 = _context.Candidates.Include(c => c.City).Include(c => c.AccountUser)
          .Include(c => c.FamilyStatus).Include(c => c.Children);
            return View(await oxana1404.ToListAsync());
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = _context.Candidates.Include(c => c.City).Include(c => c.AccountUser)
          .Include(c => c.FamilyStatus).Include(c => c.Children)
                    .FirstOrDefault(m => m.Id == id);

            var userName = HttpContext.User.Identity.Name;
            //var user = _userManager.Users.FirstOrDefault(i => i.Email == userName);

            var cand = _context.Candidates.Include(c => c.City).Include(c => c.AccountUser)
                    .Where(c => c.AccountUser.UserName == userName);

            var canId = cand.Select(i => i.Id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            //ViewData["SexId"] = new SelectList(_context.Se, "Id", "Name");
            ViewData["FamilyStatusId"] = new SelectList(_context.FamilyStatuses, "Id", "Name");
            ViewData["ChildrenId"] = new SelectList(_context.Childrens, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,Name,Surname,Sex,Birthday,CityId,Country,Region,Street,ApartmentNumber,PhoneNumber,Email,Skype,Facebook,FamilyStatusId, ChildrenId")] Search_Work.Models.ArreaDatabase.Candidate candidate, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                candidate.Id = Guid.NewGuid();

                if (Image != null)
                {
                    string name = Image.FileName;
                    string path = $"/files/{name}";
                    string serverPath = $"{_environment.WebRootPath}{path}";
                    FileStream fs = new FileStream(serverPath, FileMode.Create,
                        FileAccess.Write);
                    await Image.CopyToAsync(fs);
                    fs.Close();
                    candidate.Avatar = path;
                }

                _context.Add(candidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Edit), new { id = candidate.Id });
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", candidate.CityId);
            ViewData["FamilyStatusId"] = new SelectList(_context.FamilyStatuses, "Id", "Name");
            ViewData["ChildrenId"] = new SelectList(_context.Childrens, "Id", "Name");
            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates.SingleOrDefaultAsync(m => m.Id == id);
            if (candidate == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", candidate.CityId);
            ViewData["FamilyStatusId"] = new SelectList(_context.FamilyStatuses, "Id", "Name");
            ViewData["ChildrenId"] = new SelectList(_context.Childrens, "Id", "Name");
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Avatar,LastName,Name,Surname,Sex,Birthday,CityId,Country,Region,Street,ApartmentNumber,PhoneNumber,Email,Skype,Facebook")] Search_Work.Models.ArreaDatabase.Candidate candModel, IFormFile Image)
        {
            var upCand = _context.Candidates.Include(c => c.City)
                .Include(c => c.Resumes)
                .FirstOrDefault(c => c.Id == id);
            var city = _context.Cities.Include(c => c.Candidates).FirstOrDefault(c => c.Id == candModel.CityId);
            if (id != candModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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
                        upCand.Avatar = path;
                    }

                    upCand.LastName = candModel.LastName;
                    upCand.Name = candModel.Name;
                    upCand.Surname = candModel.Surname;
                    upCand.Sex = candModel.Sex;
                    upCand.Birthday = candModel.Birthday;
                    upCand.City = candModel.City;
                    upCand.Country = candModel.Country;
                    upCand.Region = candModel.Region;
                    upCand.ApartmentNumber = candModel.ApartmentNumber;
                    upCand.PhoneNumber = candModel.PhoneNumber;
                    upCand.Email = candModel.Email;
                    upCand.Skype = candModel.Skype;
                    upCand.Facebook = candModel.Facebook;

                    _context.Candidates.Update(upCand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateExists(candModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Candidates", new { id = upCand.Id });
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", candModel.CityId);
            ViewData["FamilyStatusId"] = new SelectList(_context.FamilyStatuses, "Id", "Name");
            ViewData["ChildrenId"] = new SelectList(_context.Childrens, "Id", "Name");
            return View(candModel);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates
                .Include(c => c.City).Include(c => c.AccountUser)
                .Include(c => c.FamilyStatus).Include(c => c.Children)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var candidate = await _context.Candidates.SingleOrDefaultAsync(m => m.Id == id);
            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateExists(Guid id)
        {
            return _context.Candidates.Any(e => e.Id == id);
        }
    }
}
