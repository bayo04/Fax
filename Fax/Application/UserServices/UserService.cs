using Application.UserServices.Dtos;
using Application.Registries;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Application.UserServices
{
    public class UserService : Repository<User, string, CreateUserDto>, IUserService
    {
        //public FaxDbContext _faxDbContext { get; set; }
        public ApplicationUserManager _userManager { get; set; }
        public UserService(FaxDbContext context, ApplicationUserManager userManager)
        {
            _faxDbContext = context;
            _userManager = userManager;
        }

        public override async Task<bool> Add(CreateUserDto entity)
        {
            User user = new User
            {
                Email = entity.Email,
                Name = entity.Name,
                LastName = entity.LastName,
                Semester = entity.Semester,
                UserName = entity.UserName
            };
            var i = await _userManager.CreateAsync(user, entity.Password);
            var err = i.Errors;
            if (i.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Login(LoginDto user)
        {
            var i = await _userManager.FindByEmailAsync(user.Username);
            if (i != null)
            {
                user.Username = i.UserName;
            }
            return true;
        }
    }
}
