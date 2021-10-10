using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EsercizioSkylabs.Repositories;
using EsercizioSkylabs.Models;
namespace EsercizioSkylabs.Controllers
{
    [Route("api/records")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordsRepository _repository;
        public RecordsController(IRecordsRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("{offset}/{count}")]
        public async Task<IEnumerable<RecordsDenormalized>> GetRecordsDenormalized(int offset, int count)
        {
            return await _repository.GetRecords(offset, count);
        }
    }
}
