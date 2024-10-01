namespace Roomify.Domain.Entities.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public string RoomNumber { get; set; }
        public byte Floor { get; set; }
    }
}
