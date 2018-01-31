using System;
using System.Collections.Generic;
using ProfileRowsService.Models;
using Dapper;
using System.Data;

namespace ProfileRowsService.Persistence
{
    public class ProfileRowsRepository : IProfileRowsRepository
    {
        readonly IDbConnection _connection;

        public ProfileRowsRepository(IDbConnection connection)
            => _connection = connection;

        public IEnumerable<ProfileRow> GetByMpan(string mpan, string date) 
            => _connection.Query<ProfileRow>(
                "SELECT * FROM dbo.ProfileRows " +
               $"WHERE Mpan = '{mpan}'" +
               $"AND Date = '{date}'");

        public IEnumerable<ProfileRow> GetBySupplyPointRef(string supplyPointRef, string date)
            => _connection.Query<ProfileRow>(
                "SELECT * FROM dbo.ProfileRows " +
               $"WHERE SupplyPointRef = '{supplyPointRef}'" +
               $"AND Date = '{date}'");
    }
}