using Microsoft.EntityFrameworkCore;
using SmartParkingApi.Data;
using SmartParkingApi.DTOs;
using SmartParkingApi.Models;

namespace SmartParkingApi.Services
{
    public class ReservationService : IReservationService
    {
        private readonly AppDbContext _context;

        public ReservationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> HasConflictAsync(int slotId, DateTime start, DateTime end)
        {
            return await _context.Reservations.AnyAsync(r =>
                r.ParkingSlotId == slotId &&
                r.Status == "Reserved" &&
                !(end <= r.StartTime || start >= r.EndTime));
        }

        public async Task CreateAsync(Guid userId, ReservationCreateDto dto)
        {
            var reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ParkingSlotId = dto.ParkingSlotId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Status = "Reserved"
            };
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> GetByUserAsync(Guid userId)
        {
            return await _context.Reservations
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<OccupiedSlotDto>> GetOccupiedSlotsAsync(DateTime at)
        {
            return await _context.Reservations
                .Where(r => r.StartTime <= at && r.EndTime >= at)
                .Include(r => r.ParkingSlot)
                .Select(r => new OccupiedSlotDto
                {
                    SlotId = r.ParkingSlotId,
                    SlotName = r.ParkingSlot != null ? r.ParkingSlot.SlotNumber: "Unknown",
                    StartTime = r.StartTime,
                    EndTime = r.EndTime
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<FrequentSlotDto>> GetTopFrequentSlotsAsync()
        {
            return await _context.Reservations
                .GroupBy(r => r.ParkingSlotId)
                .Select(g => new
                {
                    SlotId = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Count)
                .Take(5)
                .Join(_context.ParkingSlots,
                    g => g.SlotId,
                    s => s.Id,
                    (g, s) => new FrequentSlotDto
                    {
                        SlotId = s.Id,
                        SlotName = s.SlotNumber,
                        ReservationCount = g.Count
                    })
                .ToListAsync();
        }
    }
}
