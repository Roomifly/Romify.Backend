namespace Roomify.Domain.Entities.Models.PrimaryModels
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public byte Floor { get; set; }
        public string ImageURL { get; set; }
    }
}
