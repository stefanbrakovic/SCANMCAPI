using System;
using System.Collections.Generic;

namespace TeretanaAPI.Models
{
    public partial class Contains
    {
        public int ContainsId { get; set; }
        public DateTime? DateAdded { get; set; }
        public decimal Discount { get; set; }
        public int ServiceId { get; set; }
        public int PackageId { get; set; }

        public virtual Packages Package { get; set; }
        public virtual Services Service { get; set; }
    }
}
