using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsercizioSkylabs
{
    public class Stats
    {
        public string aggregationType { get; set; }
        public int aggregationFilter { get; set; }
        public float capital_gain_sum { get; set; }
        public float capital_gain_avg { get; set; }
        public float capital_loss_sum { get; set; }
        public float capital_loss_avg { get; set; }
        public int over_50k_count { get; set; }
        public int under_50k_count { get; set; }


    }
}
