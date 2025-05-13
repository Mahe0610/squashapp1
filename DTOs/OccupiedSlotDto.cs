namespace SmartParkingApi.DTOs
{
    public class OccupiedSlotDto
    {
        public int SlotId { get; set; }
        public string SlotName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
