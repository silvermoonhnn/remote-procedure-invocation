using System.IO.Pipes;
using System.Net.WebSockets;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MediatR;
using System.Threading.Tasks;
using user_services.Infrastructure;
using user_services.Domain.Entities;
using user_services.Application.UseCases.Users.Model;
using user_services.Application.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;

namespace user_services.Application.UseCases.Users.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandDto>
    {
        private readonly UserContext _context;

        public CreateUserCommandHandler(UserContext context)
        {
            _context = context;
        }

        public async Task<CreateUserCommandDto> Handle(CreateUserCommand request, CancellationToken cancellation)
        {
            var us = new UserEn
            {
                Name = request.Data.Attributes.Name,
                Username = request.Data.Attributes.Username,
                Email = request.Data.Attributes.Email,
                Password = request.Data.Attributes.Password,
                Address = request.Data.Attributes.Address
            };

             _context.Users.Add(us);
            await _context.SaveChangesAsync(cancellation);
            
            var user = _context.Users.First(i => i.Username == request.Data.Attributes.Username);
            var target = new Target()
            {
                Id = user.Id, EmailDestination = user.Email
            };
            
            var po = new UserNo()
            {
                Title = "This is the title of the massage",
                Message = "The massage is nothing, just this",
                Type = "Email",
                From = 1,
                Targets = new List<Target>() { target } 
            };

            var attributes = new Data<UserNo>() { Attributes = po };
            var httpContent = new RequestData<UserNo>() { Data = attributes }; 
            var convert = JsonConvert.SerializeObject(httpContent);

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "notification", type: ExchangeType.Fanout);
                channel.QueueDeclare(queue: "this", durable: true, exclusive: false, autoDelete: false, arguments: null);
                channel.QueueBind(queue: "this", exchange: "notification", string.Empty);
                
                var body = Encoding.UTF8.GetBytes(convert);
                channel.BasicPublish(exchange: "notification", routingKey: "", basicProperties: null, body: body);

                Console.WriteLine($"Message has sent");
            }
           
            // var data = new StringContent(convert, Encoding.UTF8, "application/json");
            //await client.PostAsync("http://notificationservice/notification", content);

            return new CreateUserCommandDto
            {
                Success = true,
                Message = "User successfully created"
            };
        }
    }
}