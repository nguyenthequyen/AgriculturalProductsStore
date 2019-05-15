﻿// <auto-generated />
using System;
using AgriculturalProductsStore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AgriculturalProductsStore.Repository.Data.Migrations
{
    [DbContext(typeof(ApplicationIdentityDbContext))]
    partial class ApplicationIdentityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.ApplicationRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.ApplicationUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.ApplicationUserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.ApplicationUserRole", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.ApplicationUserToken", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.AspController", b =>
                {
                    b.Property<string>("Action");

                    b.Property<string>("Controller");

                    b.Property<string>("Area");

                    b.Property<string>("Desctiption");

                    b.Property<bool>("IsDelete");

                    b.HasKey("Action", "Controller");

                    b.ToTable("AspControllers");
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.AspRoleController", b =>
                {
                    b.Property<string>("IdentityRoleId");

                    b.Property<string>("Controller");

                    b.Property<string>("Action");

                    b.Property<string>("Desctiption");

                    b.HasKey("IdentityRoleId", "Controller", "Action");

                    b.HasAlternateKey("Action", "Controller", "IdentityRoleId");

                    b.ToTable("AspRoleControllers");
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.CategoryChidren", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryChidrens");
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<string>("CategoryId");

                    b.Property<string>("Code");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FullDescription");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("OpenDaySale");

                    b.Property<decimal>("Price");

                    b.Property<string>("ShortDescription");

                    b.Property<int>("Status");

                    b.Property<string>("UnitId");

                    b.Property<int>("View");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UnitId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.Unit", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.UserAddress", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int?>("AddressType");

                    b.Property<string>("Company");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("District");

                    b.Property<string>("FullName");

                    b.Property<string>("IdentityUserId");

                    b.Property<bool>("IsDefault");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("ProvinceCity");

                    b.Property<string>("Ward");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("UserAddresses");
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.UserInfor", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Birthday");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FirstName");

                    b.Property<int?>("Gender");

                    b.Property<string>("IdentityUserId");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("ModifyDate");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("UserInfors");
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.ApplicationRoleClaim", b =>
                {
                    b.HasOne("AgriculturalProductsStore.Models.Entity.ApplicationRole", "ApplicationRole")
                        .WithMany("ApplicationRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.ApplicationUserClaim", b =>
                {
                    b.HasOne("AgriculturalProductsStore.Models.Entity.ApplicationUser")
                        .WithMany("ApplicationUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.ApplicationUserLogin", b =>
                {
                    b.HasOne("AgriculturalProductsStore.Models.Entity.ApplicationUser")
                        .WithMany("ApplicationUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.ApplicationUserRole", b =>
                {
                    b.HasOne("AgriculturalProductsStore.Models.Entity.ApplicationRole", "ApplicationRole")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgriculturalProductsStore.Models.Entity.ApplicationUser")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.ApplicationUserToken", b =>
                {
                    b.HasOne("AgriculturalProductsStore.Models.Entity.ApplicationUser")
                        .WithMany("ApplicationUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.AspRoleController", b =>
                {
                    b.HasOne("AgriculturalProductsStore.Models.Entity.ApplicationRole", "IdentityRole")
                        .WithMany()
                        .HasForeignKey("IdentityRoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.CategoryChidren", b =>
                {
                    b.HasOne("AgriculturalProductsStore.Models.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.Product", b =>
                {
                    b.HasOne("AgriculturalProductsStore.Models.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("AgriculturalProductsStore.Models.Entity.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.UserAddress", b =>
                {
                    b.HasOne("AgriculturalProductsStore.Models.Entity.ApplicationUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("AgriculturalProductsStore.Models.Entity.UserInfor", b =>
                {
                    b.HasOne("AgriculturalProductsStore.Models.Entity.ApplicationUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
