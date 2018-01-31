using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CustomerService.Persistence;
using CustomerService.Models;

namespace CustomerService.Controllers
{
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
            => _repository = repository;

        [HttpGet]
        public IEnumerable<CustomerName> GetAll()
            => _repository.GetAll();

        [HttpGet("mpan/{mpan}")]
        public IEnumerable<CustomerName> GetByMpan(string mpan)
            => _repository.GetByMpan(mpan);

        [HttpGet("supply/{supplyPointRef}")]
        public IEnumerable<CustomerName> GetBySupplyPointRef(string supplyPointRef)
            => _repository.GetBySupplyPointRef(supplyPointRef);
    }
}
