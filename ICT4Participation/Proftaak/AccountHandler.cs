using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    class AccountHandler
    {
        private List<Vrijwilliger> vrijwilligers = new List<Vrijwilliger>(); 
        private List<HelpBehoevende> helpBehoevenden = new List<HelpBehoevende>();

        public List<Vrijwilliger> Vrijwilligers { get { return vrijwilligers; } }
        public List<HelpBehoevende> HelpBehoevenden { get { return helpBehoevenden; } } 

        public AccountHandler()
        {
            
        }

        public bool AddVrijwilliger()
        {
            return false;
        }

        public bool DelVrijwilliger()
        {
            return false;
        }

        public bool AddHelpbehoevende()
        {
            return false;
        }

        public bool DelHelpbehoevende()
       {
            return false;
        }
    }
}
