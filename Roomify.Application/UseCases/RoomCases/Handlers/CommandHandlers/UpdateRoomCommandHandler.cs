﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Roomify.Application.Abstraction;
using Roomify.Application.UseCases.RoomCases.Commands;
using Roomify.Domain.Entities.Enums;
using Roomify.Domain.Entities.Models.PrimaryModels;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.RoomCases.Handlers.CommandHandlers
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateRoomCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponseModel> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);

                if (user == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Response = "User not found!"
                    };
                }

                if (user.Role != Roles.SuperAdmin)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        Response = "User is not SuperAdmin!"
                    };
                }

                Room room = await _applicationDbContext.Rooms.FirstOrDefaultAsync(r => r.Id == request.RoomId);

                if (room == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Response = "Room not found to update!"
                    };
                }

                room.Number = request.Number != null ? request.Number : room.Number;
                room.Floor = request.Floor != null ? (byte)request.Floor : room.Floor;

                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Response = "Room updated succefully!"
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
