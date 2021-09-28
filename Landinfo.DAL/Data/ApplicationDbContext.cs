using Landinfo.DAL.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Landinfo.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }

    public class LandinfoDbContext : DbContext
    {
        public LandinfoDbContext()
        {
        }

        public LandinfoDbContext(DbContextOptions<LandinfoDbContext> options)
            : base(options)
        {
        }
        public DbSet<PropertyInfo> PropertyInfos { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<OperatingArea> OperatingAreas { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ATHARVAM\\SQLEXPRESS;Database=Landinfo;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
