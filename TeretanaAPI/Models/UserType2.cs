using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeretanaAPI.Models
{
    public class UserType2
    {
        private int userId;

        public int UserID
        {
            get { return userId; }
            set { userId = value; }
        }

        private string typeName;

        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        private string typeDescription;

        public string TypeDescription
        {
            get { return typeDescription; }
            set { typeDescription = value; }
        }

    }
}
