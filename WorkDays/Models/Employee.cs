using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkDays.Models
{
    public class Employee
    {
        public Employee()
        {
            Id = 0;
            Team = Team.Altele;
        }
        public Employee(int id)
        {
            Id = id;
            Team = Team.Altele;
        }
        public Employee(int id, string firstname, string lastname, Team team, string email)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Team = team;
            Email = email;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Team Team { get; set; }
    }
}
