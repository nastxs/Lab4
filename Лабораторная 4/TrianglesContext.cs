using System;
using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Lab4
{
    public partial class TrianglesContext : DbContext
    {
        public TrianglesContext()
        {
        }

        public TrianglesContext(DbContextOptions<TrianglesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Triangle> triangle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Triangles;Username=postgres;Password=25481");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Triangle>(entity =>
            {
                entity.ToTable("triangle_table");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.A).HasColumnName("_a");

                entity.Property(e => e.Area).HasColumnName("_area");

                entity.Property(e => e.B).HasColumnName("_b");

                entity.Property(e => e.C).HasColumnName("_c");

                entity.Property(e => e.Type).HasColumnName("_type");

                entity.Property(e => e.IsValidType).HasColumnName("_isvalidtype");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
