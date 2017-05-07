using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeretanaAPI.Models
{
    public class Address
    {
        private int addressId;

        public int AddressId
        {
            get { return addressId; }
            set { addressId = value; }
        }

        private String street;

        public String Street
        {
            get { return street; }
            set { street = value; }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private String streetNumber;

        public String StreetNumber
        {
            get { return streetNumber; }
            set { streetNumber = value; }
        }


    }
}
