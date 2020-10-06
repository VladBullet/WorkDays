using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkDays.Services
{
    using System.IO;

    using ClosedXML.Excel;

    using DocumentFormat.OpenXml.Wordprocessing;

    using Microsoft.AspNetCore.Hosting;

    using WorkDays.Models;
    using WorkDays.HelpersExtensions;
    public class EmployeeService : IEmployeeService
    {
        private IWebHostEnvironment _hostingEnvironment;

        public EmployeeService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public List<Employee> GetEmployees(List<int> ids = null)
        {
            var resultList = new List<Employee>();
            //Get filepath
            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Database", "Employees.xlsx");

            //Open the Excel file using ClosedXML.
            using (XLWorkbook workBook = new XLWorkbook(filePath))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(1);

                //Loop through the Worksheet rows.
                foreach (IXLRow row in workSheet.RowsUsed())
                {
                    var emp = new Employee();
                    emp.Id = row.Cell(1).GetValue<int>();
                    emp.FirstName = row.Cell(2).GetValue<string>();
                    emp.LastName = row.Cell(3).GetValue<string>();
                    emp.Team = row.Cell(4).GetValue<string>().ToTeam();
                    emp.Email = row.Cell(5).GetValue<string>();
                    resultList.Add(emp);
                }
            }

            if (ids != null)
            {
                resultList = resultList.Where(x => ids.Contains(x.Id)).ToList();
            }

            return resultList;
        }

        public bool AddEmployee(Employee emp)
        {
            try
            {
                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Database", "Employees.xlsx");
                using (XLWorkbook workBook = new XLWorkbook(filePath))
                {
                    //Read the first Sheet from Excel file.
                    IXLWorksheet workSheet = workBook.Worksheet(1);
                    var lastrow = workSheet.LastRowUsed().RowNumber();
                    var newemp = workSheet.Row(lastrow + 1);
                    newemp.Cell(1).SetValue(emp.Id.ToString());
                    newemp.Cell(2).SetValue(emp.FirstName);
                    newemp.Cell(3).SetValue(emp.LastName);
                    newemp.Cell(4).SetValue(emp.Team.ToString());
                    newemp.Cell(5).SetValue(emp.Email);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Database", "Employees.xlsx");
                using (XLWorkbook workBook = new XLWorkbook(filePath))
                {
                    //Read the first Sheet from Excel file.
                    IXLWorksheet workSheet = workBook.Worksheet(1);
                    workSheet.Row(id).Delete();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public bool EditEmployee(Employee emp)
        {
            try
            {
                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Database", "Employees.xlsx");
                using (XLWorkbook workBook = new XLWorkbook(filePath))
                {
                    //Read the first Sheet from Excel file.
                    IXLWorksheet workSheet = workBook.Worksheet(1);
                    var empRow = workSheet.Row(emp.Id);
                    empRow.Cell(2).SetValue(emp.FirstName);
                    empRow.Cell(3).SetValue(emp.LastName);
                    empRow.Cell(4).SetValue(emp.Team.ToString());
                    empRow.Cell(5).SetValue(emp.Email);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public Employee GetEmployeeById(int id)
        {
            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Database", "Employees.xlsx");
            var emp = new Employee();
            using (XLWorkbook workBook = new XLWorkbook(filePath))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(1);
                var empRow = workSheet.Row(id);
                if (empRow.CellsUsed() != null)
                {
                    emp.Id = empRow.Cell(1).GetValue<int>();
                    emp.FirstName = empRow.Cell(2).GetValue<string>();
                    emp.LastName = empRow.Cell(3).GetValue<string>();
                    emp.Team = empRow.Cell(4).GetValue<string>().ToTeam();
                    emp.Email = empRow.Cell(5).GetValue<string>();
                }
            }
            return emp;
        }
    }
}
