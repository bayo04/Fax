using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class FaxDbContext : IdentityDbContext<User>, IFaxDbContext
    {
        public FaxDbContext(DbContextOptions<FaxDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                    "Server=localhost\\SQLEXPRESS; Database=Faksistent; Trusted_Connection=True;");
        }
    }
}
