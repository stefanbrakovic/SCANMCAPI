using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeretanaAPI.Models
{
    public class UserType
    {
        //private int userTypeId;

        public int UserTypeId
        {
            get { return userTypeId; }
            set { userTypeId = value; }
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
