using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExistingDbConnection.Models
{
    public partial class coreDBContext : DbContext
    {
        public coreDBContext()
        {
        }

        public coreDBContext(DbContextOptions<coreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Crypto> Crypto { get; set; }
        public virtual DbSet<Todo> Todo { get; set; }
        public virtual DbSet<Website> Website { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:my1stsqlserver.database.windows.net,1433;Database=coreDB;User ID=godhand;Password=TestPassword91748;Encrypt=true;Connection Timeout=30;");
            }
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crypto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Country).HasColumnType("text");

                entity.Property(e => e.CryptoName).HasColumnType("text");

                entity.Property(e => e.Type).HasColumnType("text");
            });

            modelBuilder.Entity<Todo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Website>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Country).HasColumnType("text");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.WebsiteName).HasColumnType("text");
            });
        }
    }
}
