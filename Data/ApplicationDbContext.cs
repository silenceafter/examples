using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using repository_template.Models;

namespace repository_template.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("server=localhost;port=5432;database=repository-template;user id=postgres;password=bdw");
    }
}
