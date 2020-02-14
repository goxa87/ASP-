using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySite1.Auth;

namespace MySite1.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(
                @"Server=.\SQLEXPRESS;DataBase=MySite1;Trusted_Connection=True;"
                );
        }
    }
}
