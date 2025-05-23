using Microsoft.EntityFrameworkCore;
using OracleJwtApiFull.Models;

namespace OracleJwtApiFull.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Passenger> Passengers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // USER TABLE
            modelBuilder.Entity<User>().ToTable("USERS");
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Id).HasColumnName("ID");
                entity.Property(u => u.Name).HasColumnName("NAME").HasMaxLength(100).IsRequired();
                entity.Property(u => u.Email).HasColumnName("EMAIL").HasMaxLength(150).IsRequired();
                entity.Property(u => u.Password).HasColumnName("PASSWORD").HasMaxLength(200).IsRequired();
                entity.Property(u => u.Gender).HasColumnName("GENDER").HasMaxLength(10).IsRequired();
                entity.Property(u => u.DateOfBirth).HasColumnName("DATE_OF_BIRTH").HasColumnType("DATE").IsRequired();
                entity.Property(u => u.Role).HasColumnName("ROLE").HasMaxLength(50).IsRequired();
                entity.Property(u => u.PhoneNumber).HasColumnName("PHONE_NUMBER").HasMaxLength(20).IsRequired();
                entity.Property(u => u.CreatedAt).HasColumnName("CREATED_AT").HasColumnType("TIMESTAMP").IsRequired();
                entity.Property(u => u.LastLogin).HasColumnName("LAST_LOGIN").HasColumnType("TIMESTAMP").IsRequired(false);
            });

            // AIRPLANE TABLE
            modelBuilder.Entity<Airplane>().ToTable("AIRPLANES");
            modelBuilder.Entity<Airplane>(entity =>
            {
                entity.Property(a => a.Id).HasColumnName("ID");
                entity.Property(a => a.Model).HasColumnName("MODEL").HasMaxLength(100).IsRequired();
                entity.Property(a => a.EconomyCapacity).HasColumnName("ECONOMY_CAPACITY").IsRequired();
                entity.Property(a => a.BusinessCapacity).HasColumnName("BUSINESS_CAPACITY").IsRequired();
                entity.Property(a => a.FirstClassCapacity).HasColumnName("FIRST_CLASS_CAPACITY").IsRequired();
                entity.Property(a => a.CreatedAt).HasColumnName("CREATED_AT").HasColumnType("TIMESTAMP").IsRequired();
                entity.Property(a => a.UpdatedAt).HasColumnName("UPDATED_AT").HasColumnType("TIMESTAMP").IsRequired(false);
            });

            // AIRPORT TABLE
            modelBuilder.Entity<Airport>().ToTable("AIRPORTS");
            modelBuilder.Entity<Airport>(entity =>
            {
                entity.Property(a => a.Id).HasColumnName("ID");
                entity.Property(a => a.Name).HasColumnName("NAME").HasMaxLength(150).IsRequired();
                entity.Property(a => a.Code).HasColumnName("CODE").HasMaxLength(10).IsRequired();
                entity.Property(a => a.City).HasColumnName("CITY").HasMaxLength(100).IsRequired();
                entity.Property(a => a.Country).HasColumnName("COUNTRY").HasMaxLength(100).IsRequired();
                entity.Property(a => a.CreatedAt).HasColumnName("CREATED_AT").HasColumnType("TIMESTAMP").IsRequired();
                entity.Property(a => a.UpdatedAt).HasColumnName("UPDATED_AT").HasColumnType("TIMESTAMP").IsRequired(false);
            });

            // FLIGHT TABLE
            modelBuilder.Entity<Flight>().ToTable("FLIGHTS");
            modelBuilder.Entity<Flight>(entity =>
            {
                entity.Property(f => f.FlightId).HasColumnName("FLIGHT_ID");
                entity.Property(f => f.FlightNumber).HasColumnName("FLIGHT_NUMBER").HasMaxLength(10).IsRequired();
                entity.Property(f => f.AirplaneId).HasColumnName("AIRPLANE_ID").IsRequired();
                entity.Property(f => f.OriginAirportId).HasColumnName("ORIGIN_AIRPORT_ID").IsRequired();
                entity.Property(f => f.DestinationAirportId).HasColumnName("DESTINATION_AIRPORT_ID").IsRequired();
                entity.Property(f => f.DepartureTime).HasColumnName("DEPARTURE_TIME").HasColumnType("TIMESTAMP").IsRequired();
                entity.Property(f => f.ArrivalTime).HasColumnName("ARRIVAL_TIME").HasColumnType("TIMESTAMP").IsRequired();
                entity.Property(f => f.Duration).HasColumnName("DURATION").HasMaxLength(20);
                entity.Property(f => f.AvailableEconomySeats).HasColumnName("AVAILABLE_ECONOMY_SEATS").IsRequired();
                entity.Property(f => f.AvailableBusinessSeats).HasColumnName("AVAILABLE_BUSINESS_SEATS").IsRequired();
                entity.Property(f => f.AvailableFirstClassSeats).HasColumnName("AVAILABLE_FIRST_CLASS_SEATS").IsRequired();
                entity.Property(f => f.CreatedAt).HasColumnName("CREATED_AT").HasColumnType("TIMESTAMP").IsRequired();
                entity.Property(f => f.UpdatedAt).HasColumnName("UPDATED_AT").HasColumnType("TIMESTAMP").IsRequired(false);

                // Relationships / Foreign Keys
                entity.HasOne(f => f.Airplane)
                    .WithMany()
                    .HasForeignKey(f => f.AirplaneId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(f => f.OriginAirport)
                    .WithMany()
                    .HasForeignKey(f => f.OriginAirportId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(f => f.DestinationAirport)
                    .WithMany()
                    .HasForeignKey(f => f.DestinationAirportId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // WALLET TABLE
            modelBuilder.Entity<Wallet>().ToTable("WALLETS");
            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.Property(w => w.WalletId).HasColumnName("WALLET_ID");
                entity.Property(w => w.Balance).HasColumnName("BALANCE").HasColumnType("DECIMAL(18,2)").IsRequired();
                entity.Property(w => w.UserId).HasColumnName("USER_ID").IsRequired();
                entity.Property(w => w.CreatedAt).HasColumnName("CREATED_AT").HasColumnType("TIMESTAMP").IsRequired();
                entity.Property(w => w.UpdatedAt).HasColumnName("UPDATED_AT").HasColumnType("TIMESTAMP").IsRequired(false);

                // Relationship: One Wallet belongs to One User
                entity.HasOne(w => w.User)
                      .WithOne()  // One-to-one relationship, or change to .WithMany() if one user can have multiple wallets
                      .HasForeignKey<Wallet>(w => w.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // BOOKING TABLE
            modelBuilder.Entity<Booking>().ToTable("BOOKINGS");
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(b => b.BookingId).HasColumnName("BOOKING_ID");
                entity.Property(b => b.UserId).HasColumnName("USER_ID").IsRequired();
                entity.Property(b => b.FlightId).HasColumnName("FLIGHT_ID").IsRequired();
                entity.Property(b => b.NumberOfSeats).HasColumnName("NUMBER_OF_SEATS").IsRequired();
                entity.Property(b => b.TotalPrice).HasColumnName("TOTAL_PRICE").HasColumnType("DECIMAL(18,2)").IsRequired();
                entity.Property(b => b.SeatClass).HasColumnName("SEAT_CLASS").HasMaxLength(20).IsRequired();
                entity.Property(b => b.BookingDate).HasColumnName("BOOKING_DATE").HasColumnType("TIMESTAMP").IsRequired();
                entity.Property(b => b.CancelledAt).HasColumnName("CANCELLED_AT").HasColumnType("TIMESTAMP").IsRequired(false);

                entity.HasOne(b => b.User)
                    .WithMany()
                    .HasForeignKey(b => b.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(b => b.Flight)
                    .WithMany()
                    .HasForeignKey(b => b.FlightId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // PASSENGER TABLE
            modelBuilder.Entity<Passenger>().ToTable("PASSENGERS");
            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.Property(p => p.PassengerId).HasColumnName("PASSENGER_ID");
                entity.Property(p => p.BookingId).HasColumnName("BOOKING_ID").IsRequired();
                entity.Property(p => p.FullName).HasColumnName("FULL_NAME").HasMaxLength(100).IsRequired();
                entity.Property(p => p.Gender).HasColumnName("GENDER").HasMaxLength(20).IsRequired(false);
                entity.Property(p => p.DateOfBirth).HasColumnName("DATE_OF_BIRTH").HasColumnType("DATE").IsRequired();
                entity.Property(p => p.PassportNumber).HasColumnName("PASSPORT_NUMBER").HasMaxLength(100).IsRequired(false);

                entity.HasOne(p => p.Booking)
                    .WithMany(b => b.Passengers)
                    .HasForeignKey(p => p.BookingId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}
