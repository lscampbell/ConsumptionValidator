using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DistTransLossService.Persistence;
using DistTransLossService.Models;

namespace DistTransLossService.Controllers
{
    [Route("api/distribution")]
    public class DistributionController : Controller
    {
        readonly IDistributionRepository _repository;

        public DistributionController(IDistributionRepository repository) 
            => _repository = repository;

        [HttpGet("{marketParticipantId}/{llf}/{date}")]
        public IEnumerable<Distribution> Get(string marketParticipantId, string llf, string date) 
            => _repository.GetAll(marketParticipantId, llf, date);
    }
}
