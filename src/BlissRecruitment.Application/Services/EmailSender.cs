using BlissRecruitment.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace BlissRecruitment.Application.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            throw new NotImplementedException();
        }
    }
}
