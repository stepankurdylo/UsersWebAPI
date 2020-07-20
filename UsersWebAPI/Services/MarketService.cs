using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UsersWebAPI.App_Start;
using UsersWebAPI.Models;

namespace UsersWebAPI.Services
{
    public class MarketService : IMarketService
    {
        private readonly IMapper mapper;
        private readonly MarketContext marketContext;

        public MarketService(IMapper mapper, MarketContext marketContext)
        {
            this.mapper = mapper;
            this.marketContext = marketContext;
        }

        public IQueryable<UserDto> GetAllUsers()
        {
            try
            {
                var users = marketContext.Users;
                var usersDto = users.Select(user => mapper.Map<UserDto>(user)).ToList();
                foreach (var userDto in usersDto)
                {
                    var companyIDs = users.Where(user => user.ID == userDto.ID)
                        .SelectMany(companyUser => companyUser.CompanyUsers)
                        .Select(companyUser => companyUser.CompanyID);
                    var companies = marketContext.Companies
                        .Where(company => companyIDs.Contains(company.ID));
                    AssignCompaniesToUserDto(userDto, companies);
                }
                return usersDto.AsQueryable();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public UserDto GetUserByID(int userID)
        {
            try
            {
                var users = marketContext.Users.Where(user => user.ID == userID);
                var userDto = users.Select(user => mapper.Map<UserDto>(user)).FirstOrDefault();
                var companyIDs = users
                    .SelectMany(companyUser => companyUser.CompanyUsers)
                    .Select(companyUser => companyUser.CompanyID);
                var companies = marketContext.Companies
                    .Where(company => companyIDs.Contains(company.ID));
                AssignCompaniesToUserDto(userDto, companies);
                return userDto;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public int AddUser(User newUser)
        {
            var existingUser = marketContext.Users.FirstOrDefault(user => user.ID == newUser.ID);
            if (existingUser != null)
            {
                return WebApiConfig.EXISTING_USER_RESPONSE;
            }
            bool IsUsernameExist = marketContext.Users
                .Any(user => user.Username == newUser.Username && user.ID != newUser.ID);
            if (IsUsernameExist)
            {
                return WebApiConfig.EXISTING_USER_RESPONSE;
            }
            marketContext.Users.Add(newUser);
            marketContext.SaveChanges();
            return newUser.ID;
        }

        private void AssignCompaniesToUserDto(UserDto userDto, IQueryable<Company> companies)
        {
            foreach (var company in companies)
            {
                userDto.Companies.Add(mapper.Map<CompanyDto>(company));
            }
        }
    }
}