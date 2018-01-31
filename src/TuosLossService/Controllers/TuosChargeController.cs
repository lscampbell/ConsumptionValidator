using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TuosLossService.Persistence;
using TuosLossService.Models;

namespace TuosLossService.Controllers
{
    [Route("api/tuosCharge")]
    public class TuosLossController : Controller
    {
        readonly ITuosChargeRepository _repository;
        public TuosLossController(ITuosChargeRepository repository) 
            => _repository = repository;

        [HttpGet("{marketParticipantId}/{date}")]
        public IEnumerable<TuosCharge> GetAll(string marketParticipantId, string date) 
            => _repository.GetAll(marketParticipantId, date);
    }
}