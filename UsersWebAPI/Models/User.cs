using System.Collections.Generic;

namespace UsersWebAPI.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public IList<CompanyUser> CompanyUsers { get; set; }
    }
}