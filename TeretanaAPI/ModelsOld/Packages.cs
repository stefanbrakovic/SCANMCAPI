using System;
using System.Collections.Generic;

namespace TeretanaAPI.Models
{
    public partial class Packages
    {
        public Packages()
        {
            Subscribed = new HashSet<Subscribed>();
        }

        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string PackageDescription { get; set; }
        public byte[] IsActive { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<Subscribed> Subscribed { get; set; }
    }
}
