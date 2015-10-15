using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    class Account
    {
        private string email;
        private string password;

        public Account(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public string Email { get { return email; } }

        public string Password { get { return password;} }
    }
}
