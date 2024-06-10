using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using HotelReservationApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Connections;
using Newtonsoft.Json;

public class NightlyTasksService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<NightlyTasksService> _logger;
    private readonly string _adminEmail = "rozerinsinemm@gmail.com";

    public NightlyTasksService(IServiceProvider serviceProvider, ILogger<NightlyTasksService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var now = DateTime.Now;
            if (now.Hour == 0 && now.Minute == 0) // Run at midnight
            {
                await CheckHotelCapacitiesAsync();
                await ProcessNewReservationsAsync();
            }

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); // Check every minute
        }
    }

    private async Task CheckHotelCapacitiesAsync()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<HotelReservationDbContext>();
            var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

            var hotels = dbContext.Hotels.Include(h => h.Rooms).ToList();

            foreach (var hotel in hotels)
            {
                var availableRooms = hotel.Rooms.Where(r => r.IsAvailable).Count();
                var totalRooms = hotel.Rooms.Count();
                var availabilityPercentage = (double)availableRooms / totalRooms * 100;

                if (availabilityPercentage < 20)
                {
                    await emailService.SendEmailAsync(_adminEmail, "Low Hotel Capacity Alert", $"The hotel {hotel.HotelName} has less than 20% capacity available for the next month.");
                }
            }
        }
    }

    private async Task ProcessNewReservationsAsync()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "new_reservations", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var reservation = JsonConvert.DeserializeObject<Reservation>(message);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                    await emailService.SendEmailAsync(reservation.Email, "Reservation Details", $"Your reservation details: {reservation.Details}");
                }
            };

            channel.BasicConsume(queue: "new_reservations", autoAck: true, consumer: consumer);
        }
    }
}

public class Reservation
{
    public string Email { get; set; }
    public string Details { get; set; }
}
