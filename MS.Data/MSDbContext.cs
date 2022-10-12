using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeterStors.API.Data
{
    public class MSDbContext : IdentityDbContext<User>
    {
        public MSDbContext(DbContextOptions<MSDbContext> options)
            : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Service> Services { get; set; }


    }
}
