using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Views;
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
            optionsBuilder.UseSqlServer(@"Server=.;Database=PharmacyAutomationDB;Trusted_Connection=false;User Id=pharmacy;Password=pharmacy123");
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Automat> Automats { get; set; }
        public DbSet<AutomatStockInformation> AutomatStockInformations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<SupplierUser> SupplierUsers { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionDetail> PrescriptionDetails { get; set; }
        public DbSet<AuthorizationType> AuthorizationTypes { get; set; }
        public DbSet<SystemOperationClaim> SystemOperationClaims { get; set; }
        public DbSet<WebOperationClaim> WebOperationClaims { get; set; }
    }
}
