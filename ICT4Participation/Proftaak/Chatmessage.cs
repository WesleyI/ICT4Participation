using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    class ChatMessage
    {
        private int id;
        private string text;
        private DateTime date;
        private int ontvanger;

        public int Id { get { return id; } }
        public string Text { get { return text; } }
        public DateTime Date { get { return date; } }
        public int Ontvanger { get { return ontvanger; } }

        public ChatMessage(string text, DateTime date)
        {
            this.text = text;
            this.date = date;
        }

        public ChatMessage(int id, string text, DateTime date)
        {
            this.id = id;
            this.text = text;
            this.date = date;
        }

        public ChatMessage(int id, string text, DateTime date, int ontvanger)
        {
            this.id = id;
            this.text = text;
            this.date = date;
            this.ontvanger = ontvanger;
        }

        public override string ToString()
        {
            string info = date + ": " + text;
            return info;
        }
    }
}
