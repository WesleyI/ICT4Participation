using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    class Review
    {
        private int id;
        private string text;
        private DateTime date;
        private int score;

        public int Id { get { return id; } }
        public string Text { get { return text; } }
        public DateTime Date { get { return date; } }
        public int Score { get { return score; } }

        public Review(int id, string text, DateTime date, int score)
        {
            this.id = id;
            this.text = text;
            this.date = date;
            this.score = score;
        }

        public override string ToString()
        {
            return text + " - " + score;
        }
    }
}
