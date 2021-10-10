using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EsercizioSkylabs.Repositories;
using EsercizioSkylabs.Models;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

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

        [HttpGet]
        public ActionResult Download()
        {
            List<RecordsDenormalized> recordsToDownload = (List<RecordsDenormalized>)_repository.GetAllRecords();
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));
            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(stream: ms, encoding: System.Text.Encoding.UTF8))
                {
                    using(var cw = new CsvWriter(sw, cc))
                    {
                        cw.WriteRecords(recordsToDownload);
                    }
                    return File(ms.ToArray(), "text/csv", $"export_{DateTime.UtcNow.Ticks}.csv");
                }
            }

            }
    }
}
