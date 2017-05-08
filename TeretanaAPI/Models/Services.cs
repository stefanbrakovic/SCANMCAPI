using System;
using System.Collections.Generic;

namespace TeretanaAPI.Models
{
    public partial class Services
    {
        public Services()
        {
            Contains = new HashSet<Contains>();
            Provides = new HashSet<Provides>();
            Uses = new HashSet<Uses>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }

        public virtual ICollection<Contains> Contains { get; set; }
        public virtual ICollection<Provides> Provides { get; set; }
        public virtual ICollection<Uses> Uses { get; set; }
    }
}
