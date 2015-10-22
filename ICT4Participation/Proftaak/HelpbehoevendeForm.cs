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
    public partial class Hulpbehoevende : Form
    {
        HelpHandler help = new HelpHandler(); // Toegang tot de lijsten in de HelpHandler.
        AccountHandler account = new AccountHandler(); // Toegang tot de lijsten van de AccountHandler.

        string email;
        public Hulpbehoevende(string email)
        {
            InitializeComponent();
            this.email = email;
            foreach (Vrijwilliger v in account.Vrijwilligers) // Alle vrijwilligers die zijn aangemaakt worden in de lijst getoond.
            {
                lbVrijwilligers.Items.Add(v);
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string bericht = tbChatMessage.Text; // Het bericht dat de gebruiker heeft ingevoerd.
            string datum = Convert.ToString(DateTime.Now); // De tijd en datum waarop het bericht wordt verzonden.
            Vrijwilliger ontvanger = lbVrijwilligers.SelectedItem as Vrijwilliger; // Haal de ontvanger op uit de lijst met vrijwilligers.

            // ontvangerID = database.GetAccountID(ontvanger.Email); // Haal de ontvangerID op uit de database.
            // int verzenderID = database.GetAccountID(email); // Haal de verzenderID op uit de database.

            ChatMessage chatMessage = new ChatMessage(bericht, datum);
            help.AddChatMessage(chatMessage); // Het bericht wordt toegevoegd aan de lijst met bestaande chatberichten.
            lbChatMessage.Items.Add(chatMessage); // Het verstuurde bericht wordt weergegeven in de chatbox.
            lbChatMessage.Refresh();

            //database.AddChatMessage(bericht, datum, ontvangerID, verzenderID); // Voeg het bericht toe aan de database.
        }
    }
}
