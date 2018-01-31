using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using IndustryDataService.Persistence;
using IndustryDataService.Models;

namespace IndustryDataService.Controllers
{
    [Route("api/idno")]
    public class IndependentDistributionNetworkOperatorsController : Controller
    {
        readonly IIndependentDistributionNetworkOperatorsRepository _repository;

        public IndependentDistributionNetworkOperatorsController(IIndependentDistributionNetworkOperatorsRepository repository) 
            => _repository = repository;

        [HttpGet]
        public IEnumerable<IndependentDistributionNetworkOperator> Get() 
            => _repository.GetAll();

        [HttpGet("id/{areaId}")]
        public IEnumerable<IndependentDistributionNetworkOperator> GetByAreaId(int areaId) 
            => _repository.GetByAreaId(areaId);

        [HttpGet("area/{area}")]
        public IEnumerable<IndependentDistributionNetworkOperator> GetByArea(string area) 
            => _repository.GetByArea(area);
        
        [HttpGet("market/{marketParticipantId}")]
        public IEnumerable<IndependentDistributionNetworkOperator> GetByMarketParticipantId(string marketParticipantId) 
            => _repository.GetByMarketParticipantId(marketParticipantId);

    }
}