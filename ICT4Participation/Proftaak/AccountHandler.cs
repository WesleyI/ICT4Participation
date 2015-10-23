using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    class AccountHandler
    {
        private static List<Vrijwilliger> vrijwilligers = new List<Vrijwilliger>(); 
        private static List<HelpBehoevende> helpBehoevenden = new List<HelpBehoevende>();
        private static List<HelpRequest> helpRequests = new List<HelpRequest>();

        public static List<Vrijwilliger> Vrijwilligers { get { return vrijwilligers; } }
        public static List<HelpBehoevende> HelpBehoevenden { get { return helpBehoevenden; } }
        public static List<HelpRequest> HelpRequests { get { return helpRequests; } }

        public AccountHandler()
        {
            
        }

        public void AddVrijwilliger(Vrijwilliger vrijwilliger)
        {
            vrijwilligers.Add(vrijwilliger);
        }

        public void DelVrijwilliger()
        {
        }

        public void AddHelpbehoevende(HelpBehoevende helpbehoevende)
        {
            helpBehoevenden.Add(helpbehoevende);
        }

        public void DelHelpbehoevende()
       {

        }
    }
}
