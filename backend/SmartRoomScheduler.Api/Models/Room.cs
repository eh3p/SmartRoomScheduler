namespace SmartRoomScheduler.Api.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Equipment { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
