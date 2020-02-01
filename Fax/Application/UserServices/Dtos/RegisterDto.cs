using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserServices.Dtos
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Semester { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
