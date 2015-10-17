namespace WindowsFormsApplication1
{
    partial class GenderForm
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
            this.confirmButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maleButton = new System.Windows.Forms.RadioButton();
            this.femaleButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.firstNameForm = new System.Windows.Forms.TextBox();
            this.AddressForm = new System.Windows.Forms.TextBox();
            this.DOBForm = new System.Windows.Forms.TextBox();
            this.lastNameForm = new System.Windows.Forms.TextBox();
            this.PhoneForm = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // confirmButton
            // 
            this.confirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.confirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            this.confirmButton.ForeColor = System.Drawing.SystemColors.Window;
            this.confirmButton.Location = new System.Drawing.Point(58, 616);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(838, 100);
            this.confirmButton.TabIndex = 0;
            this.confirmButton.Text = "Confirm Information";
            this.confirmButton.UseVisualStyleBackColor = false;
            this.confirmButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(52, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(549, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // maleButton
            // 
            this.maleButton.AutoSize = true;
            this.maleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.maleButton.Location = new System.Drawing.Point(555, 304);
            this.maleButton.Name = "maleButton";
            this.maleButton.Size = new System.Drawing.Size(102, 36);
            this.maleButton.TabIndex = 10;
            this.maleButton.TabStop = true;
            this.maleButton.Text = "Male";
            this.maleButton.UseVisualStyleBackColor = true;
            // 
            // femaleButton
            // 
            this.femaleButton.AutoSize = true;
            this.femaleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.femaleButton.Location = new System.Drawing.Point(761, 304);
            this.femaleButton.Name = "femaleButton";
            this.femaleButton.Size = new System.Drawing.Size(135, 36);
            this.femaleButton.TabIndex = 11;
            this.femaleButton.TabStop = true;
            this.femaleButton.Text = "Female";
            this.femaleButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(52, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(347, 32);
            this.label3.TabIndex = 12;
            this.label3.Text = "Date of Birth (dd/mm/yyyy)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(549, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 32);
            this.label4.TabIndex = 13;
            this.label4.Text = "Gender (optional)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label5.Location = new System.Drawing.Point(52, 442);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(329, 32);
            this.label5.TabIndex = 14;
            this.label5.Text = "Street Address (optional)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label6.Location = new System.Drawing.Point(549, 442);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(225, 32);
            this.label6.TabIndex = 15;
            this.label6.Text = "Phone (optional)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(414, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Your Information";
            // 
            // firstNameForm
            // 
            this.firstNameForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.firstNameForm.Location = new System.Drawing.Point(58, 134);
            this.firstNameForm.Name = "firstNameForm";
            this.firstNameForm.Size = new System.Drawing.Size(341, 39);
            this.firstNameForm.TabIndex = 17;
            // 
            // AddressForm
            // 
            this.AddressForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.AddressForm.Location = new System.Drawing.Point(58, 479);
            this.AddressForm.Name = "AddressForm";
            this.AddressForm.Size = new System.Drawing.Size(341, 39);
            this.AddressForm.TabIndex = 19;
            // 
            // DOBForm
            // 
            this.DOBForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.DOBForm.Location = new System.Drawing.Point(58, 301);
            this.DOBForm.Name = "DOBForm";
            this.DOBForm.Size = new System.Drawing.Size(341, 39);
            this.DOBForm.TabIndex = 20;
            // 
            // lastNameForm
            // 
            this.lastNameForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lastNameForm.Location = new System.Drawing.Point(555, 134);
            this.lastNameForm.Name = "lastNameForm";
            this.lastNameForm.Size = new System.Drawing.Size(341, 39);
            this.lastNameForm.TabIndex = 21;
            // 
            // PhoneForm
            // 
            this.PhoneForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.PhoneForm.Location = new System.Drawing.Point(555, 477);
            this.PhoneForm.Name = "PhoneForm";
            this.PhoneForm.Size = new System.Drawing.Size(341, 39);
            this.PhoneForm.TabIndex = 22;
            // 
            // GenderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 764);
            this.Controls.Add(this.PhoneForm);
            this.Controls.Add(this.lastNameForm);
            this.Controls.Add(this.DOBForm);
            this.Controls.Add(this.AddressForm);
            this.Controls.Add(this.firstNameForm);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.femaleButton);
            this.Controls.Add(this.maleButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirmButton);
            this.Name = "GenderForm";
            this.Text = "Your Information";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton maleButton;
        private System.Windows.Forms.RadioButton femaleButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox firstNameForm;
        private System.Windows.Forms.TextBox AddressForm;
        private System.Windows.Forms.TextBox DOBForm;
        private System.Windows.Forms.TextBox lastNameForm;
        private System.Windows.Forms.TextBox PhoneForm;
    }
}

