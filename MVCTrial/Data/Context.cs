using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCTrial.Models;

namespace MVCTrial.Data
{
    public class Context : IdentityDbContext<ApplicationUser>

    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options):base(options)
        {

        }

        public DbSet<books> books { get; set; }
        //LAPTOP-9K9G1JR4\SQLEXPRESS1

       // string demo = @"server=LAPTOP-9K9G1JR4\SQLEXPRESS1;Database=bookstore;Integrated Security = true;";

        public DbSet<Language> lang { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-9K9G1JR4\\SQLEXPRESS1;Database=bookstore;Integrated Security=true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
