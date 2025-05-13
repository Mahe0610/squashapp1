using Microsoft.AspNetCore.Mvc;
using SmartParkingApi.DTOs;
using SmartParkingApi.Services;
using System;
using System.Threading.Tasks;

namespace SmartParkingApi.Controllers
{
    [ApiController]
    [Route("api/user/reservations")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        private Guid GetUserId()
        {
            return Guid.NewGuid();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationCreateDto dto)
        {
            var userId = GetUserId();
            if (await _reservationService.HasConflictAsync(dto.ParkingSlotId, dto.StartTime, dto.EndTime))
                return BadRequest("Slot already reserved for this time.");
            await _reservationService.CreateAsync(userId, dto);
            return Ok("Reservation successful.");
        }

        [HttpGet("mine")]
        public async Task<IActionResult> GetMyReservations()
        {
            var userId = GetUserId(); 
            var result = await _reservationService.GetByUserAsync(userId);
            return Ok(result);
        }
    }
}
