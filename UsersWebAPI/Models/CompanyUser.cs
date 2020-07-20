namespace UsersWebAPI.Models
{
    public class CompanyUser
    {
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}