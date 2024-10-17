using Mapster;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Roomify.Application.Abstraction;
using Roomify.Application.UseCases.RoomCases.Commands;
using Roomify.Domain.Entities.Enums;
using Roomify.Domain.Entities.Models.PrimaryModels;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.RoomCases.Handlers.CommandHandlers
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public CreateRoomCommandHandler(IApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        public async Task<ResponseModel> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
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

                string imagePath = $"roomImages/{Guid.NewGuid()}_{request.Image.FileName}";
                string path = $"{_webHostEnvironment.WebRootPath}/{imagePath}";
                string url = $"{_configuration.GetValue<string>("DNS")!}{imagePath}";

                using (FileStream strem = new FileStream(path, FileMode.Create))
                {
                    await request.Image.CopyToAsync(strem);
                }

                Room room = request.Adapt<Room>();

                room.ImageURL = url;

                await _applicationDbContext.Rooms.AddAsync(room);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Response = "Room successfully created!"
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

/*
private readonly IApplicationDbContext _applicationDbContext;

        public CreateRoomCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

try
{

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
*/