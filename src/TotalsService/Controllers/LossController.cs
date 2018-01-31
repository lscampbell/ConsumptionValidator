using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TotalsService.Persistence;
using TotalsService.Models;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;

namespace TotalsService.Controllers
{
    [Route("api/[controller]")]
    public class LossController : Controller
    {
        readonly ILossRepository _repository;

        public LossController(ILossRepository repository)
            => _repository = repository;

        [HttpGet("mpan/{mpan}")]
        public IEnumerable<LossRow> GetByMpan(string mpan) 
            => _repository.GetAllByMpan(mpan);
    
        [HttpGet("mpan/{mpan}/{date}")]
         public IEnumerable<LossRow> GetByMpanAndDate(string mpan, string date) 
            => _repository.GetByMpanAndDate(mpan, date);
   
        [HttpGet("mpan/{mpan}/{startDate}/{endDate}")]
         public IEnumerable<LossRow> GetByMpanBetweenDates(string mpan, string startDate, string endDate) 
            => _repository.GetByMpanBetweenDates(mpan, startDate, endDate);
    
        [HttpGet("supply/{supplyPointRef}")]
        public IEnumerable<LossRow> GetBySupplyPointRef(string supplyPointRef) 
            => _repository.GetAllBySupplyPointRef(supplyPointRef);
    
        [HttpGet("supply/{supplyPointRef}/{date}")]
         public IEnumerable<LossRow> GetBySupplyPointRefAndDate(string supplyPointRef, string date) 
            => _repository.GetBySupplyPointRefAndDate(supplyPointRef, date);
   
        [HttpGet("supply/{supplyPointRef}/{startDate}/{endDate}")]
         public IEnumerable<LossRow> GetBySupplyPointRefBetweenDates(string supplyPointRef, string startDate, string endDate) 
            => _repository.GetBySupplyPointRefBetweenDates(supplyPointRef, startDate, endDate);
        
        [HttpPost]
        public HttpStatusCode Post([FromBody]JArray data)
        {
            foreach (var row in JsonConvert.DeserializeObject<IEnumerable<LossRow>>(data.ToString()))
                _repository.InsertLossRow(row);
            
            return HttpStatusCode.OK;
        }
    }
}