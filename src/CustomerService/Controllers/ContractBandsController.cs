using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CustomerService.Persistence;
using CustomerService.Models;
using System;

namespace CustomerService.Controllers
{
    [Route("api/contracts")]
    public class ContractBandsController : Controller
    {
        readonly IContractsRepository _repository;

        public ContractBandsController(IContractsRepository repository)
            => _repository = repository;

        [HttpGet("bands/{customer}/mpan/{mpan}/{date}")]
        public IEnumerable<ContractBand> GetByMpan(string customer, string mpan, string date)
            => _repository.GetByMpan(customer, mpan, date);

        [HttpGet("bands/{customer}/supply/{supplyPointRef}/{date}")]
        public IEnumerable<ContractBand> GetBySupplyPoint(string customer, string supplyPointRef, string date)
            => _repository.GetBySupplyPoint(customer, supplyPointRef, date);

    }
}
