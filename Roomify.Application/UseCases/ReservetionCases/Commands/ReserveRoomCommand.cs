using MediatR;
using Roomify.Domain.Entities.Views;
using System.ComponentModel.DataAnnotations;

namespace Roomify.Application.UseCases.ReservetionCases.Commands
{
    public class ReserveRoomCommand:IRequest<ResponseModel>
    {
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public DayOfWeek Day { get; set; }
        [RegularExpression(@"^([01]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "The time field must be in HH:mm format.")]
        public string StartTime { get; set; }
        [RegularExpression(@"^([01]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "The time field must be in HH:mm format.")]
        public string FinishTime { get; set; }
    }
}
