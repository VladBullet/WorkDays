using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkDays.Services.History
{
    using WorkDays.Models;

    public interface IHistoryService
    {
        bool AddHistory(History history);
        bool EditHistory(History history);
        List<History> GetHistories();
        History GetHistoryById(int id);
    }
}
