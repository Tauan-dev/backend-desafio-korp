using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FaturamentoService.Data
{
    public class FaturamentoDbContext : DbContext
    {
        public FaturamentoDbContext(DbContextOptions<FaturamentoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Invoice> Invoices { get; set; }
        public DbSet<Models.InvoiceProduct> InvoiceProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Invoice>()
                .HasMany(i => i.Products)
                .WithOne(ip => ip.Invoice)
                .HasForeignKey(ip => ip.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }

}