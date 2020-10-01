using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkDays.ViewModels
{
    using WorkDays.Models;

    public class HomeViewModel
    {
        public List<Employee> Employees
        {
            get
            {
                int i = 1;
                return new List<Employee>
                {
                               new Employee(i++,"Vlad","Bulete",Team.DataProcessor,"vlad.bulete@proplanet.com.ro"),
                               new Employee(i++,"Vlad","Matei",Team.DataProcessor,"vlad.matei@proplanet.com.ro"),
                               new Employee(i++,"Eduard","Cireag",Team.DataProcessor,"eduard.cireag@proplanet.com.ro"),

                               new Employee(i++,"Bogdan","Dragomir",Team.Ecom,"bogdan.dragomir@proplanet.com.ro"),
                               new Employee(i++,"Andrei","Tenea",Team.Ecom, "andrei.tenea@proplanet.com.ro"),
                               new Employee(i++,"Smaranda","Voiculescu",Team.Ecom,"smaranda.voiculescu@proplanet.com.ro"),
                               
                               new Employee(i++,"Radu","Dinca",Team.Saninet,"radu.dinca@proplanet.com.ro"),
                               new Employee(i++,"Lucian","Ion",Team.Saninet,"lucian.ion@proplanet.com.ro"),

                               new Employee(i++,"Marian","Rotaru",Team.Grafica,"marian.rotaru@proplanet.com.ro"),
                };
            }
        }
    }
}
