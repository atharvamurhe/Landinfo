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
        public LandinfoDbContext(DbContextOptions<LandinfoDbContext> options)
            : base(options)
        {
        }
        public DbSet<PropertyInfo> PropertyInfos { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<OperatingArea> OperatingAreas { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Property> Properties { get; set; }
    }
}
