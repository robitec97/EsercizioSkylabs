using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EsercizioSkylabs.Models;
namespace EsercizioSkylabs.Repositories
{
    public interface IRecordsRepository
    {
        public Task<IEnumerable<RecordsDenormalized>> GetRecords(int offset, int count);

        public IEnumerable<RecordsDenormalized> GetAllRecords();

        public Stats GetStats(string aggregationType, int aggregationFilter);
    }
}
