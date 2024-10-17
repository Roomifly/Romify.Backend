using System.Text.Json.Serialization;

namespace Roomify.Domain.Entities.Models.PrimaryModels
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public Guid RoomId { get; set; }
        [JsonIgnore]
        public Room Room { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly FinishTime { get; set; }
        [JsonIgnore]
        public DateOnly Date { get; set; }
    }
}
