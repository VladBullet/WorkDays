using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkDays.Services.History
{
    using System.IO;

    using ClosedXML.Excel;

    using Microsoft.AspNetCore.Hosting;

    using WorkDays.HelpersExtensions;
    using WorkDays.Models;

    public class HistoryService : IHistoryService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public HistoryService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public bool AddHistory(History history)
        {
            try
            {
                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Database", "History.xlsx");
                using (XLWorkbook workBook = new XLWorkbook(filePath))
                {
                    //Read the first Sheet from Excel file.
                    IXLWorksheet workSheet = workBook.Worksheet(1);
                    var lastrow = workSheet.LastRowUsed().RowNumber();
                    var newHistory = workSheet.Row(lastrow + 1);

                    newHistory.Cell(1).SetValue(history.Id);
                    newHistory.Cell(2).SetValue(history.EmployeeIds.ToCSVString());
                    newHistory.Cell(3).SetValue(history.DaysOfWeek.ToString());
                    newHistory.Cell(4).SetValue(history.LastModified.ToString());
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool EditHistory(History history)
        {
            throw new NotImplementedException();
        }

        public List<History> GetHistories()
        {
            throw new NotImplementedException();
        }

        public History GetHistoryById(int id)
        {
            throw new NotImplementedException();
        }
    }

}
