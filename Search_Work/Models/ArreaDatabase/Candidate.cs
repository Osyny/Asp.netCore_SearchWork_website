using Search_Work.Models.ArreaDatabase.Resumes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase
{
    public class Candidate
    {

        public Guid Id { get; set; }

        public string Avatar { get; set; }


        public ApplicationUser AccountUser { get; set; }

        public string LastName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }

        public Guid? CityId { get; set; }
        public City City { get; set; }

        public string Country { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
        public string ApartmentNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        //public string Site { get; set; }
        public string Skype { get; set; }

        public string Facebook { get; set; }

        public string Linkedin { get; set; }

    [NotMapped]
    public string Age
    {
      get
      {

        var dif = (DateTime.Now - Birthday).Days;

        DateTime year = new DateTime().AddDays(dif);

        return year.ToString("yy");
      }
    }

    public FamilyStatus FamilyStatus { get; set; }
    [ForeignKey("FamilyStatus")]
    public Guid? FamilyStatusId { get; set; }

    public Children Children { get; set; }
    [ForeignKey("Children")]
    public Guid? ChildrenId { get; set; }

    public ICollection<Resume> Resumes { get; set; }
    public ICollection<RecommendedVacancy> RecommendedVacancies { get; set; }

    public ICollection<SavedVacancy> SavedVacancies { get; set; }

    public ICollection<ResponseToVacancy> ResponsesToVacancy { get; set; }
  }
}
