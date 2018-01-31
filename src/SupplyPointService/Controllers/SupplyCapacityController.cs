using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SupplyPointService.Persistence;
using System.Linq;
using SupplyPointService.Models;

namespace SupplyPointService.Controllers
{
    [Route("api/capacity")]
    public class SupplyCapacityController : Controller
    {
        readonly ISupplyCapacityRepository _repository;

        public SupplyCapacityController(ISupplyCapacityRepository repository)
            => _repository = repository;

        [HttpGet("mpan/{mpan}")]
        public SupplyCapacity GetByMpan(string mpan)
            => _repository.GetByMpan(mpan).OrderBy(o => o.EffectiveDate).FirstOrDefault();

        [HttpGet("supply/{supplyPointRef}")]
        public SupplyCapacity GetBySupplyPointRef(string supplyPointRef)
            => _repository.GetBySupplyPointRef(supplyPointRef).OrderBy(o => o.EffectiveDate).FirstOrDefault();
    }
}
