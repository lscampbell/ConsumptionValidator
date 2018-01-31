using System.Collections.Generic;
using SupplyPointService.Models;
using Dapper;
using System.Data;

namespace SupplyPointService.Persistence
{
    public class SupplyCapacityRepository : ISupplyCapacityRepository
    {
        readonly IDbConnection _connection;

        public SupplyCapacityRepository(IDbConnection connection)
            => _connection = connection;

        public IEnumerable<SupplyCapacity> GetByMpan(string mpan)
            => _connection.Query<SupplyCapacity>("SELECT * FROM dbo.SupplyCapacity " +
                                   $"WHERE Mpan = '{mpan}'");

        public IEnumerable<SupplyCapacity> GetBySupplyPointRef(string supplyPointRef)
            => _connection.Query<SupplyCapacity>("SELECT * FROM dbo.SupplyCapacity " +
                                   $"WHERE SupplyPointRef = '{supplyPointRef}' ");
    
    }
}
