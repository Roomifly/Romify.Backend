using MediatR;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.ReservetionCases.Commands
{
    public class CancelReservationCommand:IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
