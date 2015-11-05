using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Proftaak
{
    public partial class VrijwilligerForm : Form
    {
        AccountHandler account = new AccountHandler(); // Toegang tot de lijsten van de AccountHandler.

        private string email;
        private string voornaam;
        private string achternaam;
        private int id;

        public VrijwilligerForm(string email, string voornaam, string achternaam, int id)
        {
            InitializeComponent();
            this.email = email;
            this.voornaam = voornaam;
            this.achternaam = achternaam;
            this.id = id;
            timer1.Start();

            lblUsername.Text = voornaam + " " + achternaam;

            RefreshOverzicht();

            DatabaseHandler.GetHulpBehoevende();
            foreach (HelpBehoevende h in AccountHandler.HelpBehoevenden) // Alle hulpbehoevenden die zijn aangemaakt worden in de lijst getoond.
            {
                lbHulpbehoevende.Items.Add(h.ToString());
            }

            RefreshListboxes();
        }

        public void RefreshList()
        {
            lbChatmessage.Items.Clear();

            foreach (ChatMessage c in HelpHandler.GetMesagges())
            {
                lbChatmessage.Items.Add(c);
            }
        }

        private void btSendMessage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbChatmessage.Text))
            {
                string bericht = tbChatmessage.Text;
                DateTime datum = DateTime.Now;

                if (lbHulpbehoevende.SelectedItem != null)
                {
                    foreach (HelpBehoevende hb in AccountHandler.HelpBehoevenden)
                    {
                        if (hb.ToString() == (string)lbHulpbehoevende.SelectedItem)
                        {
                            DatabaseHandler.AddChatMessage(bericht, datum, 1, hb.Id);
                            ChatMessage chatMessage = new ChatMessage(bericht, datum);
                            HelpHandler.AddChatMessage(chatMessage);
                            lbChatmessage.Items.Add(chatMessage.ToString());
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Vul een chatbericht in");
            }
        }

        /// <summary>
        /// Haalt alle berichten op van de geselecteerde hulpbehoevende
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbHulpbehoevende_SelectedIndexChanged(object sender, EventArgs e)
        {
            HelpHandler.ClearMessages();
            lbChatmessage.Items.Clear();

            DatabaseHandler.GetChatAfzender(1);
            DatabaseHandler.GetChatOntvanger(1);

            if (lbHulpbehoevende.SelectedItem != null)
            {
                foreach (HelpBehoevende hb in AccountHandler.HelpBehoevenden)
                {
                    if (hb.ToString() == (string)lbHulpbehoevende.SelectedItem)
                    {


                        foreach (ChatMessage c in HelpHandler.GetMesagges())
                        {
                            if(hb.Id == c.Ontvanger)
                            {
                                lbChatmessage.Items.Add(c.ToString());
                            }
                        }
                    }
                }
            }
        }

        //TODO: BERICHTEN OPHALEN VAN AFZENDER
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            HelpHandler.ClearMessages();
            lbChatmessage.Items.Clear();

            DatabaseHandler.GetChatAfzender(1);
            DatabaseHandler.GetChatOntvanger(1);

            if (lbHulpbehoevende.SelectedItem != null)
            {
                foreach (HelpBehoevende hb in AccountHandler.HelpBehoevenden)
                {
                    if (hb.ToString() == (string)lbHulpbehoevende.SelectedItem)
                    {
                        foreach (ChatMessage c in HelpHandler.GetMesagges())
                        {
                            if (hb.Id == c.Ontvanger)
                            {
                                lbChatmessage.Items.Add(c.ToString());
                            }
                            if(hb.Id == c.Verzender)
                            {
                                lbChatmessage.Items.Add(c.ToString());
                            }
                        }
                    }
                }
            }
        }

        private void RefreshListboxes()
        {
            lbHelpRequest.Items.Clear();
            lbMeeting.Items.Clear();
            lbReview.Items.Clear();
            HelpHandler.HelpRequests.Clear();
            DatabaseHandler.GetHulpVraag();
            List<HelpRequest> requests = HelpHandler.GetAllHelpRequests();
            foreach (HelpRequest hulpvraag in requests)
            {
                if (hulpvraag.Accepted == false)
                {
                    lbHelpRequest.Items.Add(hulpvraag.ToString());
                }
            }
            HelpHandler.Meetings.Clear();
            DatabaseHandler.GetMeeting();
            List<Meeting> meetings = HelpHandler.GetAllMeetings();
            foreach (Meeting meeting in meetings)
            {

                //lbMeeting.Items.Add(meeting.GetTekst());
            }
            HelpHandler.Reviews.Clear();
            DatabaseHandler.GetReview();
            List<Review> reviews = HelpHandler.GetAllReviews();
            foreach (Review review in reviews)
            {
                string accountnaam = DatabaseHandler.GetAccountNaam(this.id);
                lbReview.Items.Add(accountnaam + ": " + review.Text);
            }
        }

        private void RefreshOverzicht()
        {
            lbAcceptedHelpRequest.Items.Clear();
            //int aantal = DatabaseHandler.CountAcceptedHelpRequests(this.id);
            List<HelpRequest> requests = DatabaseHandler.GetAcceptedHelpRequests(this.id);
            foreach (HelpRequest request in requests)
            {
                lbAcceptedHelpRequest.Items.Add(request.ToString());
            }

            List<Meeting> meetings = DatabaseHandler.GetAcceptedMeetings(this.id);
            foreach (Meeting meeting in meetings)
            {
                lbAcceptedMeetings.Items.Add(meeting.ToString());
            }

        }

        private void btnAcceptHelpRequest_Click(object sender, EventArgs e)
        {
            int index = lbHelpRequest.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Klik eerst een hulpvraag aan!");
                return;
            }
            List<HelpRequest> requests = HelpHandler.GetAllHelpRequests();
            bool gelukt = DatabaseHandler.AcceptHelpRequest(this.id, (requests[index].Id + 1));
            if (gelukt)
            {
                MessageBox.Show("Het accepteren van de Helprequest is gelukt.");
            }
            else
            {
                MessageBox.Show("Het accepteren van de Helprequest is niet gelukt.");
            }
            RefreshListboxes();
            RefreshOverzicht();

        }

        private void lbHelpRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbHelpRequest.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("kun jij niet raak klikken?");
                return;
            }
            List<HelpRequest> requests = HelpHandler.GetAllHelpRequests();
            string problem = requests[index].Problem.ToString();
            string beginDatum = requests[index].BeginDate.ToString();
            string lengte = requests[index].Duration.ToString();
            string aangemaakt = requests[index].DateOfCreation.ToString();
            string Urgent = requests[index].Urgent.ToString();
            string urgent = "Niet urgent";

            lbExtraInfo.Items.Clear();

            lbExtraInfo.Items.Add("Het probleem: " + problem);
            lbExtraInfo.Items.Add("Vanaf: " + beginDatum);
            lbExtraInfo.Items.Add("Tot: " + beginDatum);
            lbExtraInfo.Items.Add("Aangemaakt op: " + aangemaakt);
            if (Urgent == "Y")
            {
                urgent = "Wel urgent";
            }
            else if (Urgent == "N")
            {
                urgent = "Niet urgent";
            }
            lbExtraInfo.Items.Add("Urgentie: " + urgent);


        }

        private void btnAcceptMeeting_Click(object sender, EventArgs e)
        {
            int index = lbHelpRequest.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Klik eerst een hulpvraag aan!");
                return;
            }
            List<HelpRequest> requests = HelpHandler.GetAllHelpRequests();
            bool gelukt = DatabaseHandler.AcceptHelpRequest(this.id, (requests[index].Id + 1));
            if (gelukt)
            {
                MessageBox.Show("Het accepteren van de Helprequest is gelukt.");
            }
            else
            {
                MessageBox.Show("Het accepteren van de Helprequest is niet gelukt.");
            }
            RefreshListboxes();
            RefreshOverzicht();
        }

        private void lbAcceptedHelpRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbAcceptedHelpRequest.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("kun jij niet raak klikken?");
                return;
            }
            List<HelpRequest> requests = HelpHandler.GetAllHelpRequests();
            string problem = requests[index].Problem.ToString();
            string beginDatum = requests[index].BeginDate.ToString();
            string lengte = requests[index].Duration.ToString();
            string aangemaakt = requests[index].DateOfCreation.ToString();
            string Urgent = requests[index].Urgent.ToString();
            string urgent = "Niet urgent";

            lbExtraInfoAccepted.Items.Clear();

            lbExtraInfoAccepted.Items.Add("Het probleem: " + problem);
            lbExtraInfoAccepted.Items.Add("Vanaf: " + beginDatum);
            lbExtraInfoAccepted.Items.Add("Tot: " + beginDatum);
            lbExtraInfoAccepted.Items.Add("Aangemaakt op: " + aangemaakt);
            if (Urgent == "Y")
            {
                urgent = "Wel urgent";
            }
            else if (Urgent == "N")
            {
                urgent = "Niet urgent";
            }
            lbExtraInfoAccepted.Items.Add("Urgentie: " + urgent);
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            int index = lbReview.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("je moet eerst een beoordeling aanklikken.");
                return;
            }
            string antwoord = tbAnswer.Text;
            List<Review> reviews = HelpHandler.Reviews;
            int accountid = DatabaseHandler.GetAccountIDReview(reviews[index].Id);
            bool gelukt = DatabaseHandler.AddAnswer(tbAnswer.Text, DateTime.Now, accountid, this.id);
            if (gelukt == true)
            {
                MessageBox.Show("U heeft een reactie geplaatst!");
            }
            else
            {
                MessageBox.Show("U heeft geen reactie geplaatst!");
            }
            tbAnswer.Text = "";
        }
    }
}
