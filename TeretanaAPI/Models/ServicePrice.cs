using System;
using System.Collections.Generic;

namespace TeretanaAPI.Models
{
    public partial class ServicePrice
    {
        public int ServiceId { get; set; }
        public DateTime DateModified { get; set; }
        public decimal Price { get; set; }

        public virtual Services Service { get; set; }
    }
}
