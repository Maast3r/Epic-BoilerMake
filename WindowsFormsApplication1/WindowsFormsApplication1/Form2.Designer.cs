namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.perscriptionBox = new System.Windows.Forms.GroupBox();
            this.drugNameLabel = new System.Windows.Forms.Label();
            this.drugPillDescriptionLabel = new System.Windows.Forms.Label();
            this.drugInstructionLabel = new System.Windows.Forms.Label();
            this.drugDoseLabel = new System.Windows.Forms.Label();
            this.drugTimesInfoLabel = new System.Windows.Forms.Label();
            this.drugTime1Label = new System.Windows.Forms.Label();
            this.drugTime2Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.drugUpdateReminderTimeButton = new System.Windows.Forms.Button();
            this.drugIGotARefillButton = new System.Windows.Forms.Button();
            this.perscriptionBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // perscriptionBox
            // 
            this.perscriptionBox.Controls.Add(this.drugIGotARefillButton);
            this.perscriptionBox.Controls.Add(this.drugUpdateReminderTimeButton);
            this.perscriptionBox.Controls.Add(this.label1);
            this.perscriptionBox.Controls.Add(this.drugTime2Label);
            this.perscriptionBox.Controls.Add(this.drugTime1Label);
            this.perscriptionBox.Controls.Add(this.drugTimesInfoLabel);
            this.perscriptionBox.Controls.Add(this.drugDoseLabel);
            this.perscriptionBox.Controls.Add(this.drugInstructionLabel);
            this.perscriptionBox.Controls.Add(this.drugPillDescriptionLabel);
            this.perscriptionBox.Controls.Add(this.drugNameLabel);
            this.perscriptionBox.Location = new System.Drawing.Point(17, 24);
            this.perscriptionBox.Name = "perscriptionBox";
            this.perscriptionBox.Size = new System.Drawing.Size(752, 317);
            this.perscriptionBox.TabIndex = 0;
            this.perscriptionBox.TabStop = false;
            // 
            // drugNameLabel
            // 
            this.drugNameLabel.AutoSize = true;
            this.drugNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drugNameLabel.Location = new System.Drawing.Point(32, 38);
            this.drugNameLabel.Name = "drugNameLabel";
            this.drugNameLabel.Size = new System.Drawing.Size(100, 29);
            this.drugNameLabel.TabIndex = 0;
            this.drugNameLabel.Text = "Vikodin";
            // 
            // drugPillDescriptionLabel
            // 
            this.drugPillDescriptionLabel.AutoSize = true;
            this.drugPillDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.drugPillDescriptionLabel.Location = new System.Drawing.Point(138, 43);
            this.drugPillDescriptionLabel.Name = "drugPillDescriptionLabel";
            this.drugPillDescriptionLabel.Size = new System.Drawing.Size(196, 22);
            this.drugPillDescriptionLabel.TabIndex = 1;
            this.drugPillDescriptionLabel.Text = "( 21/40 pills remaining )";
            // 
            // drugInstructionLabel
            // 
            this.drugInstructionLabel.AutoSize = true;
            this.drugInstructionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.drugInstructionLabel.Location = new System.Drawing.Point(37, 83);
            this.drugInstructionLabel.Name = "drugInstructionLabel";
            this.drugInstructionLabel.Size = new System.Drawing.Size(494, 25);
            this.drugInstructionLabel.TabIndex = 2;
            this.drugInstructionLabel.Text = "Instructions: Take 2 tablets (80 mg total) by mouth daily.";
            this.drugInstructionLabel.Click += new System.EventHandler(this.drugDescriptionLabel_Click);
            // 
            // drugDoseLabel
            // 
            this.drugDoseLabel.AutoSize = true;
            this.drugDoseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drugDoseLabel.Location = new System.Drawing.Point(37, 125);
            this.drugDoseLabel.Name = "drugDoseLabel";
            this.drugDoseLabel.Size = new System.Drawing.Size(123, 25);
            this.drugDoseLabel.TabIndex = 3;
            this.drugDoseLabel.Text = "Dose: 80 mg";
            this.drugDoseLabel.Click += new System.EventHandler(this.drugDoseLabel_Click);
            // 
            // drugTimesInfoLabel
            // 
            this.drugTimesInfoLabel.AutoSize = true;
            this.drugTimesInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drugTimesInfoLabel.Location = new System.Drawing.Point(38, 170);
            this.drugTimesInfoLabel.Name = "drugTimesInfoLabel";
            this.drugTimesInfoLabel.Size = new System.Drawing.Size(331, 25);
            this.drugTimesInfoLabel.TabIndex = 4;
            this.drugTimesInfoLabel.Text = "Times when Cortana will remind you:";
            // 
            // drugTime1Label
            // 
            this.drugTime1Label.AutoSize = true;
            this.drugTime1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drugTime1Label.Location = new System.Drawing.Point(38, 209);
            this.drugTime1Label.Name = "drugTime1Label";
            this.drugTime1Label.Size = new System.Drawing.Size(93, 25);
            this.drugTime1Label.TabIndex = 5;
            this.drugTime1Label.Text = "8:30 a.m.";
            // 
            // drugTime2Label
            // 
            this.drugTime2Label.AutoSize = true;
            this.drugTime2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drugTime2Label.Location = new System.Drawing.Point(187, 209);
            this.drugTime2Label.Name = "drugTime2Label";
            this.drugTime2Label.Size = new System.Drawing.Size(93, 25);
            this.drugTime2Label.TabIndex = 6;
            this.drugTime2Label.Text = "4:00 p.m.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "You will need more pills by 11/18/2015";
            // 
            // drugUpdateReminderTimeButton
            // 
            this.drugUpdateReminderTimeButton.BackColor = System.Drawing.Color.Orange;
            this.drugUpdateReminderTimeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drugUpdateReminderTimeButton.ForeColor = System.Drawing.Color.White;
            this.drugUpdateReminderTimeButton.Location = new System.Drawing.Point(606, 43);
            this.drugUpdateReminderTimeButton.Name = "drugUpdateReminderTimeButton";
            this.drugUpdateReminderTimeButton.Size = new System.Drawing.Size(122, 118);
            this.drugUpdateReminderTimeButton.TabIndex = 8;
            this.drugUpdateReminderTimeButton.Text = "Update Reminder Times and Information";
            this.drugUpdateReminderTimeButton.UseVisualStyleBackColor = false;
            // 
            // drugIGotARefillButton
            // 
            this.drugIGotARefillButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.drugIGotARefillButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drugIGotARefillButton.ForeColor = System.Drawing.Color.White;
            this.drugIGotARefillButton.Location = new System.Drawing.Point(606, 170);
            this.drugIGotARefillButton.Name = "drugIGotARefillButton";
            this.drugIGotARefillButton.Size = new System.Drawing.Size(122, 38);
            this.drugIGotARefillButton.TabIndex = 9;
            this.drugIGotARefillButton.Text = "I got a refill";
            this.drugIGotARefillButton.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 831);
            this.Controls.Add(this.perscriptionBox);
            this.Name = "Form2";
            this.Text = "Form2";
            this.perscriptionBox.ResumeLayout(false);
            this.perscriptionBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox perscriptionBox;
        private System.Windows.Forms.Label drugInstructionLabel;
        private System.Windows.Forms.Label drugPillDescriptionLabel;
        private System.Windows.Forms.Label drugNameLabel;
        private System.Windows.Forms.Label drugTimesInfoLabel;
        private System.Windows.Forms.Label drugDoseLabel;
        private System.Windows.Forms.Label drugTime2Label;
        private System.Windows.Forms.Label drugTime1Label;
        private System.Windows.Forms.Button drugIGotARefillButton;
        private System.Windows.Forms.Button drugUpdateReminderTimeButton;
        private System.Windows.Forms.Label label1;
    }
}