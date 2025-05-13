using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Authorization;
using SmartParkingApi.DTOs;
using SmartParkingApi.Services; 


[Authorize(Roles = "User")]
[Route("api/reservations")]
public class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReservationCreateDto dto) {
        return Ok();
    }

    [HttpGet("mine")]
    public async Task<IActionResult> GetMine() {
        return Ok();
    }
    [HttpGet("my-reservations")]
    public async Task<IActionResult> GetMyReservations()
    {
        return Ok();
    }

}
