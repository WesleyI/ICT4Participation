namespace Proftaak
{
    partial class HulpvraagForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRequestTitle = new System.Windows.Forms.TextBox();
            this.tbRequestDescription = new System.Windows.Forms.TextBox();
            this.dtpRequestDate = new System.Windows.Forms.DateTimePicker();
            this.tbRequestDuration = new System.Windows.Forms.TextBox();
            this.cbRequestUrgency = new System.Windows.Forms.CheckBox();
            this.btnCreateRequest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titel:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Datum:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Duur:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Beschrijving:";
            // 
            // tbRequestTitle
            // 
            this.tbRequestTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRequestTitle.Location = new System.Drawing.Point(93, 18);
            this.tbRequestTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbRequestTitle.Name = "tbRequestTitle";
            this.tbRequestTitle.Size = new System.Drawing.Size(341, 21);
            this.tbRequestTitle.TabIndex = 4;
            // 
            // tbRequestDescription
            // 
            this.tbRequestDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRequestDescription.Location = new System.Drawing.Point(93, 102);
            this.tbRequestDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbRequestDescription.Multiline = true;
            this.tbRequestDescription.Name = "tbRequestDescription";
            this.tbRequestDescription.Size = new System.Drawing.Size(341, 111);
            this.tbRequestDescription.TabIndex = 5;
            // 
            // dtpRequestDate
            // 
            this.dtpRequestDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRequestDate.Location = new System.Drawing.Point(93, 49);
            this.dtpRequestDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpRequestDate.Name = "dtpRequestDate";
            this.dtpRequestDate.Size = new System.Drawing.Size(341, 21);
            this.dtpRequestDate.TabIndex = 6;
            // 
            // tbRequestDuration
            // 
            this.tbRequestDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRequestDuration.Location = new System.Drawing.Point(93, 75);
            this.tbRequestDuration.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbRequestDuration.Name = "tbRequestDuration";
            this.tbRequestDuration.Size = new System.Drawing.Size(341, 21);
            this.tbRequestDuration.TabIndex = 7;
            // 
            // cbRequestUrgency
            // 
            this.cbRequestUrgency.AutoSize = true;
            this.cbRequestUrgency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRequestUrgency.Location = new System.Drawing.Point(378, 218);
            this.cbRequestUrgency.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbRequestUrgency.Name = "cbRequestUrgency";
            this.cbRequestUrgency.Size = new System.Drawing.Size(63, 19);
            this.cbRequestUrgency.TabIndex = 8;
            this.cbRequestUrgency.Text = "Urgent";
            this.cbRequestUrgency.UseVisualStyleBackColor = true;
            // 
            // btnCreateRequest
            // 
            this.btnCreateRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateRequest.Location = new System.Drawing.Point(93, 218);
            this.btnCreateRequest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCreateRequest.Name = "btnCreateRequest";
            this.btnCreateRequest.Size = new System.Drawing.Size(87, 24);
            this.btnCreateRequest.TabIndex = 9;
            this.btnCreateRequest.Text = "Aanmaken";
            this.btnCreateRequest.UseVisualStyleBackColor = true;
            // 
            // HulpvraagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 249);
            this.Controls.Add(this.btnCreateRequest);
            this.Controls.Add(this.cbRequestUrgency);
            this.Controls.Add(this.tbRequestDuration);
            this.Controls.Add(this.dtpRequestDate);
            this.Controls.Add(this.tbRequestDescription);
            this.Controls.Add(this.tbRequestTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "HulpvraagForm";
            this.Text = "Hulpvraag";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbRequestTitle;
        private System.Windows.Forms.TextBox tbRequestDescription;
        private System.Windows.Forms.DateTimePicker dtpRequestDate;
        private System.Windows.Forms.TextBox tbRequestDuration;
        private System.Windows.Forms.CheckBox cbRequestUrgency;
        private System.Windows.Forms.Button btnCreateRequest;
    }
}