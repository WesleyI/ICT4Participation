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

        public void AddHelpRequest(HelpRequest helpRequest)
        {
            helpRequests.Add(helpRequest);
        }

        public void AddReview(Review review)
        {
            reviews.Add(review);
        }

        public void AddMeeting()
        {

        }

        public void AddChatMessage(ChatMessage message)
        {
            chatMessages.Add(message);
        }

        public List<ChatMessage> GetMesagges()
        {
            return chatMessages;
        }

        public void ClearMessages()
        {
            chatMessages.Clear();
        }

        public void AddAnswer(Answer answer)
        {
            answers.Add(answer);
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
