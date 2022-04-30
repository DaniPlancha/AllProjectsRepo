using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AirportDBFirst
{
    public partial class airportsystemContext : DbContext
    {
        public airportsystemContext()
        {
        }

        public airportsystemContext(DbContextOptions<airportsystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<FlightSection> FlightSections { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("user id=root;password=DaniGotiniq123;host=localhost;database=airportsystem", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Airline>(entity =>
            {
                entity.ToTable("airline");

                entity.HasIndex(e => e.Id, "ID")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.ToTable("airport");

                entity.HasIndex(e => e.Id, "ID")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("flight");

                entity.HasIndex(e => e.Id, "ID")
                    .IsUnique();

                entity.HasIndex(e => e.AirlineId, "airline_id");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AirlineId).HasColumnName("airline_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("destination");

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("origin");

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.AirlineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flight_ibfk_1");
            });

            modelBuilder.Entity<FlightSection>(entity =>
            {
                entity.ToTable("flight_section");

                entity.HasIndex(e => e.Id, "ID")
                    .IsUnique();

                entity.HasIndex(e => e.FlightId, "flight_id");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cols).HasColumnName("cols");

                entity.Property(e => e.FlightId).HasColumnName("flight_id");

                entity.Property(e => e.Rows).HasColumnName("rows");

                entity.Property(e => e.SeatClass)
                    .HasColumnType("enum('Economy','Business','First')")
                    .HasColumnName("seat_class");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.FlightSections)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flight_section_ibfk_1");
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.ToTable("seat");

                entity.HasIndex(e => e.Id, "ID")
                    .IsUnique();

                entity.HasIndex(e => e.SectionId, "section_id");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Booked).HasColumnName("booked");

                entity.Property(e => e.Col)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("col")
                    .IsFixedLength(true);

                entity.Property(e => e.Row).HasColumnName("row");

                entity.Property(e => e.SectionId).HasColumnName("section_id");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("seat_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
