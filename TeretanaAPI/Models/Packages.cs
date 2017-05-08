using System;
using System.Collections.Generic;

namespace TeretanaAPI.Models
{
    public partial class Packages
    {
        public Packages()
        {
            Contains = new HashSet<Contains>();
            Subscribed = new HashSet<Subscribed>();
        }

        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string PackageDescription { get; set; }

        public virtual ICollection<Contains> Contains { get; set; }
        public virtual ICollection<Subscribed> Subscribed { get; set; }
    }
}
