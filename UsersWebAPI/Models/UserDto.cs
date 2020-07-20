using System.Collections.Generic;

namespace UsersWebAPI.Models
{
    public class UserDto
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public IList<CompanyDto> Companies { get; set; } = new List<CompanyDto>();
    }
}