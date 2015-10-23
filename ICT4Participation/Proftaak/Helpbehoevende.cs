using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    public class HelpBehoevende
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string wachtwoord;
        private string city;
        private string street;
        private string address;
        private string bio;
        private DateTime dateOfBirth;
        private string phoneNumber;
        private string problem;


        public int Id { get { return id; } }
        public string FirstName { get { return firstName; } }
        public string LastName { get { return lastName; } }
        public string Email { get { return email; } }
        public string Wachtwoord { get { return wachtwoord; } }
        public string City { get { return city; } }
        public string Street { get { return street; } }
        public string Address { get { return address; } }
        public string Bio { get { return bio; } }
        public DateTime DateOfBirth { get { return dateOfBirth; } }
        public string PhoneNumber { get { return phoneNumber; } }
        public string Problem { get { return problem; } }



        public HelpBehoevende(int id, string firstname, string lastname)
        {
            this.id = id;
            this.firstName = firstname;
            this.lastName = lastname;
        }

        public HelpBehoevende(string firstName, string lastName, string email, string wachtwoord, string city, string street,
            string address, string bio, DateTime dateOfBirth, string phoneNumber, string problem)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.wachtwoord = wachtwoord;
            this.city = city;
            this.street = street;
            this.address = address;
            this.bio = bio;
            this.dateOfBirth = dateOfBirth;
            this.phoneNumber = phoneNumber;
            this.problem = problem;
        }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}
