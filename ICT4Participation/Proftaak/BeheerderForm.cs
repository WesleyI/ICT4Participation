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
    public partial class BeheerderForm : Form
    {
        HelpHandler helphandler = new HelpHandler();

        HelpRequest selectedRequest = null;
        Review selectedReview = null;
        Answer selectedAnswer = null;

        public BeheerderForm()
        {
            InitializeComponent();
            DatabaseHandler.GetHulpVraag();
            DatabaseHandler.GetReview();
            DatabaseHandler.GetAnswer();
            UpdateLists();
        }
        /// <summary>
        /// Uiloggen en terug naar inlogscherm
        /// </summary>
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            InloggenForm inloggenForm = new InloggenForm();

            this.Hide();
            inloggenForm.Show();
        }

        /// <summary>
        /// Update de lijsten met hulpvragen, recensies en reacties
        /// </summary>
        private void UpdateLists()
        {
            lbHelpRequest.Items.Clear();
            lbReview.Items.Clear();
            lbAnswer.Items.Clear();

            foreach (HelpRequest hr in HelpHandler.HelpRequests)
            {
                lbHelpRequest.Items.Add(hr);
            }

            foreach (Review r in HelpHandler.Reviews)
            {
                lbReview.Items.Add(r);
            }

            foreach (Answer a in HelpHandler.Answers)
            {
                lbAnswer.Items.Add(a);
            }
        }

        /// <summary>
        /// Toont de geselecteerde hulpvraag in het tekstvak
        /// </summary>
        private void lbHelpRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbHelpRequest.SelectedIndex != -1)
            {
                selectedRequest = lbHelpRequest.SelectedItem as HelpRequest;
                if (selectedRequest != null)
                {
                    tbEdit.Text = selectedRequest.ToString();
                }
            }
        }

        /// <summary>
        /// Toont de geselecteerde review in het tekstvak
        /// </summary>
        private void lbReview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbReview.SelectedIndex != -1)
            {
                selectedReview = lbReview.SelectedItem as Review;

                if (selectedReview != null)
                {
                    tbEdit.Text = selectedReview.ToString();
                }
            }
        }

        /// <summary>
        /// Toont de geselecteerde reactie in het tekstvak
        /// </summary>
        private void lbAnswer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAnswer.SelectedIndex != -1)
            {
                selectedAnswer = lbAnswer.SelectedItem as Answer;

                if(selectedAnswer != null)
                {
                    tbEdit.Text = selectedAnswer.ToString();
                }
            }
        }

        /// <summary>
        /// Verwijderd de geselecteerde hulpvraag, review of reactie
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            selectedRequest = lbHelpRequest.SelectedItem as HelpRequest;

            if (selectedRequest != null)
            {
                if (selectedRequest != null)
                {
                    DatabaseHandler.DelHelpRequest(selectedRequest.Id);
                    helphandler.DelHelpRequest(selectedRequest);
                }
            }

            selectedReview = lbReview.SelectedItem as Review;

            if (selectedReview != null)
            {
                if (selectedReview != null)
                {
                    DatabaseHandler.DelReview(selectedReview.Id);
                    helphandler.DelReview(selectedReview);
                }
            }

            selectedAnswer = lbAnswer.SelectedItem as Answer;

            if (selectedAnswer != null)
            {
                if (selectedAnswer != null)
                {
                    DatabaseHandler.DelAnswer(selectedAnswer.Id);
                    helphandler.DelAnswer(selectedAnswer);
                }
            }

            UpdateLists();
        }

        /// <summary>
        /// past de geselecteerde hulpvraag, review of reactie aan, aan de hand van het tekstvak
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            selectedRequest = lbHelpRequest.SelectedItem as HelpRequest;

            if (selectedRequest != null)
            {
                if (selectedRequest != null)
                {
                    DatabaseHandler.EditHelpRequest(selectedRequest.Id, tbEdit.Text);
                }
            }

            selectedReview = lbReview.SelectedItem as Review;

            if (selectedReview != null)
            {
                if (selectedReview != null)
                {
                    DatabaseHandler.EditReview(selectedReview.Id,tbEdit.Text);
                }
            }

            selectedAnswer = lbAnswer.SelectedItem as Answer;

            if (selectedAnswer != null)
            {
                if (selectedAnswer != null)
                {
                    DatabaseHandler.EditAnswer(selectedAnswer.Id,tbEdit.Text);
                }
            }
        }
    }
}
