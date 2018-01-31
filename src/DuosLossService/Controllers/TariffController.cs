using DuosLossService.Persistence;
using DuosLossService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace DuosLossService.Controllers
{
    [Route("api/tariffs")]
    public class TariffController : Controller
    {
        readonly ITariffRepository _repository;
        public TariffController(ITariffRepository repository) 
            => _repository = repository;

        [HttpGet]
        public string Get() => "Ping";

        [HttpGet("{marketParticipantId}/{llf}/{date}")]
        public IEnumerable<Tariff> GetAll(string marketParticipantId, string llf, DateTime date) 
            => _repository.GetAll(marketParticipantId, llf, date);
    }
}