using Application.UserServices.Dtos;
using Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserServices
{
    public class UserAppService : IUserAppService
    {
        public FaxDbContext _context { get; set; }
        public UserAppService(FaxDbContext context)
        {
            _context = context;
        }

        private byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public async Task Register(RegisterDto data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(data.Password))
                sb.Append(b.ToString("X2"));

            string passwordHash = sb.ToString();
            User user = new User
            {
                Email = data.Email,
                Name = data.Name,
                UserName = data.UserName,
                LastName = data.LastName,
                PasswordHash = passwordHash,
                Semester = data.Semester
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
