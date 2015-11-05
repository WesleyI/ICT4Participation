using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    static class HelpHandler
    {
        private static List<HelpRequest> helpRequests = new List<HelpRequest>();
        private static List<Review> reviews = new List<Review>();
        private static List<ChatMessage> chatMessages = new List<ChatMessage>();
        private static List<Answer> answers = new List<Answer>();
        private static List<Meeting> meetings = new List<Meeting>();

        public static List<HelpRequest> HelpRequests { get { return helpRequests; } }
        public static List<Review> Reviews { get { return reviews; } }
        public static List<ChatMessage> ChatMessages { get { return chatMessages; } }
        public static List<Answer> Answers { get { return answers; } }
        public static List<Meeting> Meetings { get { return meetings; } }

        static public void AddHelpRequest(HelpRequest helpRequest)
        {
            helpRequests.Add(helpRequest);
        }

        static public void AddReview(Review review)
        {
            reviews.Add(review);
        }

        static public void AddMeeting()
        {

        }

        static public void AddChatMessage(ChatMessage message)
        {
            chatMessages.Add(message);
        }

        static public List<ChatMessage> GetMesagges()
        {
  
            ChatMessages.Sort((x,y) => DateTime.Compare(x.Date, y.Date));
            return ChatMessages;
        }

        static public void ClearMessages()
        {
            chatMessages.Clear();
        }

        static public void AddAnswer(Answer answer)
        {
            answers.Add(answer);
        }

        static public void EditMeeting()
        {
            
        }

        static public void EditHelpRequest(HelpRequest helpRequest)
        {

        }

        static public void EditReview(Review review)
        {

        }

        static public void EditAnswer(Answer answer)
        {

        }

        static public void DelHelpRequest(HelpRequest helpRequest)
        {
            helpRequests.Remove(helpRequest);
        }

        static public void DelReview(Review review)
        {
            reviews.Remove(review);
        }

        static public void DelAnswer(Answer answer)
        {
            answers.Remove(answer);
        }

        static public List<HelpRequest> GetAllHelpRequests()
        {
            return HelpRequests;
        }

        static public void AddMeeting(Meeting meeting)
        {
            meetings.Add(meeting);
        }

        static public List<Meeting> GetAllMeetings()
        {
            return meetings;
        }

        static public List<Review> GetAllReviews()
        {
            return reviews;
        }
    }
}
