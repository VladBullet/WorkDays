using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkDays.Models
{
    using System.Xml.Linq;

    public class History
    {
        public int Id { get; set; }
        public List<int> EmployeeIds { get; set; }
        public DaysOfWeek DaysOfWeek{ get; set; }
        public DateTime LastModified { get; set; }
    }
}
