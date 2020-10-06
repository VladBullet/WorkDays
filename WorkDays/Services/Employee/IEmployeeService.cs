using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkDays.Services
{
    using WorkDays.Models;

    public interface IEmployeeService
    {
        List<Employee> GetEmployees(List<int> ids = null);
        bool AddEmployee(Employee emp);
        bool DeleteEmployee(int id);
        bool EditEmployee(Employee emp);
        Employee GetEmployeeById(int id);

    }
}
