using Microsoft.EntityFrameworkCore;
using Notex.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notex.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<NotexItem> Notex { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotexItem>().ToTable("Notex");
            modelBuilder.Entity<NotexItem>().Property(x => x.Id);
            modelBuilder.Entity<NotexItem>().Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<NotexItem>().Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(160)");
            modelBuilder.Entity<NotexItem>().Property(x => x.Done).HasColumnType("bit");
            modelBuilder.Entity<NotexItem>().Property(x => x.Date);
            modelBuilder.Entity<NotexItem>().HasIndex(b => b.User);
        }
    }
}
