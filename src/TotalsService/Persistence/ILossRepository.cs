using TotalsService.Models;
using System.Collections.Generic;

namespace TotalsService.Persistence
{
    public interface ILossRepository
    {
        IEnumerable<LossRow> GetAllByMpan(string mpan);
        IEnumerable<LossRow> GetAllBySupplyPointRef(string supplyPointRef);
        IEnumerable<LossRow> GetByMpanAndDate(string mpan, string date);
        IEnumerable<LossRow> GetBySupplyPointRefAndDate(string supplyPointRef, string date);
        IEnumerable<LossRow> GetByMpanBetweenDates(string mpan, string startDate, string endDate);
        IEnumerable<LossRow> GetBySupplyPointRefBetweenDates(string supplyPointRef, string startDate, string endDate);
        bool InsertLossRow(LossRow lossRow);
    }
}