using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proftaak
{
    public partial class HulpbehoevendeForm : Form
    {
        HelpHandler help = new HelpHandler(); // Toegang tot de lijsten in de HelpHandler.
        AccountHandler account = new AccountHandler(); // Toegang tot de lijsten van de AccountHandler.

        string email;

        public HulpbehoevendeForm()
        {
            InitializeComponent();

            DatabaseHandler.GetVrijwilliger();

            foreach(Vrijwilliger v in AccountHandler.Vrijwilligers)
            {
                lbChatVrijwilligers.Items.Add(v.ToString());
            }
        }

        public HulpbehoevendeForm(string email)
        {
            InitializeComponent();
            this.email = email;
            foreach (Vrijwilliger v in AccountHandler.Vrijwilligers) // Alle vrijwilligers die zijn aangemaakt worden in de lijst getoond.
            {
                lbVrijwilligers.Items.Add(v);
            }
        }

        private void btnSendMessage_Click_1(object sender, EventArgs e)
        {
            string bericht = tbChatMessage.Text;
            DateTime datum = DateTime.Now;

            if (lbChatVrijwilligers.SelectedItem != null)
            {
                foreach (Vrijwilliger vw in AccountHandler.Vrijwilligers)
                {
                    if (vw.ToString() == (string)lbChatVrijwilligers.SelectedItem)
                    {
                        DatabaseHandler.AddChatMessage(bericht, datum, 2, vw.Id);
                        ChatMessage chatMessage = new ChatMessage(bericht, datum);
                        help.AddChatMessage(chatMessage);
                        lbChatMessage.Items.Add(chatMessage.ToString());
                    }
                }
            }
        }


        //TODO: BERICHTEN OPHALEN VAN AFZENDER
        private void timer1_Tick(object sender, EventArgs e)
        {
            help.ClearMessages();
            lbChatMessage.Items.Clear();

            if (lbChatVrijwilligers.SelectedItem != null)
            {
                foreach (Vrijwilliger vw in AccountHandler.Vrijwilligers)
                {
                    if (vw.ToString() == (string)lbChatVrijwilligers.SelectedItem)
                    {
                        lbChatMessage.Items.Clear();

                        DatabaseHandler.GetChatMessage(1);

                        foreach (ChatMessage c in help.GetMesagges())
                        {
                            if (vw.Id == c.Ontvanger)
                            {
                                lbChatMessage.Items.Add(c.ToString());
                            }
                        }
                    }
                }
            }
        }


        //TODO: BERICHTEN OPHALEN VAN AFZENDER
        private void lbChatVrijwilligers_SelectedIndexChanged(object sender, EventArgs e)
        {
            help.ClearMessages();
            lbChatMessage.Items.Clear();

            if (lbChatVrijwilligers.SelectedItem != null)
            {
                foreach (Vrijwilliger vw in AccountHandler.Vrijwilligers)
                {
                    if (vw.ToString() == (string)lbChatVrijwilligers.SelectedItem)
                    {
                        lbChatMessage.Items.Clear();

                        DatabaseHandler.GetChatMessage(1);

                        foreach (ChatMessage c in help.GetMesagges())
                        {
                            if (vw.Id == c.Ontvanger)
                            {
                                lbChatMessage.Items.Add(c.ToString());
                            }
                        }
                    }
                }
            }
        }
    }
}
