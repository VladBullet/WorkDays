using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkDays.Services.Mail
{
    using System.Net.Mail;

    using WorkDays.Models;

    public class MailService : IMailService
    {
        private readonly string _from = "noreply@proplanet.nl";
        private readonly string _subject = "Programare venire la birou";
        private readonly string _body = string.Join("Buna ziua! ", Environment.NewLine, $"Tin sa va anunt ca pentru saptamana {0} in zilele {1} trebuie sa veniti la birou.", Environment.NewLine, Environment.NewLine, "Va multumesc!")

            ;

        public bool SendMail(List<string> toEmails, DaysOfWeek selectedDays, string weekdateStart, string weekdateEnd)
        {
            var msg = new MailMessage();
            MailAddress fromMail = new MailAddress(_from);
            msg.From = fromMail;
            msg.Subject = _subject;
            foreach (var mail in toEmails)
            {
                MailAddress mailaddr = new MailAddress(mail);
                msg.To.Add(mailaddr);
            }

            msg.Body = string.Format(_body, string.Join(weekdateStart, " - ", weekdateEnd), selectedDays.ToString());

            var smtp = new SmtpClient("127.0.0.1")
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 25
            };
            smtp.Send(msg);
            return true;
        }
    }
}
