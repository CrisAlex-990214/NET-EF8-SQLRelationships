using Microsoft.EntityFrameworkCore;
using SQLRelationships.Entities;

namespace SQLRelationships
{
    public class Context : DbContext
    {
        public Context(DbContextOptions opts) : base(opts)
        {

        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Coupon> Coupon { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserCoupon> UserCoupon { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(new Address { Id = 1, StreetNumber = "Avenue 110th" });
            modelBuilder.Entity<Coupon>().HasData(new Coupon { Id = 1, Code = "FIFf" });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, Title = "Shoe", Price = 12, UserId = 1 });
            modelBuilder.Entity<User>().HasData(new User { Id = 1, Name = "Paul", AddressId = 1 });

            modelBuilder.Entity<User>()
                .HasMany(e => e.Coupons)
                .WithMany(e => e.Users)
                .UsingEntity<UserCoupon>();

            modelBuilder.Entity<UserCoupon>().HasData(new UserCoupon { UserId = 1, CouponId = 1 });
        }
    }
}
