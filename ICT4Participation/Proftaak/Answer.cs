using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    class Answer
    {
        private int id;
        private string text;
        private DateTime date;

        public int Id { get { return id; } }
        public string Text { get { return text; } }
        public DateTime Date { get { return date; } }

        public Answer(int id, string text, DateTime date)
        {
            this.id = id;
            this.text = text;
            this.date = date;
        }

    }
}
