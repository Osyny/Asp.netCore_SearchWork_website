using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase
{
  public class Company
  {
    public Company()
    {
      this.Employers = new List<Employer>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Name { get; set; }


    public string CompanyLogoUrl { get; set; }

    public City City { get; set; }
    public Guid? CityId { get; set; }
    public string Requirements { get; set; }

    public string Description { get; set; }


    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Site { get; set; }

    public string Facebook { get; set; }

    // public string Linkedin { get; set; }

    public string Adress { get; set; }

    public ICollection<Employer> Employers { get; set; }

    public bool? Status { get; set; }
  }
}
