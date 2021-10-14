using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cardapp.WebApp.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string from, string name, string subject, string message);

    }
}
