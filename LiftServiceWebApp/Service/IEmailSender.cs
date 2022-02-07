using LiftServiceWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Service
{
    public interface IEmailSender
    {
        Task SendAsync(EmailMessage message);
    }
}
