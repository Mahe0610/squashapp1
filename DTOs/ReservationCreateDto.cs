using System;

namespace SmartParkingApi.DTOs
{
    public class ReservationCreateDto
    {
        public int ParkingSlotId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}