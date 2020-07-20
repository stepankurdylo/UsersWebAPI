using System.Linq;
using UsersWebAPI.Models;

namespace UsersWebAPI.Services
{
    public interface IMarketService
    {
        public IQueryable<UserDto> GetAllUsers();
        public UserDto GetUserByID(int userID);
        public int AddUser(User newUser);
    }
}