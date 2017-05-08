using System;
using System.Collections.Generic;

namespace TeretanaAPI.Models
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string StreetNumber { get; set; }
    }
}
