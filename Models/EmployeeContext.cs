using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.MVCCoreWeb.Models
{

    public class EmployeeContext:IdentityDbContext<ApplicationUser>
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)

        {


        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<Tournaments> tournment { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //   // base.OnModelCreating(builder);


        //    //builder.Entity<ApplicationUser>(entity => {
        //    //    entity.HasIndex(e => e.PhoneNumber).IsUnique();
        //    //});
        //}
    }
}
               