using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tools.TogglData.Domain.Entities;

namespace Tools.TogglData.Adapters.Builders
{
    /// <summary>
    /// Class for modeling Winlog
    /// </summary>
    public class WinlogBuilder
    {
        /// <summary>
        /// Build model with the specified model builder.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Winlog>(entity =>
            {
                entity.ToTable("winlog");
                entity.HasKey(e => e.LocalId);

                entity.Property(e => e.LocalId)
                    .HasColumnName("local_id")
                    .HasPrecision(8, 0);

                entity.Property(e => e.HashCode)
                    .HasColumnName("hash_code")
                    .HasPrecision(8, 0);
                entity.Property(e => e.Program)
                    .HasColumnName("program")
                    .HasMaxLength(2147483647);
                entity.Property(e => e.Filename)
                    .HasColumnName("filename")
                    .HasMaxLength(2147483647);
                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .IsRequired()
                    .HasMaxLength(2147483647);
                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .IsRequired()
                    .HasMaxLength(2147483647);
                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .IsRequired()
                    .HasMaxLength(2147483647);
                entity.Property(e => e.TotalTime)
                    .HasColumnName("total_time")
                    .IsRequired()
                    .HasMaxLength(2147483647);
                entity.Property(e => e.Exported)
                    .HasColumnName("exported")
                    .HasPrecision(8, 0);

            });
        }
    }
}