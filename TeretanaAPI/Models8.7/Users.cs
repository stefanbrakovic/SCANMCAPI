using System;
using System.Collections.Generic;

namespace TeretanaAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            Provides = new HashSet<Provides>();
            Subscribed = new HashSet<Subscribed>();
            Uses = new HashSet<Uses>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }
        public string UserPassword { get; set; }
        public int UserTypeId { get; set; }
        public int GenderId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfRegistration { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string StreetNumber { get; set; }
        public string CardNumber { get; set; }

        public virtual ICollection<Provides> Provides { get; set; }
        public virtual ICollection<Subscribed> Subscribed { get; set; }
        public virtual ICollection<Uses> Uses { get; set; }
    }
}
