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
        string inlog;

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
            inlog = tbUsername.Text;
            string SoortAccount = DatabaseHandler.LogIn(tbUsername.Text, tbPassword.Text);
            if (SoortAccount == "H")
            {
                //HelpBehoevende hulpbehoevende = DatabaseHandler.GetHulpbehoevendeInlog(tbUsername.Text);
                //HulpbehoevendeForm form = new HulpbehoevendeForm(hulpbehoevende.Id, hulpbehoevende.FirstName, hulpbehoevende.LastName);
                //form.Show();
            }
            else if (SoortAccount == "V")
            {
                Vrijwilliger vrijwilliger = DatabaseHandler.GetVrijwilligerInlog(tbUsername.Text);
                VrijwilligerForm form = new VrijwilligerForm(vrijwilliger.Email, vrijwilliger.FirstName, vrijwilliger.LastName, vrijwilliger.Id); //
                form.Show();
            }
            else if (SoortAccount == "B")
            {
                BeheerderForm beheerder = new BeheerderForm();
                beheerder.Show();
            }
        }

        public string GeefInlog()
        {
            return inlog;
        }
    }
}
