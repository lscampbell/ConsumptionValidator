using System.Collections.Generic;
using SupplyPointService.Models;

namespace SupplyPointService.Persistence
{
    public interface ISupplyCapacityRepository
    {
        IEnumerable<SupplyCapacity> GetByMpan(string mpan);
        IEnumerable<SupplyCapacity> GetBySupplyPointRef(string supplyPointRef);
    }
}
