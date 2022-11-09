using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ZemiBrojce.Models
{
    public partial class Praksa_ZemiBrojContext : DbContext
    {
        public Praksa_ZemiBrojContext()
        {
        }

        public Praksa_ZemiBrojContext(DbContextOptions<Praksa_ZemiBrojContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Broj> Brojs { get; set; } = null!;
        public virtual DbSet<Salter> Salters { get; set; } = null!;
        public virtual DbSet<SalterUsluga> SalterUslugas { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Usluga> Uslugas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.9.252;Database=Praksa_ZemiBroj;User Id=sa;Password=Lexmarke_120");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Broj>(entity =>
            {
                entity.ToTable("Broj");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NajnovBroj).HasColumnName("Broj");

                entity.Property(e => e.MomentalenBroj).HasColumnName("MomentalenBroj");

                entity.Property(e => e.Generiran).HasColumnType("datetime");

                entity.HasOne(d => d.Salter)
                    .WithMany(p => p.Brojs)
                    .HasForeignKey(d => d.SalterId)
                    .HasConstraintName("FK__Broj__SalterId__22AA2996");

                entity.HasOne(d => d.Usluga)
                    .WithMany(p => p.Brojs)
                    .HasForeignKey(d => d.UslugaId)
                    .HasConstraintName("FK__Broj__UslugaId__21B6055D");
            });

            modelBuilder.Entity<Salter>(entity =>
            {
                entity.ToTable("Salter");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SalterIme).HasMaxLength(100);
            });

            modelBuilder.Entity<SalterUsluga>(entity =>
            {
                entity.ToTable("SalterUsluga");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Salter)
                    .WithMany(p => p.SalterUslugas)
                    .HasForeignKey(d => d.SalterId)
                    .HasConstraintName("FK__SalterUsl__Salte__1DE57479");

                entity.HasOne(d => d.Usluga)
                    .WithMany(p => p.SalterUslugas)
                    .HasForeignKey(d => d.UslugaId)
                    .HasConstraintName("FK__SalterUsl__Uslug__1ED998B2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Username).HasMaxLength(100);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Salter");
            });

            modelBuilder.Entity<Usluga>(entity =>
            {
                entity.ToTable("Usluga");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ImeUsluga).HasMaxLength(300);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
