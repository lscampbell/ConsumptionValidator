using System.Collections.Generic;
using IndustryDataService.Models;

namespace IndustryDataService.Persistence
{
    public interface IIndependentDistributionNetworkOperatorsRepository
    {
        IEnumerable<IndependentDistributionNetworkOperator> GetAll();
        IEnumerable<IndependentDistributionNetworkOperator> GetByAreaId(int areaId);
        IEnumerable<IndependentDistributionNetworkOperator> GetByArea(string area);
        IEnumerable<IndependentDistributionNetworkOperator> GetByMarketParticipantId(string marketParticipantId);
    }
}
