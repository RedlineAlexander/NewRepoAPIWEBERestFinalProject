using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NewRepoAPIWEBERestFinalProject.Configuration;
using NewRepoAPIWEBERestFinalProject.Services.Interfaces;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Security;

namespace NewRepoAPIWEBERestFinalProject.Services.Implementations
{
    public class EmailMessageService : IMessageService<Email>
    {

        public IConfiguration _configuration { get; set; }

        public NewRepoAPIWEBERestFinalProjectConfiguration _NewRepoAPIWEBERestFinalProjectConfiguration { get; set; }

        public EmailMessageService(IConfiguration configuration, IOptions<NewRepoAPIWEBERestFinalProjectConfiguration> options)
        {
            _configuration = configuration;
            _NewRepoAPIWEBERestFinalProjectConfiguration = options.Value;
        }
        public void SendMessage()
        {

            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Admin", _NewRepoAPIWEBERestFinalProjectConfiguration.EmailAddress));
            message.To.Add(new MailboxAddress("User", _NewRepoAPIWEBERestFinalProjectConfiguration.MyEmail));
            message.Subject = "Email from My dear System Admin";


            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Hello from my dear Admin";
            bodyBuilder.HtmlBody = "<h1> Helo from my dear Admin</h1>";
            message.Body = bodyBuilder.ToMessageBody();


            using(SmtpClient client = new SmtpClient())
            {
               // client.ServerCertificateValidationCallback = (s, c, ce, e) => true;
                //client.Connect(_NewRepoAPIWEBERestFinalProjectConfiguration);
            }
          //  throw new NotImplementedException();
        }
    }
}
