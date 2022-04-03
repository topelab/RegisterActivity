using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tools.TogglData.Domain.Entities;

namespace Tools.TogglData.Adapters.Builders
{
    /// <summary>
    /// Class for modeling TimelineEvent
    /// </summary>
    public class TimelineEventBuilder
    {
        /// <summary>
        /// Build model with the specified model builder.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimelineEvent>(entity =>
            {
                entity.ToTable("timeline_events");
                entity.HasNoKey();

                entity.Property(e => e.LocalId)
                    .HasColumnName("local_id")
                    .HasPrecision(8, 0);
                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasMaxLength(2147483647);
                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(2147483647);
                entity.Property(e => e.Filename)
                    .HasColumnName("filename")
                    .HasMaxLength(2147483647);
                entity.Property(e => e.Uid)
                    .HasColumnName("uid")
                    .HasPrecision(8, 0);
                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasPrecision(8, 0);
                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasPrecision(8, 0);
                entity.Property(e => e.Idle)
                    .HasColumnName("idle")
                    .HasPrecision(8, 0);
                entity.Property(e => e.Uploaded)
                    .HasColumnName("uploaded")
                    .HasPrecision(8, 0);
                entity.Property(e => e.Chunked)
                    .HasColumnName("chunked")
                    .HasPrecision(8, 0);

            });
        }
    }
}