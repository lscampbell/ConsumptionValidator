using DuosLossService.Persistence;
using DuosLossService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace DuosLossService.Controllers
{
    [Route("api/timebands")]
    public class TimeBandController : Controller
    {
        readonly ITimeBandRepository _repository;
        public TimeBandController(ITimeBandRepository repository) 
            => _repository = repository;
        
        [HttpGet]
        public string Get() => "Ping";
        
        [HttpGet("{marketParticipantId}/{date}")]
        public IEnumerable<TimeBand> GetAll(string marketParticipantId, DateTime date) 
            => _repository.GetAll(marketParticipantId, date);
    }
}