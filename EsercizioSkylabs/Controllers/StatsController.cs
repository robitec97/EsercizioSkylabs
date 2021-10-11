using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EsercizioSkylabs.Repositories;
namespace EsercizioSkylabs.Controllers
{
    [Route("api/stats")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IRecordsRepository _repository;

        public StatsController(IRecordsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{aggregationType}/{aggregationFilter}")]
        public ActionResult<Stats> GetStats(string aggregationType, int aggregationFilter)
        {
            return _repository.GetStats(aggregationType, aggregationFilter);
        }
    }
}
