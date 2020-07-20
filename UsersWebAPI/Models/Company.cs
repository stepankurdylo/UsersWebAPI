using System.Collections.Generic;

namespace UsersWebAPI.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<CompanyUser> CompanyUsers { get; set; }
    }
}