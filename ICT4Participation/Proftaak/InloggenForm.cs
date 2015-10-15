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
        public InloggenForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BeheerderForm beheerder = new BeheerderForm();
            InschrijvenForm inschrijven = new InschrijvenForm();
            VrijwilligerForm vrijwilliger = new VrijwilligerForm();
            Hulpbehoevende hulpbehoevende = new Hulpbehoevende();
            HulpvraagForm hulpvraag = new HulpvraagForm();

            beheerder.Show();
            inschrijven.Show();
            vrijwilliger.Show();
            hulpbehoevende.Show();
            hulpvraag.Show();
        }
    }
}
