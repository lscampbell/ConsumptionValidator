using System.Collections.Generic;
using CustomerService.Models;
using Dapper;
using System.Data;
using System;

namespace CustomerService.Persistence
{
    public class ContractsRepository : IContractsRepository
    {
        readonly IDbConnection _connection;

        public ContractsRepository(IDbConnection connection)
            => _connection = connection;

        public IEnumerable<ContractBand> GetByMpan(string customer, string mpan, string date)
            => _connection.Query<ContractBand>(
                "SELECT * FROM dbo.ContractBands " +
               $"WHERE Mpan = '{mpan}' " +
               $"AND Customer = '{customer}' " +
               $"AND Date = '{date}'");

        public IEnumerable<ContractBand> GetBySupplyPoint(string customer, string supplyPointRef, string date)
            => _connection.Query<ContractBand>(
                "SELECT * FROM dbo.ContractBands " +
               $"WHERE SupplyPointRef = '{supplyPointRef}' " +
               $"AND Customer = '{customer}' " +
               $"AND Date = '{date}'");
    }
}
