using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBFirstTrainAssignmentDATA.Models
{
    public partial class TrainAssignmentContext : DbContext
    {
        public TrainAssignmentContext()
        {
        }

        public TrainAssignmentContext(DbContextOptions<TrainAssignmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Train> Trains { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-CEIJQT1;Database=TrainAssignment;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Train>(entity =>
            {
                entity.HasKey(e => e.TrainNo);

                entity.HasIndex(e => e.TrainNo, "IX_Trains")
                    .IsUnique();

                entity.Property(e => e.TrainNo).ValueGeneratedNever();

                entity.Property(e => e.FromStation).HasMaxLength(50);

                entity.Property(e => e.ToStation).HasMaxLength(50);

                entity.Property(e => e.TrainName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
