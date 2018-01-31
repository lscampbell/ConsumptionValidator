using System.Collections.Generic;
using CustomerService.Models;

namespace CustomerService.Persistence
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerName> GetAll();
        IEnumerable<CustomerName> GetByMpan(string mpan);
        IEnumerable<CustomerName> GetBySupplyPointRef(string supplyPointRef);
    }
}
