using TotalsService.Models;
using System.Collections.Generic;

namespace TotalsService.Persistence
{
    public interface IDuosRepository
    {
        IEnumerable<DuosRow> GetAllByMpan(string mpan);
        IEnumerable<DuosRow> GetAllBySupplyPointRef(string supplyPointRef);
        IEnumerable<DuosRow> GetByMpanAndDate(string mpan, string date);
        IEnumerable<DuosRow> GetBySupplyPointRefAndDate(string supplyPointRef, string date);
        IEnumerable<DuosRow> GetByMpanBetweenDates(string mpan, string startDate, string endDate);
        IEnumerable<DuosRow> GetBySupplyPointRefBetweenDates(string supplyPointRef, string startDate, string endDate);
        bool InsertDuosRow(DuosRow row);
    }
}