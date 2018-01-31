using System.Collections.Generic;
using IndustryDataService.Models;
using Dapper;
using System.Data;

namespace IndustryDataService.Persistence
{
    public class DistributionNetworkOperatorRepository : IDistributionNetworkOperatorRepository
    {
        readonly IDbConnection _connection;

        public DistributionNetworkOperatorRepository (IDbConnection connection)
            => _connection = connection;

        public IEnumerable<DistributionNetworkOperator> GetAll()
            => _connection.Query<DistributionNetworkOperator>(
                "SELECT * FROM dbo.DBOs");

        public IEnumerable<DistributionNetworkOperator> GetByAreaId(int areaId)
            => _connection.Query<DistributionNetworkOperator>(
                "SELECT * FROM dbo.DBOs " +
               $"WHERE AreaId = {areaId}");
        
        public IEnumerable<DistributionNetworkOperator> GetByArea(string area)
            => _connection.Query<DistributionNetworkOperator>(
                "SELECT * FROM dbo.DBOs " +
               $"WHERE Area = '{area}'");
        
        public IEnumerable<DistributionNetworkOperator> GetByMarketParticipantId(string marketParticipantId)
            => _connection.Query<DistributionNetworkOperator>(
                "SELECT * FROM dbo.DBOs " +
               $"WHERE MarketParticipantId = '{marketParticipantId}'");
    }
}