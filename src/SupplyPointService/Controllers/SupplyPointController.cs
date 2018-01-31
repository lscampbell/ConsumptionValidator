using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SupplyPointService.Persistence;
using SupplyPointService.Models;

namespace SupplyPointService.Controllers
{
    [Route("api/supply")]
    public class SupplyPointController : Controller
    {
        readonly ISupplyPointRepository _repository;

        public SupplyPointController(ISupplyPointRepository repository) 
            => _repository = repository;

        [HttpGet]
        public IEnumerable<SupplyPoint> Get() 
            => _repository.GetAll();

        [HttpGet("mpan/{mpan}")]
        public IEnumerable<SupplyPoint> GetByMpan(string mpan) 
            => _repository.GetByMpan(mpan);

        [HttpGet("supply/{supplyPointRef}")]
        public IEnumerable<SupplyPoint> GetByRef(string supplyPointRef) 
            => _repository.GetByRef(supplyPointRef);

        [HttpGet("account/{id}")]
        public IEnumerable<SupplyPoint> GetByAccountId(string id) 
            => _repository.GetByAccountId(id);

        [HttpGet("site/{id}")]
        public IEnumerable<SupplyPoint> GetBySiteId(string id) 
            => _repository.GetBySiteId(id);

        [HttpGet("site/{name}")]
        public IEnumerable<SupplyPoint> GetBySiteName(string name) 
            => _repository.GetBySiteName(name);

        [HttpGet("marketParticipantId/{marketParticipantId}")]
        public IEnumerable<SupplyPoint> GetByMarketParticipantId(string marketParticipantId) 
            => _repository.GetByMarketParticipantId(marketParticipantId);
    }
}