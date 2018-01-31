using System.Collections.Generic;
using SupplyPointService.Models;
using Dapper;
using System.Data;

namespace SupplyPointService.Persistence
{
    public class SupplyPointRepository : ISupplyPointRepository
    {
        readonly IDbConnection _connection;

        public SupplyPointRepository(IDbConnection connection)
            => _connection = connection;

        public IEnumerable<SupplyPoint> GetAll()
            => _connection.Query<SupplyPoint>(
                "SELECT * FROM dbo.SupplyPoint");

        public IEnumerable<SupplyPoint> GetByMpan(string mpan)
                => _connection.Query<SupplyPoint>(
                "SELECT * FROM dbo.SupplyPoint " +
                $"WHERE Mpan = '{mpan}'");

        public IEnumerable<SupplyPoint> GetByRef(string supplyPointRef)
                        => _connection.Query<SupplyPoint>(
                "SELECT * FROM dbo.SupplyPoint " +
                $"WHERE SupplyPointRef = '{supplyPointRef}'");

        public IEnumerable<SupplyPoint> GetByAccountId(string id)
            => _connection.Query<SupplyPoint>(
                "SELECT * FROM dbo.SupplyPoint " +
                $"WHERE AccountId = '{id}'");

        public IEnumerable<SupplyPoint> GetBySiteId(string id)
                        => _connection.Query<SupplyPoint>(
                "SELECT * FROM dbo.SupplyPoint " +
                $"WHERE SupplierId = '{id}'");

        public IEnumerable<SupplyPoint> GetBySiteName(string name)
                        => _connection.Query<SupplyPoint>(
                "SELECT * FROM dbo.SupplyPoint " +
                $"WHERE SupplierName = '{name}'");

        public IEnumerable<SupplyPoint> GetByMarketParticipantId(string marketParticipantId)
        => _connection.Query<SupplyPoint>(
                "SELECT * FROM dbo.SupplyPoint " +
                $"WHERE MarketParticipantId = '{marketParticipantId}'");
    }
}