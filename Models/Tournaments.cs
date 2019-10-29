using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.MVCCoreWeb.Models
{
    public class Tournaments
    {
        [Key]
        public long Id { get; set; }

        public DateTime Date_Time { get; set; }

        public string type { get; set; }

        public string title { get; set; }
        public int Slots { get; set; }

        public double fee { get; set; }

        public double Prize { get; set; }

        public String Details { get; set; }


 
    }
}
