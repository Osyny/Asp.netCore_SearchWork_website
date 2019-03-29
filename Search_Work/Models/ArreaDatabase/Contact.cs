using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.ArreaDatabase
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    public string Name { get; set; }
    public string Surname { get; set; }

    public string Avatar { get; set; }

    public string Site { get; set; }

        public string Facebook { get; set; }

        public bool Status { get; set; }

        public Employer Employer { get; set; }
        public Guid EmployerId { get; set; }
    }
}
