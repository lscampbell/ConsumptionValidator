using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SupplyPointService.Persistence;
using SupplyPointService.Models;

namespace SupplyPointService.Controllers
{
    [Route("api/mpan")]
    public class MpanController : Controller
    {
        readonly IMpanRepository _repository;

        public MpanController(IMpanRepository repository)
            => _repository = repository;

        [HttpGet]
        public IEnumerable<MeterPointAdministrationNumber> Get()
            => _repository.GetAll();

        [HttpGet("mpan/{mpan}")]
        public IEnumerable<MeterPointAdministrationNumber> GetByMpan(string mpan)
            => _repository.GetByMpan(mpan);      
    
        [HttpGet("supply/{supplyPointRef}")]
        public IEnumerable<MeterPointAdministrationNumber> GetBySupplyPointRef(string supplyPointRef)
            => _repository.GetBySupplyPointRef(supplyPointRef);
    }
}