using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkDays.HelpersExtensions
{
    using System.Globalization;

    using WorkDays.Models;

    public static class Extensions
    {
        public static Team ToTeam(this string str)
        {
            switch (str.ToLower())
            {
                case "dataprocessor":
                    return Team.DataProcessor;
                case "ecom":
                    return Team.Ecom;
                case "saninet":
                    return Team.Saninet;
                case "grafica":
                    return Team.Grafica;
                default:
                    return Team.Altele;
            }
        }

        public static string ToCSVString(this List<int> list)
        {
           return string.Join(",",list);
        }

        public static List<int> ToListIntFromCSV(this string str)
        {
            var result = new List<int>();
            var strList = str.Split(',').ToList();
            foreach (var item in strList)
            {
                result.Add(int.Parse(item));
            }
            return result;
        }

        public static int GetIso8601WeekOfYear(this DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
