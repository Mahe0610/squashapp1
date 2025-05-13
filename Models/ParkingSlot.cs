namespace SmartParkingApi.Models
{
    public class ParkingSlot
    {
        public int Id { get; set; }

        public string SlotNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
