using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Search_Work.Models
{
 
        public class UsersViewModel
        {
            public List<UserViewModel> Users { get; set; }
           
        }

        public class UserViewModel
        {
			//public int Id { get; set; }
            public string UserName { get; set; }
            public UserManager<ApplicationUser> Roles { get; set; }
        }

    public class RoleNameViewModel
    {
        public string Name { get; set; }
    }
}

