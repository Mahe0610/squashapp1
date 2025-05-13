using Microsoft.EntityFrameworkCore;
using SmartParkingApi.Models;

namespace SmartParkingApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ParkingSlot> ParkingSlots { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = Guid.NewGuid(), Name = "Admin", Email = "admin@mall.com", Role = "Admin" },
                new User { Id = Guid.NewGuid(), Name = "User1", Email = "user1@mall.com", Role = "User" },
                new User { Id = Guid.NewGuid(), Name = "User2", Email = "user2@mall.com", Role = "User" },
                new User { Id = Guid.NewGuid(), Name = "User3", Email = "user3@mall.com", Role = "User" },
                new User { Id = Guid.NewGuid(), Name = "User4", Email = "user4@mall.com", Role = "User" }
            );

            var slots = new List<ParkingSlot>();
            for (int i = 1; i <= 10; i++)
                slots.Add(new ParkingSlot { Id = i, SlotNumber = $"S{i:00}", IsActive = true });

            modelBuilder.Entity<ParkingSlot>().HasData(slots);
        }
    }
}