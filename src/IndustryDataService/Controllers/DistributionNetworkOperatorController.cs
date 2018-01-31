using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using IndustryDataService.Persistence;
using IndustryDataService.Models;

namespace IndustryDataService.Controllers
{
    [Route("api/dno")]
    public class DistributionNetworkOperatorController : Controller
    {
        readonly IDistributionNetworkOperatorRepository _repository;

        public DistributionNetworkOperatorController(IDistributionNetworkOperatorRepository repository) 
            => _repository = repository;

        [HttpGet]
        public IEnumerable<DistributionNetworkOperator> Get() 
            => _repository.GetAll();

        [HttpGet("id/{areaId}")]
        public IEnumerable<DistributionNetworkOperator> GetByAreaId(int areaId) 
            => _repository.GetByAreaId(areaId);

        [HttpGet("area/{area}")]
        public IEnumerable<DistributionNetworkOperator> GetByArea(string area) 
            => _repository.GetByArea(area);

        [HttpGet("market{marketParticipantId}")]
        public IEnumerable<DistributionNetworkOperator> GetByMarketParticipantId(string marketParticipantId) 
            => _repository.GetByMarketParticipantId(marketParticipantId);

    }
}