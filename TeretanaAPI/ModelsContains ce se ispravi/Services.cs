using System;
using System.Collections.Generic;

namespace TeretanaAPI.Models
{
    public partial class Services
    {
        public Services()
        {
            Contains = new HashSet<Contains>();
            ServicePrice = new HashSet<ServicePrice>();
            Uses = new HashSet<Uses>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public byte IsActive { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<Contains> Contains { get; set; }
        public virtual ICollection<ServicePrice> ServicePrice { get; set; }
        public virtual ICollection<Uses> Uses { get; set; }
    }
}
