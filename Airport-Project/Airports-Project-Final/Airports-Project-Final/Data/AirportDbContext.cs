using Microsoft.EntityFrameworkCore;
using Airports_Project_Final.Models;

namespace Airports_Project_Final.Data
{
    public class AirportDbContext : DbContext
    {
        public DbSet<Airport> Airport { get; set; }
        public DbSet<Airline> Airline { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public AirportDbContext(DbContextOptions<AirportDbContext> options) : base(options)
        {
        }
    }
}
