using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace OlxaWeb.WebUI.Controllers
{
    public class EMAIL_SMS_sendController : Controller
    {
        public static void SendMail(string email, string subject, string text)
        {
            var smtp = new SmtpClient("email.ru", 2525) // айпи нашего SMTP клиента
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(
                        "expamle@domain.ru",
                        "pass")
            };

            var message = new MailMessage(); // формируем письмо
            message.ReplyToList.Add("expamle@domain.ru");
            message.From = new MailAddress("expamle@domain.ru"); // отправитель
            message.To.Add(new MailAddress(email)); // адрес регистрирующегося
            message.IsBodyHtml = true; // тело письма - html
            message.Subject = subject; // заголовок письма
            message.Body = text; // текст письма

            try
            {
                smtp.Send(message); //отправляем письмо
            }
            catch { }
        }
    }
}