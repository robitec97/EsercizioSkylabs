using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EsercizioSkylabs.Models;
using EsercizioSkylabs.Repositories;
using Microsoft.EntityFrameworkCore;
namespace EsercizioSkylabs.Repositories
{
    public class RecordsRepository : IRecordsRepository
    {
        private readonly DatabaseContext _context;
        public RecordsRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RecordsDenormalized>> GetRecords(int offset, int count)
        {
            var queryResult = from r in _context.RecordsDenormalized where r.id >= offset && r.id <= offset + count select r; //tanto sono gia ordinati per id
            return await queryResult.ToListAsync();
        }

        public IEnumerable<RecordsDenormalized> GetAllRecords()
        {
            return _context.RecordsDenormalized.ToList();
        }

        public Stats GetStats(string aggregationType, int aggregationFilter)
        {
            Stats s = new Stats();
            s.aggregationType = aggregationType;
            s.aggregationFilter = aggregationFilter;
            switch (aggregationType)
            {
                case "age":
                    s.capital_gain_avg = (float)(from r in _context.Records where r.age == s.aggregationFilter select r.capital_gain).Average();
                    s.capital_gain_sum = (float)(from r in _context.Records where r.age == s.aggregationFilter select r.capital_gain).Sum();
                    s.capital_loss_avg = (float)(from r in _context.Records where r.age == s.aggregationFilter select r.capital_loss).Average();
                    s.capital_loss_sum = (float)(from r in _context.Records where r.age == s.aggregationFilter select r.capital_loss).Sum();
                    s.over_50k_count = (from r in _context.Records where r.age == s.aggregationFilter && r.over_50k == true select r).Count();
                    s.under_50k_count = (from r in _context.Records where r.age == s.aggregationFilter && r.over_50k == false select r).Count();
                    break;
                case "education_level_id":
                    s.capital_gain_avg = (float)(from r in _context.Records where r.education_level_id == s.aggregationFilter select r.capital_gain).Average();
                    s.capital_gain_sum = (float)(from r in _context.Records where r.education_level_id == s.aggregationFilter select r.capital_gain).Sum();
                    s.capital_loss_avg = (float)(from r in _context.Records where r.education_level_id == s.aggregationFilter select r.capital_loss).Average();
                    s.capital_loss_sum = (float)(from r in _context.Records where r.education_level_id == s.aggregationFilter select r.capital_loss).Sum();
                    s.over_50k_count = (from r in _context.Records where r.education_level_id == s.aggregationFilter && r.over_50k == true select r).Count();
                    s.under_50k_count = (from r in _context.Records where r.education_level_id == s.aggregationFilter && r.over_50k == false select r).Count();
                    break;
                case "occupation_id":
                    s.capital_gain_avg = (float)(from r in _context.Records where r.occupation_id == s.aggregationFilter select r.capital_gain).Average();
                    s.capital_gain_sum = (float)(from r in _context.Records where r.occupation_id == s.aggregationFilter select r.capital_gain).Sum();
                    s.capital_loss_avg = (float)(from r in _context.Records where r.occupation_id == s.aggregationFilter select r.capital_loss).Average();
                    s.capital_loss_sum = (float)(from r in _context.Records where r.occupation_id == s.aggregationFilter select r.capital_loss).Sum();
                    s.over_50k_count = (from r in _context.Records where r.occupation_id == s.aggregationFilter && r.over_50k == true select r).Count();
                    s.under_50k_count = (from r in _context.Records where r.occupation_id == s.aggregationFilter && r.over_50k == false select r).Count();
                    break;
            }
            return s;
        }

        
    }
}
