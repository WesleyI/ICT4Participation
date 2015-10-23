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
        HelpHandler help = new HelpHandler(); // Toegang tot de lijsten in de HelpHandler.
        AccountHandler account = new AccountHandler(); // Toegang tot de lijsten van de AccountHandler.


        private string email;

        public VrijwilligerForm(string email)
        {
            InitializeComponent();
            this.email = email;
            timer1.Start();
        }

        public VrijwilligerForm()
        {
            InitializeComponent();

            DatabaseHandler.GetHulpBehoevende();

            foreach (HelpBehoevende h in AccountHandler.HelpBehoevenden) // Alle hulpbehoevenden die zijn aangemaakt worden in de lijst getoond.
            {
                lbHulpbehoevende.Items.Add(h.ToString());
            }

            timer1.Start();
        }

        public void RefreshList()
        {
            lbChatmessage.Items.Clear();

            foreach (ChatMessage c in help.GetMesagges())
            {
                lbChatmessage.Items.Add(c);
            }
        }

        private void btSendMessage_Click(object sender, EventArgs e)
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
                        help.AddChatMessage(chatMessage);
                        lbChatmessage.Items.Add(chatMessage.ToString());
                    }
                }
            }
        }


        //TODO: BERICHTEN OPHALEN VAN AFZENDER
        private void lbHulpbehoevende_SelectedIndexChanged(object sender, EventArgs e)
        {
            help.ClearMessages();
            lbChatmessage.Items.Clear();

            if (lbHulpbehoevende.SelectedItem != null)
            {
                foreach (HelpBehoevende hb in AccountHandler.HelpBehoevenden)
                {
                    if (hb.ToString() == (string)lbHulpbehoevende.SelectedItem)
                    {
                        lbChatmessage.Items.Clear();

                        DatabaseHandler.GetChatMessage(1);

                        foreach (ChatMessage c in help.GetMesagges())
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
            help.ClearMessages();
            lbChatmessage.Items.Clear();

            if (lbHulpbehoevende.SelectedItem != null)
            {
                foreach (HelpBehoevende hb in AccountHandler.HelpBehoevenden)
                {
                    if (hb.ToString() == (string)lbHulpbehoevende.SelectedItem)
                    {
                        lbChatmessage.Items.Clear();

                        DatabaseHandler.GetChatMessage(1);

                        foreach (ChatMessage c in help.GetMesagges())
                        {
                            if (hb.Id == c.Ontvanger)
                            {
                                lbChatmessage.Items.Add(c.ToString());
                            }
                        }
                    }
                }
            }
        }
    }
}
