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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            button1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            //pictureBox1.Image = Image.FromFile("Metod1.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Parent = panel1;
            // pictureBox2.Image = Image.FromFile("Metod2.png");
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;

            pictureBox2.Parent = panel1;
            // pictureBox3.Image = Image.FromFile("Metod3.png");
            pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;

            pictureBox3.Parent = panel1;
            // pictureBox4.Image = Image.FromFile("Metod4.png");
            pictureBox4.SizeMode = PictureBoxSizeMode.AutoSize;

            pictureBox5.Parent = panel1;
            // pictureBox5.Image = Image.FromFile("Metod5.png");
            pictureBox6.SizeMode = PictureBoxSizeMode.AutoSize;

            pictureBox5.Parent = panel1;
            // pictureBox6.Image = Image.FromFile("Metod6.png");
           // pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            pictureBox6.Parent = panel1;
            panel1.AutoScroll = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
