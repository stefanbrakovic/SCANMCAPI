using System;
using System.Collections.Generic;

namespace TeretanaAPI.Models
{
    public partial class UserTypes
    {
        public UserTypes()
        {
            Users = new HashSet<Users>();
        }

        public int UserTypeId { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
