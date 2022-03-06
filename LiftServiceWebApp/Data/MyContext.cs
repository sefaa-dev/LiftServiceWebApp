using LiftServiceWebApp.Models.Entities;
using LiftServiceWebApp.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

            builder.Entity<BasketProduct>()
                .HasKey(x => new { x.BasketId, x.ProductId });
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<Failure> Failures { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }
        
    }
}
