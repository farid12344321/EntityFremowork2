using EntityFremwork_homework2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFremwork_homework2
{
    internal class AppDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-U6B6T1F\\SQLEXPRESS;Database=homeworkDb;Trusted_Connection=true;TrustServerCertificate=True");
        }
    }
}
