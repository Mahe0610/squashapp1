public class ReservationDto
{
    public int Id { get; set; }
    public string SlotNumber { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Status { get; set; }
}