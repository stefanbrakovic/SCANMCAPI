using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeretanaAPI.Models
{
    public class User
    {
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private Address address;

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }

        private string telephone;

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        private string mail;

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private UserType userType;

        public UserType UserType
        {
            get { return userType; }
            set { userType = value; }
        }

        private Gender gender;

        public Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private DateTime dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        private DateTime dateOfRegistration;

        public DateTime DateOfRegistration
        {
            get { return dateOfRegistration; }
            set { dateOfRegistration = value; }
        }

        private string cardNumber;

        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }




    }
}
