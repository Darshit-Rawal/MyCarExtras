using ForgetPassword.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;

namespace ForgetPassword.Controllers
{
    public class MailingController : ApiController
    {
        public async Task SendEmail([FromBody] MailModel objData)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(objData.username.ToString() + " <" + objData.ToMail.ToString() + ">"));
            message.From = new MailAddress("Amit Mohanty <amitmohanty@email.com>");
            message.Bcc.Add(new MailAddress("Amit Mohanty <amitmohanty@email.com>"));
            message.Subject = objData["subject"].ToString();
            message.Body = createEmailBody(objData["toname"].ToString(), objData["message"].ToString());
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                await smtp.SendMailAsync(message);
                await Task.FromResult(0);
            }
        }
    }
}
