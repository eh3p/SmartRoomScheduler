namespace SmartRoomScheduler.Api.Models
{
    public enum ReservationStatus { Pending=0, Approved=1, Rejected=2, Cancelled=3 }

    public class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
        public Room? Room { get; set; }
        public User? User { get; set; }
    }
}
