using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkDays.Services.Mail
{
    using WorkDays.Models;

    public interface IMailService
    {
        bool SendMail(List<string> toEmails, DaysOfWeek selectedDays, string weekdateStart, string weekdateEnd);
    }
}
