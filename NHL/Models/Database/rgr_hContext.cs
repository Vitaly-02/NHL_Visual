using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NHL.Models.Database
{
    public partial class rgr_hContext : DbContext
    {
        public rgr_hContext()
        {
        }

        public rgr_hContext(DbContextOptions<rgr_hContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<Result> Results { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source = C:\\Users\\matin\\Desktop\\NHL\\NHL\\Assets\\rgr_h.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("Match");

                entity.HasOne(d => d.NameNavigation)
                    .WithOne(p => p.Match)
                    .HasForeignKey<Match>(d => d.Name)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Team1Navigation)
                    .WithMany(p => p.MatchTeam1Navigations)
                    .HasForeignKey(d => d.Team1);

                entity.HasOne(d => d.Team2Navigation)
                    .WithMany(p => p.MatchTeam2Navigations)
                    .HasForeignKey(d => d.Team2);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.Fio);

                entity.ToTable("Player");

                entity.Property(e => e.Fio).HasColumnName("FIO");

                entity.Property(e => e.Age).HasColumnType("INT");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("DATE")
                    .HasColumnName("Birth_date");

                entity.Property(e => e.TeamName).HasColumnName("Team_name");

                entity.HasOne(d => d.TeamNameNavigation)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamName);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => e.MatchName);

                entity.ToTable("Result");

                entity.Property(e => e.MatchName).HasColumnName("Match_name");

                entity.Property(e => e.Deletions).HasColumnType("INT");

                entity.Property(e => e.Duration).HasColumnType("TIME");

                entity.Property(e => e.TypeOfWin).HasColumnName("Type_of_win");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("Team");

                entity.Property(e => e.Points).HasColumnType("INT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
