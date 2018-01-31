using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProfileRowsService.Persistence;
using ProfileRowsService.Models;
using System;

namespace ProfileRowsService.Controllers
{
    [Route("api/profile")]
    public class ProfileRowsController : Controller
    {
        readonly IProfileRowsRepository _repository;

        public ProfileRowsController(IProfileRowsRepository repository)
            => _repository = repository;

        [HttpGet("mpan/{mpan}/{date}")]
        public IEnumerable<ProfileRow> GetByMpan(string mpan, string date)
            => _repository.GetByMpan(mpan, date);

        [HttpGet("supply/{supplyPointRef}/{date}")]
        public IEnumerable<ProfileRow> GetBySupplyPointRef(string supplyPointRef, string date)
            => _repository.GetBySupplyPointRef(supplyPointRef, date);
    }
}
