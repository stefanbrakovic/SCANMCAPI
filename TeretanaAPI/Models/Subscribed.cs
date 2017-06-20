using System;

namespace TeretanaAPI.Models
{
    public class Subscribed
    {
        public int SubscribedId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int UserId { get; set; }
        public int PackageId { get; set; }

        public virtual Packages Package { get; set; }
        public virtual Users User { get; set; }
    }
}