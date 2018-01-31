using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IndustryDataService.Persistence;
using IndustryDataService.Models;

namespace IndustryDataService.Controllers
{
    [Route("api/pc")]
    public class ProfileClassController : Controller
    {
        readonly IProfileClassRepository _repository;

        public ProfileClassController(IProfileClassRepository repository) => _repository = repository;

        [HttpGet]
        public IEnumerable<ProfileClass> Get() => _repository.GetAll();
    }
}