using LightQuery;
using LightQuery.Client;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UsersWebAPI.App_Start;
using UsersWebAPI.Models;
using UsersWebAPI.Services;

namespace UsersWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMarketService marketService;
        private const short DEFAULT_PAGE_SIZE = 10;
        private const short OK_STATUS_CODE = 200;

        public UsersController(IMarketService marketService)
        {
            this.marketService = marketService;
        }

        [HttpGet]
        [LightQuery(forcePagination: true, defaultPageSize: DEFAULT_PAGE_SIZE)]
        [ProducesResponseType(typeof(PaginationResult<IQueryable<UserDto>>), OK_STATUS_CODE)]
        public ActionResult GetAllUsers()
        {
            return Ok(marketService.GetAllUsers());
        }

        [HttpGet("{userID:int}")]
        public ActionResult<UserDto> GetUserByID(int userID)
        {
            var user = marketService.GetUserByID(userID);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPost]
        public ActionResult<int> AddUser(User newUser)
        {
            var newUserID = marketService.AddUser(newUser);
            if (newUserID == WebApiConfig.EXISTING_USER_RESPONSE)
            {
                return Conflict();
            }
            return Ok(newUserID);
        }
    }
}