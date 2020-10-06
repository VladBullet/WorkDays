using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkDays.HelpersExtensions
{
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
    }
}
