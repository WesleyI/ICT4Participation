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
    public partial class InschrijvenForm : Form
    {
        public InschrijvenForm()
        {
            InitializeComponent();
        }

        private void btnVrijFindVOG_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbVrijVog.Text = openfile.FileName;
            };

        }

        private void btnVrijFindPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbVrijPhoto.Text = openfile.FileName;
            };
            //http://stackoverflow.com/questions/6579805/save-image-to-particular-folder-from-openfiledialog
            //https://msdn.microsoft.com/en-us/library/system.windows.forms.commondialog.aspx
            //http://stackoverflow.com/questions/12909905/saving-image-to-file
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (cbSoort.Text == "Vrijwilliger" && tbVrijFirstname.Text != "" && tbVrijLastname.Text != "" && tbVrijEmail.Text != "" && tbVrijWachtwoord.Text != "" && tbVrijCity.Text != "" && tbVrijStreet.Text != "" && tbVrijAddress.Text != "" && tbVrijBio.Text != "" && dtpVrijBirthDate2.Value != null && tbVrijTransport.Text != "" && tbVrijPhonenumber.Text != "" && tbVrijCompetences.Text != "" && tbVrijAvailability.Text != "" && tbVrijVog.Text != "" && tbVrijPhoto.Text != "")
            {
                if (tbVrijWachtwoord.Text == tbVrijBevestigWachtwoord.Text)
                {
                    Vrijwilliger vrijwilliger = new Vrijwilliger(tbVrijFirstname.Text, tbVrijLastname.Text, tbVrijEmail.Text, tbVrijWachtwoord.Text, tbVrijCity.Text, tbVrijStreet.Text, tbVrijAddress.Text, tbVrijBio.Text, dtpVrijBirthDate2.Value, tbVrijTransport.Text, tbVrijPhonenumber.Text, tbVrijCompetences.Text, tbVrijAvailability.Text, tbVrijVog.Text, tbVrijPhoto.Text);
                    DatabaseHandler.AddVrijwilliger(vrijwilliger);
                    MessageBox.Show("Vrijwilliger aangemaakt");
                    this.Hide();
                }

                else if (tbVrijWachtwoord.Text != tbVrijBevestigWachtwoord.Text)
                {
                    MessageBox.Show("Uw wachtwoorden zijn niet gelijk, type deze zorgvuldig in.");
                }
            }
            else if (cbSoort.Text == "Hulpbehoevende" && tbHulpFirstname.Text != "" && tbHulpLastname.Text != "" && tbHulpEmail.Text != "" && tbHulpWachtwoord.Text != "" && tbHulpCity.Text != "" && tbHulpStreet.Text != "" && tbHulpAddress.Text != "" && tbHulpBio.Text != "" && dtpHulpBirthDate2.Value != null && tbHulpPhonenumber.Text != "" && tbHulpProblem.Text != "")
            {
                if (tbHulpWachtwoord.Text == tbHulpBevestigWachtwoord.Text)
                {
                    HelpBehoevende hulpbehoevende = new HelpBehoevende(tbHulpFirstname.Text, tbHulpLastname.Text, tbHulpEmail.Text, tbHulpWachtwoord.Text, tbHulpCity.Text, tbHulpStreet.Text, tbHulpAddress.Text, tbHulpBio.Text, dtpHulpBirthDate2.Value, tbHulpPhonenumber.Text, tbHulpProblem.Text);
                    DatabaseHandler.AddHelpBehoevende(hulpbehoevende);
                    MessageBox.Show("hulpbehoevende aangemaakt");
                    this.Hide();
                }

                else if (tbHulpBevestigWachtwoord.Text != tbHulpWachtwoord.Text)
                {
                    MessageBox.Show("Uw wachtwoorden zijn niet gelijk, type deze zorgvuldig in.");
                }
            }
            else
            {
                MessageBox.Show("Niet alle velden zijn correct ingevuld");
            }
        }

        private void cbSoort_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (cbSoort.Text == "Vrijwilliger")
            {
                gbHulpbehoevende.Visible = false;
                gbVrijwilliger.Visible = true;

            }
            else if (cbSoort.Text == "Hulpbehoevende")
            {
                gbHulpbehoevende.Visible = true;
                gbVrijwilliger.Visible = false;
            }
        }
    }
}
