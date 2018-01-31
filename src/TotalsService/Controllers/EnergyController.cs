using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TotalsService.Persistence;
using TotalsService.Models;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;

namespace TotalsService.Controllers
{
    [Route("api/[controller]")]
    public class EnergyController
    {
        readonly IEnergyRepository _repository;
        public EnergyController(IEnergyRepository repository)
            => _repository = repository;

        [HttpGet("mpan/{mpan}")]
        public IEnumerable<EnergyRow> GetByMpan(string mpan) 
            => _repository.GetAllByMpan(mpan);
    
        [HttpGet("mpan/{mpan}/{date}")]
         public IEnumerable<EnergyRow> GetByMpanAndDate(string mpan, string date) 
            => _repository.GetByMpanAndDate(mpan, date);
   
        [HttpGet("mpan/{mpan}/{startDate}/{endDate}")]
         public IEnumerable<EnergyRow> GetByMpanBetweenDates(string mpan, string startDate, string endDate) 
            => _repository.GetByMpanBetweenDates(mpan, startDate, endDate);
    
        [HttpGet("supply/{supplyPointRef}")]
        public IEnumerable<EnergyRow> GetBySupplyPointRef(string supplyPointRef) 
            => _repository.GetAllBySupplyPointRef(supplyPointRef);
    
        [HttpGet("supply/{supplyPointRef}/{date}")]
         public IEnumerable<EnergyRow> GetBySupplyPointRefAndDate(string supplyPointRef, string date) 
            => _repository.GetBySupplyPointRefAndDate(supplyPointRef, date);
   
        [HttpGet("supply/{supplyPointRef}/{startDate}/{endDate}")]
         public IEnumerable<EnergyRow> GetBySupplyPointRefBetweenDates(string supplyPointRef, string startDate, string endDate) 
            => _repository.GetBySupplyPointRefBetweenDates(supplyPointRef, startDate, endDate);   

        [HttpPost]
        public HttpStatusCode Post([FromBody]JArray data)
        {
            foreach (var row in JsonConvert.DeserializeObject<IEnumerable<EnergyRow>>(data.ToString()))
                _repository.InsertEnergyRow(row);
            
            return HttpStatusCode.OK;
        }
    }
}