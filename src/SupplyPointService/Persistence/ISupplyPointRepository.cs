using System.Collections.Generic;
using SupplyPointService.Models;

namespace SupplyPointService.Persistence
{
    public interface ISupplyPointRepository
    {
        IEnumerable<SupplyPoint> GetAll();
        IEnumerable<SupplyPoint> GetByMpan(string mpan);
        IEnumerable<SupplyPoint> GetByRef(string supplyPointRef);
        IEnumerable<SupplyPoint> GetByAccountId(string id);
        IEnumerable<SupplyPoint> GetBySiteId(string id);
        IEnumerable<SupplyPoint> GetBySiteName(string name);
        IEnumerable<SupplyPoint> GetByMarketParticipantId(string marketParticipantId);
    }
}