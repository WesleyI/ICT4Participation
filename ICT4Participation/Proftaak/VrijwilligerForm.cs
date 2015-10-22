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

        string email;
        public VrijwilligerForm(string email)
        {
            InitializeComponent();
            this.email = email;
            timer1.Start();
            foreach (HelpBehoevende h in account.HelpBehoevenden) // Alle hulpbehoevenden die zijn aangemaakt worden in de lijst getoond.
            {
                lbHulpbehoevende.Items.Add(h);
            }
        }

        public VrijwilligerForm()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string bericht = tbChatmessage.Text; // Het bericht dat de gebruiker heeft ingevoerd.
            string datum = Convert.ToString(DateTime.Now); // De tijd en datum waarop het bericht wordt verzonden.
            HelpBehoevende ontvanger = lbHulpbehoevende.SelectedItem as HelpBehoevende; // Haal de ontvanger op uit de lijst met hulpbehoevende.

            //int ontvangerID = database.GetAccountID(ontvanger.Email); // Haal de ontvangerID op uit de database.
            //int verzenderID = database.GetAccountID(email); // Haal de verzenderID op uit de database.

            ChatMessage chatMessage = new ChatMessage(bericht, datum);
            help.AddChatMessage(chatMessage); // Het bericht wordt toegevoegd aan de lijst met bestaande chatberichten.
            RefreshList();

            //database.AddChatMessage(bericht, datum, ontvangerID, verzenderID); // Voeg het bericht toe aan de database.
        }

        public void RefreshList()
        {
            lbChatmessage.Items.Clear();
            foreach (ChatMessage c in help.GetMesagges())
            {
                lbChatmessage.Items.Add(c);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            help.ClearMessages();
            //TODO2 Berichten uit database halen
            RefreshList();
        }
    }
}
