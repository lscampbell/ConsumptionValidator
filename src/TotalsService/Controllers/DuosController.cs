using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TotalsService.Persistence;
using TotalsService.Models;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TotalsService.Controllers
{
    [Route("api/[controller]")]
    public class DuosController : Controller
    {
        readonly IDuosRepository _repository;

        public DuosController(IDuosRepository repository)
            => _repository = repository;

        [HttpGet("mpan/{mpan}")]
        public IEnumerable<DuosRow> GetByMpan(string mpan) 
            => _repository.GetAllByMpan(mpan);
    
        [HttpGet("mpan/{mpan}/{date}")]
         public IEnumerable<DuosRow> GetByMpanAndDate(string mpan, string date) 
            => _repository.GetByMpanAndDate(mpan, date);
   
        [HttpGet("mpan/{mpan}/{startDate}/{endDate}")]
         public IEnumerable<DuosRow> GetByMpanBetweenDates(string mpan, string startDate, string endDate) 
            => _repository.GetByMpanBetweenDates(mpan, startDate, endDate);
    
        [HttpGet("supply/{supplyPointRef}")]
        public IEnumerable<DuosRow> GetBySupplyPointRef(string supplyPointRef) 
            => _repository.GetAllBySupplyPointRef(supplyPointRef);
    
        [HttpGet("supply/{supplyPointRef}/{date}")]
         public IEnumerable<DuosRow> GetBySupplyPointRefAndDate(string supplyPointRef, string date) 
            => _repository.GetBySupplyPointRefAndDate(supplyPointRef, date);
   
        [HttpGet("supply/{supplyPointRef}/{startDate}/{endDate}")]
         public IEnumerable<DuosRow> GetBySupplyPointRefBetweenDates(string supplyPointRef, string startDate, string endDate) 
            => _repository.GetBySupplyPointRefBetweenDates(supplyPointRef, startDate, endDate);   

        [HttpPost]
        public HttpStatusCode Post([FromBody]JArray data)
        {
            foreach (var row in JsonConvert.DeserializeObject<IEnumerable<DuosRow>>(data.ToString()))
                _repository.InsertDuosRow(row);
            
            return HttpStatusCode.OK;
        }
    }
}