using LiftServiceWebApp.Entities;
using LiftServiceWebApp.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Data
{
    public class MyContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SubscriptionType>()
                .Property(x => x.Price)
                .HasPrecision(8, 2);

            builder.Entity<Subscription>()
                .Property(x => x.Amount)
                .HasPrecision(8, 2);

            builder.Entity<Subscription>()
                .Property(x => x.PaidAmount)
                .HasPrecision(8, 2);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
    }
}
