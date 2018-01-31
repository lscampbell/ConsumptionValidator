using System.Collections.Generic;
using CustomerService.Models;
using Dapper;
using System.Data;

namespace CustomerService.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly IDbConnection _connection;

        public CustomerRepository(IDbConnection connection)
            => _connection = connection;

        public IEnumerable<CustomerName> GetAll()
            => _connection.Query<CustomerName>(
                "SELECT * FROM dbo.Customer");

        public IEnumerable<CustomerName> GetByMpan(string mpan)
            => _connection.Query<CustomerName>(
                "SELECT * FROM dbo.Customer " +
               $"WHERE Mpan = '{mpan}'");

        public IEnumerable<CustomerName> GetBySupplyPointRef(string supplyPointRef)
            => _connection.Query<CustomerName>(
                "SELECT * FROM dbo.Customer " +
               $"WHERE SupplyPointRef = '{supplyPointRef}'");
    }
}
