using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    public class Meeting
    {
        int id;
        DateTime datum;
        string tekst = "";
        int account;

        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string Tekst { get; set; }
        public int Account { get; set; }

        public Meeting(int id, DateTime datum, string tekst, int account)
        {
            this.id = id;
            this.datum = datum;
            this.tekst = tekst;
            this.account = account;
        }

        public string GetTekst()
        {
            return tekst;
        }

        public override string ToString()
        {
            return "Aanvraag: " + tekst + ", Datum: " + datum + ".";
        }
    }
}
