using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Virt_lab_25
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        int a = 10;
        private void enterRegister_Click(object sender, EventArgs e)
        {
           if (checkTextBox() && checkTextGroup())
            {
                if (int.TryParse(textBox1.Text, out a))
                {

                    string name = textBoxName.Text + " " + textBoxGroup.Text;
                    this.Hide();
                    Form1 form = new Form1();
                    form.f = a;
                    if (radioButton1.Checked == true)
                    {
                        form.numericUpDown1.Value = 30;
                        form.numericUpDown1.Minimum = 30;
                        form.numericUpDown1.Maximum = 40;
                    }
                    else
                    {
                        form.numericUpDown1.Value = 40;
                        form.numericUpDown1.Minimum = 40;
                        form.numericUpDown1.Maximum = 50;
                    }
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Не заполнены поля");
                }
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void closeRegister_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool checkTextBox()
        {
            if ((textBoxName.Text.Trim() == string.Empty))
            {
                MessageBox.Show("Не заполнены поля");
                return false;
            } else if ((textBoxName.Text.Trim() == string.Empty))
            {
                MessageBox.Show("Не заполнены поля");
                return false;
            }
            return true;
        }

        private bool checkTextGroup()
        {
            if ((textBoxGroup.Text.Trim() == string.Empty))
            {
                MessageBox.Show("Не заполнены поля");
                return false;
            }
            else if ((textBoxGroup.Text.Trim() == string.Empty))
            {
                MessageBox.Show("Не заполнены поля");
                return false;
            }
            return true;
        }



        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
