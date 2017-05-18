using System;
using System.Collections.Generic;

namespace TeretanaAPI.Models
{
    public partial class Uses
    {
        public int UsageId { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public virtual Services Service { get; set; }
    }
}
