using System;
using System.Collections.Generic;

namespace TeretanaAPI.Models
{
    public partial class UserProfile
    {
        public int UserProfileId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }
        public int? NumberOfUsedTermins { get; set; }
        public int UserTypeId { get; set; }
        public DateTime? DateOfRegistration { get; set; }
        public string CardNumber { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
