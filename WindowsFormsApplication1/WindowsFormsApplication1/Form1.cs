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
    public partial class GenderForm : Form
    {
        public GenderForm()
        {
            InitializeComponent();
        }
        //why
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            String firstName = firstNameForm.Text;
            String lastName = lastNameForm.Text;
            String DOB = DOBForm.Text;
            String gender = maleButton.Checked ? "male" : "female";
            String address = AddressForm.Text;
            String phone = PhoneForm.Text;
            MessageBox.Show("Hello World "  + firstName + " " + lastName + " " + DOB + " " + gender + " " + address + " " + phone);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
                    }
    }
}
