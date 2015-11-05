using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    public class HelpRequest
    {
        private int id;
        private string problem;
        private DateTime dateOfCreation;
        private DateTime beginDate;
        private string duration;
        private string urgent;
        private bool accepted;

        public int Id { get { return id; } }
        public string Problem { get { return problem; } set { problem = value; } }
        public DateTime DateOfCreation { get { return dateOfCreation; } }
        public DateTime BeginDate { get { return beginDate; } }
        public string Duration { get { return duration; } }
        public string Urgent { get { return urgent; } }
        public bool Accepted { get { return accepted; } }


        public HelpRequest(int id, string problem, DateTime dateOfCreation, DateTime beginDate, string duration, string urgent)
        {
            this.id = id;
            this.problem = problem;
            this.dateOfCreation = dateOfCreation;
            this.beginDate = beginDate;
            this.duration = duration;
            this.urgent = urgent;
        }

        public HelpRequest(string problem, DateTime dateOfCreation, DateTime beginDate, 
            string duration, string urgent, bool accepted)
        {
            this.problem = problem;
            this.dateOfCreation = dateOfCreation;
            this.beginDate = beginDate;
            this.duration = duration;
            this.urgent = urgent;
            this.accepted = accepted;
        }

        public override string ToString()
        {
            return problem;
        }
    }
}
