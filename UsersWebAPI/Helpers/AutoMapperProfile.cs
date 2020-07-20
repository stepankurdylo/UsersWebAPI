using AutoMapper;
using UsersWebAPI.Models;

namespace UsersWebAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Company, CompanyDto>();
        }
    }
}