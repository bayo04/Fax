using Application.UserServices.Dtos;
using Core;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserServices
{
    public interface IUserService : IRepository<User, string, CreateUserDto>
    {

    }
}
