using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    public class Vrijwilliger
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
        private string vervoer;
        private string phoneNumber;
        private string competences;
        private string availabilty;
        private string locatieVOG;
        private string locatiePhoto;

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
        public string Vervoer { get { return vervoer; } }
        public string PhoneNumber { get { return phoneNumber; } }
        public string Competences { get { return competences; } }
        public string Availability { get { return availabilty; } }
        public string LocatieVOG { get { return locatieVOG; } }
        public string LocatiePhoto { get { return locatiePhoto; } }


        public Vrijwilliger(int id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;

        }

        public Vrijwilliger(string firstName, string lastName, string email, string wachtwoord, string city, string street, string address, string bio,
            DateTime dateOfBirth, string vervoer, string phoneNumber, string competences, string availabilty, string locatieVOG, string locatiePhoto)
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
            this.vervoer = vervoer;
            this.phoneNumber = phoneNumber;
            this.competences = competences;
            this.availabilty = availabilty;
            this.locatieVOG = locatieVOG;
            this.locatiePhoto = locatiePhoto;
        }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}
