using SmartParkingApi.Models;
using SmartParkingApi.Data;
using Microsoft.EntityFrameworkCore;


public static class DataSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Users.Any())
        {
            context.Users.AddRange(new List<User> {
                new User { Id = Guid.NewGuid(), Name = "Admin", Email = "admin@example.com", Role = "Admin" },
                new User { Id = Guid.NewGuid(), Name = "User1", Email = "user1@example.com", Role = "User" },
               });
        }

        if (!context.ParkingSlots.Any())
        {
            for (int i = 1; i <= 10; i++)
            {
                context.ParkingSlots.Add(new ParkingSlot { SlotNumber = $"SLOT-{i}", IsActive = true });
            }
        }

        context.SaveChanges();
    }
}
