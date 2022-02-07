using LiftServiceWebApp.Models;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Services
{
    public interface IEmailSender
    {
        Task SendAsync(EmailMessage message);
    }
}