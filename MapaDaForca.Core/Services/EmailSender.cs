using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MapaDaForca.Core.Services
{
    public class EmailSender : IEmailSender
    {
        public static IConfiguration Configuration { get; set; }
        private readonly IBombeiroStore _bombeiroStore;
        private readonly UserManager<Bombeiro> _userManager;

        public EmailSender(IConfiguration configuration, IBombeiroStore userStore, UserManager<Bombeiro> userManager)
        {
            Configuration = configuration;
            _bombeiroStore = userStore;
            _userManager = userManager;
        }


        public async Task<bool> SendForgotPasswordEmail(Bombeiro user, string activationUrl)
        {
            if (user == null)
                return false;

            if (string.IsNullOrEmpty(activationUrl))
                return false;

            //var client = new SendGridClient(Configuration.GetSection("AppSettings")["SendGridApiKey"]);

            //var message = new SendGridMessage();
            //message.AddTo(new EmailAddress(user.Email, $"{user.FirstName + " " + user.LastName}"));
            //message.SetFrom(new EmailAddress(Configuration.GetSection("AppSettings")["SendGrid.From"], "Hannibalvakanties"));
            //message.SetTemplateId(Configuration.GetSection("AppSettings")["SendGrid.TemplateId.Reset.Password"]);

            //var templateData = new ForgotEmailTemplateData()
            //{
            //    Subject = "Wachtwoord herstellen - Hannibalportaal",
            //    FirstName = user.FirstName,
            //    PasswordResetLink = activationUrl,
            //    PasswordResetLinkUrl = activationUrl
            //};

            //message.SetTemplateData(templateData);

            //var response = await client.SendEmailAsync(message);

            //return (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK);
            return true;
        }


        public class ForgotEmailTemplateData
        {
            [JsonProperty("subject")]
            public string Subject { get; set; }

            [JsonProperty("firstname")]
            public string FirstName { get; set; }

            [JsonProperty("passwordresetlink")]
            public string PasswordResetLink { get; set; }

            [JsonProperty("passwordresetlinkurl")]
            public string PasswordResetLinkUrl { get; set; }
        }
    }
}
