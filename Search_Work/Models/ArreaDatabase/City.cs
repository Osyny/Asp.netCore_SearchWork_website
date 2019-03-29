using Search_Work.Models.ArreaDatabase.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase
{
    public class City
    {
        public City()
        {
            this.Candidates = new List<Candidate>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Candidate> Candidates { get; set; }
        public ICollection<Company> Companies { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
