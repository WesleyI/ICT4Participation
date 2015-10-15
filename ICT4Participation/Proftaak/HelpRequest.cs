using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    class HelpRequest
    {
        private string problem;
        private string dateOfCreation;
        private string beginDate;
        private string duration;
        private string urgent;
        private bool accepted;

        public string Problem { get { return problem; } }
        public string DateOfCreation { get { return dateOfCreation; } }
        public string BeginDate { get { return beginDate; } }
        public string Duration { get { return duration; } }
        public string Urgent { get { return urgent; } }
        public bool Accepted { get { return accepted; } }
    }
}
