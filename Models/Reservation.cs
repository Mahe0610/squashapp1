namespace SmartParkingApi.Models
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int ParkingSlotId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string Status { get; set; } = "Reserved"; 

        public User? User { get; set; }
        public ParkingSlot? ParkingSlot { get; set; }
    }
}
