using MediatR;
using Microsoft.EntityFrameworkCore;
using Roomify.Application.Abstraction;
using Roomify.Application.UseCases.ReservetionCases.Commands;
using Roomify.Domain.Entities.Models.PrimaryModels;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.ReservetionCases.Handlers.CommandHandlers
{
    public class CancelReservationCommandHandler : IRequestHandler<CancelReservationCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CancelReservationCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponseModel> Handle(CancelReservationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Reservation reservation = await _applicationDbContext.Reservations.FirstOrDefaultAsync(r => r.Id == request.Id);

                if (reservation == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Response = "Reservation not found to cancel!"
                    };
                }

                _applicationDbContext.Reservations.Remove(reservation);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Response = $"Reservation succesuflly canceled!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Response = $"Something went wrong: {ex.Message}"
                };
            }
        }
    }
}
