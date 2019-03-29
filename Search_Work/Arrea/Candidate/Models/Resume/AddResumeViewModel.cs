using Search_Work.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Candidate.Models.Resume
{
  public class AddResumeViewModel
  {

    public Guid CandidateId { get; set; }

    public string FotoUrl { get; set; }
    // public Int32 ID { get; set; }
    public string LastName { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Sex { get; set; }
    //public List<SexViewModel> Sex { get; set; }
    //public Guid SexId { get; set; }
    public DateTime Birthday { get; set; }

    public string Country { get; set; }
    public string Region { get; set; }

    public int Salary { get; set; }

    //public string City { get; set; }
    public string Street { get; set; }
    public string ApartmentNumber { get; set; }

    public List<FieldActivityViewModel> FieldsActivity { get; set; }
    public Guid FieldId { get; set; }


    public string Fasebook { get; set; }
    public string Linkedin { get; set; }
    public List<PhoneNumberViewModel> Phones { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Skype { get; set; }

  }
  public class SexViewModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
  }
}
