using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkDays.Models
{
    using System.Runtime.Serialization;

    public enum Team
    {
        Saninet,
        Ecom,
        DataProcessor,
        Grafica,
        Altele
    }
    public enum DaysOfWeek
    {
        [EnumMember(Value = "Luni & Marti")]
        LuniMarti,
        [EnumMember(Value = "Miercuri & Joi")]
        MiercuriJoi
    }
}
