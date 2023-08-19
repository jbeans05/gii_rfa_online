using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paperless_rfa.Models;
using Microsoft.Extensions.Configuration;

namespace Paperless_rfa.DataAccess
{
    public class ApplicationDbContext : DbContext
    {      
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();   
            var connectionString = config.GetConnectionString("GiiAuth");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);                
            modelBuilder.Entity<Departement>().Property(c=>c.Id).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Departement>().HasIndex(c=>c.DeptCode).IsUnique();

            modelBuilder.Entity<Employee>().Property(c=> c.Id).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Employee>().HasIndex(c=> c.EmployeeId).IsUnique();

            modelBuilder.Entity<Item>().Property(c=>c.Id).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Item>().HasIndex(c=> c.Code).IsUnique();

            modelBuilder.Entity<RequestOrder>().Property(c=>c.Id).UseIdentityAlwaysColumn();
            modelBuilder.Entity<RequestOrder>().HasIndex(c=>c.RequestOrderNumber).IsUnique();
            
            modelBuilder.Entity<RequestOrderDetail>().Property(c=>c.Id).UseIdentityAlwaysColumn();

            modelBuilder.Entity<RFA>().Property(c=>c.Id).UseIdentityAlwaysColumn();            
            modelBuilder.Entity<RFA>().HasIndex(c=>c.RFANumber).IsUnique();

            modelBuilder.Entity<RFADetail>().Property(c=>c.Id).UseIdentityAlwaysColumn();
          
            modelBuilder.Entity<Supplier>().Property(c=>c.Id).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Supplier>().HasIndex(c=>c.Name).IsUnique();

            modelBuilder.Entity<UserApp>().Property(c=>c.Id).UseIdentityAlwaysColumn();
            modelBuilder.Entity<UserApp>().HasIndex(c=> c.userName).IsUnique();

            modelBuilder.Entity<UserRole>().Property(c=>c.Id).UseIdentityAlwaysColumn();           
            
        }

        public DbSet<Departement> Departement{get;set;}
        public DbSet<Employee> Employee{get;set;}
        public DbSet<Item> Item {get;set;}
        public DbSet<RequestOrder> RequestOrder{get;set;}
        public DbSet<RequestOrderDetail> RequestOrderDetail{get;set;}
        public DbSet<RFA> RFA {get;set;}
        public DbSet<RFADetail> RFADetail{get;set;}
        public DbSet<Role> Role{get;set;}
        public DbSet<UserApp> UserApp{get;set;}
        public DbSet<UserRole> UserRole{get;set;}
        public DbSet<Supplier> Supplier{get;set;}
    }
}