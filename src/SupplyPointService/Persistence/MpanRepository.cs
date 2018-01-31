using System.Collections.Generic;
using SupplyPointService.Models;
using Dapper;
using System.Data;

namespace SupplyPointService.Persistence
{
    public class MpanRepository : IMpanRepository
    {
        readonly IDbConnection _connection;

        public MpanRepository(IDbConnection connection)
            => _connection = connection;

        public IEnumerable<MeterPointAdministrationNumber> GetAll()
            => _connection.Query<MeterPointAdministrationNumber>(
                 "SELECT * FROM dbo.MPANs");

        public IEnumerable<MeterPointAdministrationNumber> GetByMpan(string mpan)
            => _connection.Query<MeterPointAdministrationNumber>(
                 "SELECT * FROM dbo.MPANs " +
                $"WHERE Mpan = '{mpan}'");

        public IEnumerable<MeterPointAdministrationNumber> GetBySupplyPointRef(string supplyPointRef)
            => _connection.Query<MeterPointAdministrationNumber>(
                 "SELECT * FROM dbo.MPANs " +
                $"WHERE SupplyPointRef = '{supplyPointRef}'");
    }
}
