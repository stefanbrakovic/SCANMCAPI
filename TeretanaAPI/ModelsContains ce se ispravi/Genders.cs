using System;
using System.Collections.Generic;

namespace TeretanaAPI.Models
{
    public partial class Genders
    {
        public Genders()
        {
            Users = new HashSet<Users>();
        }

        public int GenderId { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
