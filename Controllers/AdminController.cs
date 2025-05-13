using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartParkingApi.Services;

namespace SmartParkingApi.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public AdminController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("slots/occupied")]
        public async Task<IActionResult> GetOccupiedSlots([FromQuery] DateTime at)
        {
            var slots = await _reservationService.GetOccupiedSlotsAsync(at);
            return Ok(slots);
        }

        [HttpGet("slots/frequent")]
        public async Task<IActionResult> GetFrequentSlots()
        {
            var slots = await _reservationService.GetTopFrequentSlotsAsync();
            return Ok(slots);
        }
    }
}