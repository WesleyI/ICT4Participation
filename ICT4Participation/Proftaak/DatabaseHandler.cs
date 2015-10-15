using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    class DatabaseHandler
    {
        private List<Vrijwilliger> vrijwilligers = new List<Vrijwilliger>(); 
        private List<HelpBehoevende> helpBehoevendes = new List<HelpBehoevende>();
        private List<ChatMessage> chatMessages = new List<ChatMessage>();
        private List<Answer> answers = new List<Answer>();
        private List<Review> reviews = new List<Review>();

        public DatabaseHandler()
        {
            
        }

        public void Connect()
        {
            
        }

        public void Disconnect()
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

        public bool AddHelpBehoevende()
        {
            return false;
        }

        public bool DelHelpbehoevende()
        {
            return false;
        }

        public bool AddChatMessage()
        {
            return false;
        }

        public bool AddAnswer()
        {
            return false;
        }

        public bool AddReview()
        {
            return false;
        }

        public bool DelReview()
        {
            return false;
        }

        public void EditReview()
        {
            
        }

        public bool AddMeeting()
        {
            return false;
        }

        public void EditMeeting()
        {
            
        }

        public bool AddHulpVraag()
        {
            return false;
        }

        public void EditHulpVraag()
        {
            
        }
    }
}
