using GYM.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        private static ApplicationDbContext _instance;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public static ApplicationDbContext getInstance(IConfiguration configuration) {
            IConfiguration Configuration = configuration;
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"));
            if (_instance == null) {
                _instance = new ApplicationDbContext(options.Options);
            }
            return _instance;
        }

        public static ApplicationDbContext getInstance()
        {
            return _instance;
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<PaymentType> PaymentTypes { get; set; }

        public DbSet<PaymentDescription> PaymentDescriptions { get; set; }

        public DbSet<PhysicalCondition> PhysicalConditions { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<ProductBought> ProductBoughts { get; set; }

        public DbSet<InvoiceDescription> InvoiceDescriptions { get; set; }

        public DbSet<Appointment> Appointments { get; set; }
    }
}
