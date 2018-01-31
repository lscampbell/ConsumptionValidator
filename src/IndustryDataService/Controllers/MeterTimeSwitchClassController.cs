using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IndustryDataService.Persistence;
using IndustryDataService.Models;

namespace IndustryDataService.Controllers
{    
    [Route("api/mtc")]
    public class MeterTimeSwitchClassController : Controller
    {
        readonly IMeterTimeSwitchClassRepository _repository;

        public MeterTimeSwitchClassController(IMeterTimeSwitchClassRepository repository) => _repository = repository;

        [HttpGet]
        public IEnumerable<MeterTimeSwitchClass> Get() => _repository.GetAll();
    }
}
