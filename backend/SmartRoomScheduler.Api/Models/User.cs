namespace SmartRoomScheduler.Api.Models
{
    public enum UserRole { Admin=0, Staff=1, Student=2 }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Staff;
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
