﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserServices.Dtos
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
