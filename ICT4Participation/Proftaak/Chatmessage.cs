using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    class ChatMessage
    {
        private string text;
        private string date;

        public string Text { get { return text; } }
        public string Date { get { return date; } }

        public ChatMessage(string text, string date)
        {
            this.text = text;
            this.date = date;
        }
    }
}
