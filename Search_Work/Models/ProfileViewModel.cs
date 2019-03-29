using Search_Work.Models.ArreaDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models
{

  public class ProfileViewModel
  {
    public ArreaDatabase.Employer Employer { get; set; }
    public ICollection<Employer> Employers { get; set; }
    public ArreaDatabase.Candidate Candidate { get; set; }

    public Company Company { get; set; }
  }

  public class IdentityRoleViewModel
  {
    public string Id { get; set; }
    public string NameRole { get; set; }
  }
}

