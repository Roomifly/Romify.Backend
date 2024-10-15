using Roomify.Domain.Entities.Enums;
using System.Text.Json.Serialization;

namespace Roomify.Domain.Entities.Models.PrimaryModels
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Room Room { get; set; }
        public WeekDays Day { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly FinishTime { get; set; }
        [JsonIgnore]
        public DateOnly Date { get; set; }
    }
}
