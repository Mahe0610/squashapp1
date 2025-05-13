namespace SmartParkingApi.DTOs
{
    public class FrequentSlotDto
    {
        public int SlotId { get; set; }
        public string SlotName { get; set; } = string.Empty;
        public int ReservationCount { get; set; }
    }
}
