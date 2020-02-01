using Application.UserServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserServices
{
    public interface IUserAppService
    {
        public Task Register(RegisterDto data);
    }
}
