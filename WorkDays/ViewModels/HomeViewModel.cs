using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkDays.ViewModels
{
    using WorkDays.HelpersExtensions;
    using WorkDays.Models;

    public class HomeViewModel
    {
        public List<Employee> Employees { get; set; }
        public List<History> HistoryList { get; set; }

        public string CurrentWeekString
        {
            get => string.Concat(DateTime.Today.Year.ToString(), "-W", DateTime.Today.GetIso8601WeekOfYear().ToString());
        }
    }
}
