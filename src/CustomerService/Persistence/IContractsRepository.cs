using System;
using System.Collections.Generic;
using CustomerService.Models;

namespace CustomerService.Persistence
{
    public interface IContractsRepository
    {
        IEnumerable<ContractBand> GetByMpan(string customer, string mpan, string date);
        IEnumerable<ContractBand> GetBySupplyPoint(string customer, string supplyPointRef, string date);
    }
}