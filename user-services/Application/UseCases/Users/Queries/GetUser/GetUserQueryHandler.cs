using System.Threading;
using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using user_services.Infrastructure;
using MimeKit;
using MailKit.Net.Smtp;
using System;

namespace user_services.Application.UseCases.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserDto>
    {
         private readonly UserContext _context;

         public GetUserQueryHandler(UserContext context)
         {
             _context = context;
         }

         public async Task<GetUserDto> Handle(GetUserQuery request, CancellationToken cancellation)
         {   
             var result = await _context.Users.FirstOrDefaultAsync( i => i.Id == request.Id);
             if (result == null)
      	     { 
                return null; 
             }
             else
      	     {
        	 	var message = new MimeMessage();
        		message.From.Add(new MailboxAddress("Another background h", "whatisbackgroundh@gmail.com"));
        		message.To.Add(new MailboxAddress("Another background a", "whatisbackgrounda@gmail.com"));
        		message.Subject = "Requesting a data";
        		message.Body = new TextPart("plain")
        		{
          		    Text = @"You're requesting and getting a customer data."
        		};
        		using (var client = new SmtpClient())
        		{
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect("smtp.mailtrap.io", 2525, false);
                    client.Authenticate("b0549629350b6a", "b4ff41cb5cfb79");
                    client.Send(message);
                    client.Disconnect(true);
                    Console.WriteLine("E-mail Sent");
        		}

                return new GetUserDto
                {
                    Success = true,
                    Message = "User successfully retrieved",
                    Data = result
                };
            }
        }
    }
}