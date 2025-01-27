using MapaDaForca.Model;
using System.Threading.Tasks;

namespace MapaDaForca.Core.Services
{
    public interface IEmailSender
    {
        Task<bool> SendForgotPasswordEmail(Bombeiro bombeiro, string activationUrl);
    }
}
