using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using notification_services.Infrastructure;
using System.Collections.Generic;
using notification_services.Application.UseCases.Model;
using RabbitMQ.Client;
using System;
using RabbitMQ.Client.Events;
using System.Text;

namespace notification_services.Application.UseCases.Notification.Queries.GetNotifications
{
    public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, GetNotificationsDto>
    {
         private readonly NotifContext _context;

         public GetNotificationsQueryHandler(NotifContext context)
         {
             _context = context;
         }

         public async Task<GetNotificationsDto> Handle(GetNotificationsQuery request, CancellationToken cancellation)
         {
            var data = await _context.Notifs.ToListAsync();
            var result = new List<NoData>();

            foreach (var i in data)
            {
                result.Add(new NoData
                {
                    Id = i.Id,
                    Title = i.Title,
                    Message = i.Message
                });
            }

            return new GetNotificationsDto 
            {
                Success = true,
                Message = "Notification successfully retrieved",
                Data = result
            };
         }

         public void Recieve()
         {
            var client = new HttpClient();
            var factory = new ConnectionFactory() { HostName = "localhost"};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "notification", type: ExchangeType.Fanout);

                var ex = channel.QueueDeclare();
                channel.QueueBind(queue: ex, exchange: "notification", routingKey:"");

                Console.WriteLine("Waiting for Message ...");
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (sender, a) =>
                {
                    var body = a.Body;
                    var message = Encoding.UTF8.GetString(body);
                    var content = new StringContent(message, Encoding.UTF8, "application/json");
                    Console.WriteLine($"Message recieved {message}");
                    await client.PostAsync("http://localhost/notification", content);
                };

                channel.BasicConsume(queue: ex, autoAck: true, consumer: consumer);
                Console.ReadLine();
            }
         }
    }
   


}