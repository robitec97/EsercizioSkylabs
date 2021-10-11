using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsercizioSkylabs.Models
{
    public class Records
    {
        public int id { get; set; }
        public int age { get; set; }
        public int workclass_id { get; set; }
        public int education_level_id {get; set;}
        public int education_num { get; set; }
        public int marital_status { get; set; }
        public int occupation_id { get; set; }
        public int race_id { get; set; }
        public int sex_id { get; set; }
        public int capital_gain { get; set; }
        public int capital_loss { get; set; }
        public int hours_week { get; set; }
        public int country_id { get; set; }
        public bool over_50k { get; set; }

    }
}
