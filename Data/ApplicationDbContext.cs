using System;
using System.Collections.Generic;
using System.Text;
using AlikHalafim.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlikHalafim.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<Order> Order { get; set; }
        public DbSet<CartItemForDb> CartItemForDb { get; set; }
    }
}
