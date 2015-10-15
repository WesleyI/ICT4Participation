using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    class Vrijwilliger
    {
        private string firstName;
        private string lastName;
        private string city;
        private string street;
        private string address;
        private string bio;
        private string dateOfBirth;
        private bool car;
        private string phoneNumber;
        private string competences;
        private string availabilty;

        public string FirstName { get { return firstName;} }
        public string LastName { get { return lastName;} }
        public string City { get { return city;} }
        public string Street { get { return street;} }
        public string Address { get { return address;} }
        public string Bio { get { return bio;} }
        public string DateOfBirth { get { return dateOfBirth;} }
        public bool Car { get { return car;} }
        public string PhoneNumber { get { return phoneNumber;} }
        public string Competences { get { return competences;} }
        public string Availability { get { return availabilty; } }
    }
}
