using SmartParkingApi.DTOs;
using SmartParkingApi.Models;

namespace SmartParkingApi.Services
{
    public interface IReservationService
    {
        Task<bool> HasConflictAsync(int slotId, DateTime start, DateTime end);
        Task CreateAsync(Guid userId, ReservationCreateDto dto);
        Task<IEnumerable<Reservation>> GetByUserAsync(Guid userId);
        Task<IEnumerable<OccupiedSlotDto>> GetOccupiedSlotsAsync(DateTime at);
        Task<IEnumerable<FrequentSlotDto>> GetTopFrequentSlotsAsync();
    }
}
