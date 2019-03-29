using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Search_Work.Models.ArreaDatabase;

namespace Search_Work.Models
{
  // Add profile data for application users by adding properties to the ApplicationUser class
  public class ApplicationUser : IdentityUser
  {
    public Employer Employer { get; set; }
    public Candidate Candidate { get; set; }
  }
}
