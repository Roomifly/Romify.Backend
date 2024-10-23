using Mapster;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Roomify.Application.Abstraction;
using Roomify.Application.Services.EmailServices;
using Roomify.Application.UseCases.ReservetionCases.Commands;
using Roomify.Domain.Entities.DTOs;
using Roomify.Domain.Entities.Models.PrimaryModels;
using Roomify.Domain.Entities.Views;
using Telegram.Bot;

namespace Roomify.Application.UseCases.ReservetionCases.Handlers.CommandHandlers
{
    public class ReserveRoomCommandHandler : IRequestHandler<ReserveRoomCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEmailService _emailService;
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IConfiguration _configuration;

        public ReserveRoomCommandHandler(IApplicationDbContext applicationDbContext, IEmailService emailService, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _emailService = emailService;
            _webHostEnvironment = webHostEnvironment;
            _telegramBotClient = new TelegramBotClient("7884463765:AAHcGmd2oprN4J8HcDhbMb73wYiP4YnXFlE", cancellationToken: new CancellationToken());
            _configuration = configuration;
        }

        public async Task<ResponseModel> Handle(ReserveRoomCommand request, CancellationToken cancellationToken)
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

                Room room = await _applicationDbContext.Rooms.FirstOrDefaultAsync(r => r.Id == request.RoomId);

                if (room == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Response = "Room not found to reserve!"
                    };
                }

                TimeOnly.TryParse(request.StartTime, out TimeOnly startTime);
                TimeOnly.TryParse(request.FinishTime, out TimeOnly finishTime);
                DateOnly date = DateOnly.FromDateTime(DateTime.Today);

                if (startTime > finishTime || date.DayOfWeek > request.Day)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        Response = "Period of reservation is incorrect!"
                    };
                }

                Reservation reservation = await _applicationDbContext.Reservations.FirstOrDefaultAsync(r => r.Room == room && r.StartTime < finishTime && r.FinishTime > startTime && r.Day == request.Day ? r.Date == date : false);

                if (reservation != null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        Response = "Room is already reserved in this given time!"
                    };
                }

                IEnumerable<int> reserveIds = await _applicationDbContext.Reservations.Select(r => r.ReserveId).ToListAsync();

                reservation = request.Adapt<Reservation>();
                reservation.Date = date;

                Random random = new Random();

                do
                {
                    reservation.ReserveId = random.Next(1000, 10000);
                }
                while (reserveIds.Contains(reservation.ReserveId));

                await _applicationDbContext.Reservations.AddAsync(reservation);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                string HTMLbody;

                using (StreamReader stream = new StreamReader($"{_webHostEnvironment.WebRootPath}/HTMLMessages/MessageAboutReservation.html"))
                {
                    HTMLbody = (await stream.ReadToEndAsync());
                }

                HTMLbody = HTMLbody.Replace("RoomNumber", room.Number);
                HTMLbody = HTMLbody.Replace("reserveId", reservation.ReserveId.ToString());
                HTMLbody = HTMLbody.Replace("floor", room.Floor.ToString());
                HTMLbody = HTMLbody.Replace("startTime", reservation.StartTime.ToString());
                HTMLbody = HTMLbody.Replace("finishTime", reservation.FinishTime.ToString());
                HTMLbody = HTMLbody.Replace("dayOfWeek", reservation.Day.ToString());
                HTMLbody = HTMLbody.Replace("date", reservation.Date.ToString());
                HTMLbody = HTMLbody.Replace("room.img", room.ImageURL);

                ResponseModel response = await _emailService.SendEmailAsync(new EmailDTO
                {
                    To = user.Email,
                    Subject = "Reservation Info",
                    Body = HTMLbody,
                    IsBodyHTML = true
                });

                if (response.IsSuccess = false)
                {
                    return response;
                }

                string text = $"Band qilish Idsi: {reservation.ReserveId}\n\n" +
                              $"{room.Number} - xonasi ({room.Floor} - qavat)\n\n" +
                              $"{reservation.Date} - sanasida\n" +
                              $"{reservation.Day} - kunida\n" +
                              $"{reservation.StartTime} - {reservation.FinishTime} vaqt oralig'ida\n\n" +
                              $"{user.FullName} tomonidan\n" +
                              $"({user.StudentId} - student id)\n\n" +
                              $"Tasnif: {reservation.Description}\n\n" +
                              $"BAND QILINDI!";

                List<long> telegramChatIds = await _applicationDbContext.TelegramChatIds.Select(t => t.ChatId).ToListAsync();
                telegramChatIds.Add(_configuration.GetSection("TelegramChatIds").GetValue<long>("Admin"));

                foreach (long id in telegramChatIds)
                {
                    try
                    {
                        await _telegramBotClient.SendTextMessageAsync(id, text);
                    }
                    catch { }
                }

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Response = "Room is succesfully reserved!"
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
