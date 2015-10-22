using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    class HelpHandler
    {
        private static List<HelpRequest> helpRequests = new List<HelpRequest>();
        private static List<Review> reviews = new List<Review>();
        private static List<ChatMessage> chatMessages = new List<ChatMessage>();
        private static List<Answer> answers = new List<Answer>();

        public static List<HelpRequest> HelpRequests { get { return helpRequests; } }
        public static List<Review> Reviews { get { return reviews; } }
        public static List<ChatMessage> ChatMessages { get { return chatMessages; } }
        public static List<Answer> Answers { get { return answers; } }

        public HelpHandler()
        {
            
        }

        public bool AddHelpRequest(HelpRequest helpRequest)
        {
            helpRequests.Add(helpRequest);
            return true;
        }

        public bool AddReview(Review review)
        {
            reviews.Add(review);
            return true;
        }

        public bool AddMeeting()
        {
            return false;
        }

        public bool AddChatMessage(ChatMessage message)
        {
            chatMessages.Add(message);
            return true;
        }

        public List<ChatMessage> GetMesagges()
        {
            return chatMessages;
        }

        public void ClearMessages()
        {
            chatMessages.Clear();
        }

        public bool AddAnswer(Answer answer)
        {
            answers.Add(answer);
            return true;
        }

        public void EditMeeting()
        {
            
        }

        public void EditHelpRequest(HelpRequest helpRequest)
        {

        }

        public void EditReview(Review review)
        {

        }

        public void EditAnswer(Answer answer)
        {

        }

        public void DelHelpRequest(HelpRequest helpRequest)
        {
            helpRequests.Remove(helpRequest);
        }

        public void DelReview(Review review)
        {
            reviews.Remove(review);
        }

        public void DelAnswer(Answer answer)
        {
            answers.Remove(answer);
        }
    }
}
