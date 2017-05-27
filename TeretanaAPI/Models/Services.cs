using System;
using System.Collections.Generic;

namespace TeretanaAPI.Models
{
    public partial class Services
    {
        public Services()
        {
            Provides = new HashSet<Provides>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public byte IsActive { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<Provides> Provides { get; set; }
        public virtual ServicePrice ServicePrice { get; set; }
    }
}
