using System.Collections.Generic;
using SupplyPointService.Models;

namespace SupplyPointService.Persistence
{
    public interface IMpanRepository
    {
        IEnumerable<MeterPointAdministrationNumber> GetAll();
        IEnumerable<MeterPointAdministrationNumber> GetByMpan(string mpan);
        IEnumerable<MeterPointAdministrationNumber> GetBySupplyPointRef(string supplyPointRef);
    }
}
