using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DistTransLossService.Persistence;
using DistTransLossService.Models;

namespace DistTransLossService.Controllers
{
    [Route("api/transmission")]
    public class TransmissionController : Controller
    {
        readonly ITransmissionRepository _repository;
        public TransmissionController(ITransmissionRepository repository) 
            => _repository = repository;

        [HttpGet]
        public Transmission Get() 
            => _repository.GetAll()
                          .OrderBy(s => s.EffectiveDate)
                          .First();
    }
}
