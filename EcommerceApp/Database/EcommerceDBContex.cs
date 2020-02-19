using EcommerceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Database
{
    public class EcommerceDBContex:DbContext
    {
        public DbSet<Customer> customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = "Server= DESKTOP-CG2V41L; Database=EcommerceDB; Integrated Security=true";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
