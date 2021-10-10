using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EsercizioSkylabs.Models
{
    public class RecordsDenormalized
    {
        [Key]
        public int id { get; set; }
        public int age { get; set; }
        public int education_num { get; set; }
        public int capital_gain { get; set; }
        public int capital_loss { get; set; }
        public int hours_week { get; set; }
        public bool over_50k { get; set; }
        public string country { get; set; }
        public string race { get; set; }
        public string occupation { get; set; }
        public string relationship { get; set; }
        public string education_level { get; set; }
        public string marital_status { get; set; }
        public string sex { get; set; }

    }
}
