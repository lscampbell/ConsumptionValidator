using System.Collections.Generic;
using IndustryDataService.Models;
using Dapper;
using System.Data;

namespace IndustryDataService.Persistence
{
    public class IndependentDistributionNetworkOperatorsRepository : IIndependentDistributionNetworkOperatorsRepository
    {
        readonly IDbConnection _connection;

        public IndependentDistributionNetworkOperatorsRepository(IDbConnection connection)
            => _connection = connection;

        public IEnumerable<IndependentDistributionNetworkOperator> GetAll()
            => _connection.Query<IndependentDistributionNetworkOperator>(
                "SELECT * FROM dbo.IDNOs");

        public IEnumerable<IndependentDistributionNetworkOperator> GetByAreaId(int areaId)
            => _connection.Query<IndependentDistributionNetworkOperator>(
                "SELECT * FROM dbo.IDNOs " +
               $"WHERE AreaId = {areaId}");
        
        public IEnumerable<IndependentDistributionNetworkOperator> GetByArea(string area)
            => _connection.Query<IndependentDistributionNetworkOperator>(
                "SELECT * FROM dbo.IDNOs " +
               $"WHERE Area = '{area}'");
        
        public IEnumerable<IndependentDistributionNetworkOperator> GetByMarketParticipantId(string marketParticipantId)
            => _connection.Query<IndependentDistributionNetworkOperator>(
                "SELECT * FROM dbo.IDNOs " +
               $"WHERE MarketParticipantId = '{marketParticipantId}'");
    }
}
