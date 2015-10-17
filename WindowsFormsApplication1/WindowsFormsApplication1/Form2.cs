using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public String json;   

        public Form2(String epicJson)
        {
            InitializeComponent();
            json = epicJson;
            this.AutoScroll = true;
            makeData();
        }

        private void drugDescriptionLabel_Click(object sender, EventArgs e)
        {

        }

        private void drugDoseLabel_Click(object sender, EventArgs e)
        {

        }

        private void makeData()
        {
            perscriptionBox.Hide();
            
            for (int i = 0; i < 3; i++)
            {
                var drug = new GroupBox();
                drug.Location = new Point(17, i*400 + 24);
                drug.MaximumSize = new Size(475, 0);
                drug.AutoSize = true;

                var medicineTitle = new Label();
                medicineTitle.Text = "Vicodin";
                medicineTitle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                medicineTitle.Location = new Point(37, 38);
                medicineTitle.MaximumSize = new Size(100, 0);
                medicineTitle.AutoSize = true;

                var remaining = new Label();
                remaining.Text = "10/100 remaining";
                remaining.Font = new Font("Microsoft Sans Serif", 9);
                remaining.Location = new Point(138, 43);
                remaining.MaximumSize = new Size(196, 0);
                remaining.AutoSize = true;

                var instructions = new Label();
                instructions.Text = "Take 20 everyday or else you done goofed.";
                instructions.Font = new Font("Microsoft Sans Serif", 10);
                instructions.Location = new Point(37, 83);
                instructions.MaximumSize = new Size(494, 0);
                instructions.AutoSize = true;

                var dose = new Label();
                dose.Text = "Dose: 1000000mg";
                dose.Font = new Font("Microsoft Sans Serif", 10);
                dose.Location = new Point(37, 125);
                dose.MaximumSize = new Size(123, 0);
                dose.AutoSize = true;

                var drugTimes = new Label();
                drugTimes.Text = "Times Cortana will remind you:";
                drugTimes.Font = new Font("Microsoft Sans Serif", 10);
                drugTimes.Location = new Point(38, 170);
                drugTimes.MaximumSize = new Size(331, 0);
                drugTimes.AutoSize = true;

                var reminders = new GroupBox();
                int x = 0;
                int y = 1;
                for (int j = 0; j < 7; j++)
                {
                    //MessageBox.Show(x + " Hello World " + y);
                    var reminder = new Label();
                    reminder.Text = "12:66am";
                    reminder.Font = new Font("Microsoft Sans Serif", 10);
                    reminder.Location = new Point(x * 100 + 10, 22 * y);
                    reminder.Size = new Size(75, 25);
                    x += 1;
                    if(j % 3 == 0 && j != 0)
                    {
                        y += 1;
                        x = 0;
                    }
                    reminders.Controls.Add(reminder);
                }
                reminders.Location = new Point(38, 200);
                reminders.MaximumSize = new Size(400, 0);
                reminders.AutoSize = true;

                var reFill = new Label();
                reFill.Text = "Refill now. You're out of time.";
                reFill.Font = new Font("Microsoft Sans Serif", 10);
                reFill.Location = new Point(37, 300);
                reFill.AutoSize = true;

                var updateButton = new Button();
                updateButton.Text = "Update Reminder Times and Information";
                updateButton.Font = new Font("Microsoft Sans Serif", 10);
                updateButton.Location = new Point(325, 20);
                updateButton.Size = new Size(122, 75);
                updateButton.ForeColor = Color.FromArgb(255, 255, 255);
                updateButton.BackColor = Color.FromArgb(239, 172, 67);

                var refillButton = new Button();
                refillButton.Text = "I got a refill";
                refillButton.Font = new Font("Microsoft Sans Serif", 10);
                refillButton.Location = new Point(325, 100);
                refillButton.Size = new Size(122, 30);
                refillButton.ForeColor = Color.FromArgb(255, 255, 255);
                refillButton.BackColor = Color.FromArgb(88, 185, 87);

                drug.Controls.Add(medicineTitle);
                drug.Controls.Add(remaining);
                drug.Controls.Add(instructions);
                drug.Controls.Add(dose);
                drug.Controls.Add(drugTimes);
                drug.Controls.Add(reminders);
                drug.Controls.Add(reFill);
                drug.Controls.Add(updateButton);
                drug.Controls.Add(refillButton);

                this.Controls.Add(drug);
            }
        }
    }
}
