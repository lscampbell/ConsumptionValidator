using System.Collections.Generic;
using IndustryDataService.Models;

namespace IndustryDataService.Persistence
{
    public interface IDistributionNetworkOperatorRepository
    {
        IEnumerable<DistributionNetworkOperator> GetAll();
        IEnumerable<DistributionNetworkOperator> GetByAreaId(int areaId);
        IEnumerable<DistributionNetworkOperator> GetByArea(string area);
        IEnumerable<DistributionNetworkOperator> GetByMarketParticipantId(string marketParticipantId);
    }
}