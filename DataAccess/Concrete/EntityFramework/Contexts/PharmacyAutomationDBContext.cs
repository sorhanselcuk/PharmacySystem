using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class PharmacyAutomationDBContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PharmacyAutomationDB;Trusted_Connection=true");
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Drug> Drugs { get; set; }
    }
}
