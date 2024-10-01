namespace Roomify.Domain.Entities.Models.PrimaryModels
{
    public class Room
    {
        public Guid Id { get; set; }
        public string RoomNumber { get; set; }
        public byte Floor { get; set; }
    }
}
