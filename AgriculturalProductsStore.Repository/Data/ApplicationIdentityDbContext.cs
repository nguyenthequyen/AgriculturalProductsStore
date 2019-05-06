using AgriculturalProductsStore.Models;
using AgriculturalProductsStore.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProductsStore.Repository
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.ApplicationUserClaims)
                    .WithOne()
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.ApplicationUserLogins)
                    .WithOne()
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.ApplicationUserTokens)
                    .WithOne()
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.ApplicationUserRoles)
                    .WithOne()
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.ApplicationUserRoles)
                    .WithOne(e => e.ApplicationRole)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.ApplicationRoleClaims)
                    .WithOne(e => e.ApplicationRole)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });
        }

        public DbSet<UserInfor> UserInfors { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryChidren> CategoryChidrens { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}
