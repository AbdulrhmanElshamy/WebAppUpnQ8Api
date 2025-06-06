﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppUpnQ8Api.Configuration;
using UPNprojectApi.Models;

namespace WebAppUpnQ8Api.Models
{
    public class WebAppUpnQ8ApiDBContext : IdentityDbContext<ApplicationUser>
    {
        public WebAppUpnQ8ApiDBContext(DbContextOptions<WebAppUpnQ8ApiDBContext> option)
           : base(option)
        {

        }
        public virtual DbSet<CitiesTbl> CitiesTbls { get; set; }
        public virtual DbSet<CodeNumbersTbl> CodeNumbersTbls { get; set; }
        public virtual DbSet<CompanyBrandsTbl> CompanyBrandsTbls { get; set; }
        public virtual DbSet<ContentsTbl> ContentsTbls { get; set; }
        public virtual DbSet<ContractConditionsTbl> ContractConditionsTbls { get; set; }
        public virtual DbSet<ContractServicesTbl> ContractServicesTbls { get; set; }
        public virtual DbSet<CountriesTbl> CountriesTbls { get; set; }
        //public virtual DbSet<CustomersTbl> CustomersTbls { get; set; }
        //public virtual DbSet<DiscountsTbl> DiscountsTbls { get; set; }
        public virtual DbSet<DurationsTbl> DurationsTbls { get; set; }
        public virtual DbSet<EmployeesTbl> EmployeesTbls { get; set; }
        public virtual DbSet<HomeImagesTbl> HomeImagesTbls { get; set; }
        public virtual DbSet<HomePageTbl> HomePageTbls { get; set; }
        public virtual DbSet<HomeTitlesTbl> HomeTitlesTbls { get; set; }
        public virtual DbSet<LoginUserTbl> LoginUserTbls { get; set; }
        public virtual DbSet<MaintinanceContractsTbl> MaintinanceContractsTbls { get; set; }
        public virtual DbSet<MaintinanceRequestsTbl> MaintinanceRequestsTbls { get; set; }
        public virtual DbSet<NavbarCarsolsTbl> NavbarCarsolsTbls { get; set; }
        public virtual DbSet<PaymentTypesTbl> PaymentTypesTbls { get; set; }
        public virtual DbSet<PlanContentsTbl> PlanContentsTbls { get; set; }
        public virtual DbSet<PlansTbl> PlansTbls { get; set; }
        public virtual DbSet<PlanSubscripesTbl> PlanSubscripesTbls { get; set; }
        public virtual DbSet<ProductDetailsTbl> ProductDetailsTbls { get; set; }
        public virtual DbSet<ProductSpecificationsTbl> ProductSpecificationsTbls { get; set; }
        public virtual DbSet<ProductsTbl> ProductsTbls { get; set; }
        public virtual DbSet<ProductSubTypeSpecificationsTbl> ProductSubTypeSpecificationsTbls { get; set; }
        public virtual DbSet<ProductSubTypesTbl> ProductSubTypesTbls { get; set; }
        public virtual DbSet<ProductTypesTbl> ProductTypesTbls { get; set; }
        public virtual DbSet<RequestsQuoteTbl> RequestsQuoteTbls { get; set; }
        public virtual DbSet<ServiceRequestsTbl> ServiceRequestsTbls { get; set; }
        public virtual DbSet<ServicesTbl> ServicesTbls { get; set; }
        public virtual DbSet<SocialAccountsTbl> SocialAccountsTbls { get; set; }
        public virtual DbSet<SpecialFeaturesTbl> SpecialFeaturesTbls { get; set; }
        public virtual DbSet<SpecialRequestFeaturesTbl> SpecialRequestFeaturesTbls { get; set; }
        public virtual DbSet<SpecialRequestsTbl> SpecialRequestsTbls { get; set; }
        public virtual DbSet<SubFeaturesTbl> SubFeaturesTbls { get; set; }
        public virtual DbSet<SubscriptionsTbl> SubscriptionsTbls { get; set; }
        public virtual DbSet<SubServicesTbl> SubServicesTbls { get; set; }
        public virtual DbSet<TestmonialsTbl> TestmonialsTbls { get; set; }
        public virtual DbSet<ProductSalesTbl> ProductSalesTbls { get; set; }
        public virtual DbSet<EvaluationsTbl> EvaluationsTbls { get; set; }
        public virtual DbSet<PlanSubscripeContentsTbl> PlanSubscripeContentsTbls { get; set; }
        public virtual DbSet<RefreshTokenTbl> RefreshTokenTbls { get; set; }
        public virtual DbSet<Discounts> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = DefaultUsers.Admin.Id,
                FirstName = "UpnQ8A",
                LastName = "Admin",
                UserName = DefaultUsers.Admin.Email,
                NormalizedUserName = DefaultUsers.Admin.Email.ToUpper(),
                Email = DefaultUsers.Admin.Email,
                NormalizedEmail = DefaultUsers.Admin.Email.ToUpper(),
                SecurityStamp = DefaultUsers.Admin.SecurityStamp,
                ConcurrencyStamp = DefaultUsers.Admin.ConcurrencyStamp,
                EmailConfirmed = true,
                PasswordHash = DefaultUsers.Admin.PasswordHash
            });

            builder.Entity<IdentityRole>().HasData(
      new IdentityRole
      {
          Id = DefaultRoles.Admin.Id,
          Name = DefaultRoles.Admin.Name,
          NormalizedName = DefaultRoles.Admin.Name.ToUpper(),
          ConcurrencyStamp = DefaultRoles.Admin.ConcurrencyStamp
      },
      new IdentityRole
      {
          Id = DefaultRoles.User.Id,
          Name = DefaultRoles.User.Name,
          NormalizedName = DefaultRoles.User.Name.ToUpper(),
          ConcurrencyStamp = DefaultRoles.User.ConcurrencyStamp
      }
  );


            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = DefaultUsers.Admin.Id,
                RoleId = DefaultRoles.Admin.Id
            });

            base.OnModelCreating(builder);

        }

    }
}
