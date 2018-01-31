using TotalsService.Models;
using System.Collections.Generic;

namespace TotalsService.Persistence
{
    public interface IEnergyRepository
    {
        IEnumerable<EnergyRow> GetAllByMpan(string mpan);
        IEnumerable<EnergyRow> GetAllBySupplyPointRef(string supplyPointRef);
        IEnumerable<EnergyRow> GetByMpanAndDate(string mpan, string date);
        IEnumerable<EnergyRow> GetBySupplyPointRefAndDate(string supplyPointRef, string date);
        IEnumerable<EnergyRow> GetByMpanBetweenDates(string mpan, string startDate, string endDate);
        IEnumerable<EnergyRow> GetBySupplyPointRefBetweenDates(string supplyPointRef, string startDate, string endDate);
        bool InsertEnergyRow(EnergyRow row);
    }
}