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
    public partial class InloggenForm : Form
    {
        DatabaseHandler databasehandler = new DatabaseHandler();
        public InloggenForm()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            InschrijvenForm inschrijven = new InschrijvenForm();
            inschrijven.Show();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string SoortAccount = databasehandler.LogIn(tbUsername.Text, tbPassword.Text);
            if (SoortAccount == "H")
            {
                Hulpbehoevende hulpbehoevende = new Hulpbehoevende();
                hulpbehoevende.Show();
            }
            else if (SoortAccount == "V")
            {
                VrijwilligerForm vrijwilliger = new VrijwilligerForm();
                vrijwilliger.Show();
            }
            else if (SoortAccount == "B")
            {
                BeheerderForm beheerder = new BeheerderForm();
                beheerder.Show();
            }
        }
    }
}
