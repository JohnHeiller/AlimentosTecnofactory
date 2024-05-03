using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Tecnofactory.Alimentos.DAL.Entity;

namespace Tecnofactory.Alimentos.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalogue>();
            modelBuilder.Entity<Order>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Catalogue> Catalogues { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
