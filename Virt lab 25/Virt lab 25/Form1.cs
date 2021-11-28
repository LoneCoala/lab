using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Virt_lab_25
{
    //Application.Run(new Register());
    public partial class Form1 : Form
    {
        private bool startButtonClicked = false;




        public Form1()
        {
            InitializeComponent();
            pictureBox1.Enabled = false;

            // Bob = new Point(Origin.X,(int)Length);

            timer1.Interval = 10;


        }
        int quantity = 0; // Счетчик измерений 
        double Atime = 0; // время 10 колебаний 
        private void check_Results_Click(object sender, System.EventArgs e)
        {
            // проверка значений в таблице, сначала проверяю 10 измерений или нет, затем что значения T не равны нулю(введены), затем что g == 9.8, если работает то должно выдаваться "всё ок", иначе соответсвующие сообщения
            int j = 0;
            if (dataGridView1.Rows.Count < 6) // проверка на кол-во измерений
            {
                showTextBox("Неверное количество измерений", "Сообщение");
            }
            else
            {
                for (int i = 0; i <= 5; i++)
                {
                    double a = 0;
                    if (dataGridView1.Rows[i].Cells[4].Value == null) // проверка T
                    {
                        showTextBox("ячейки значений T пусты", "Сообщение");
                        break;
                    }
                    else
                    {
                        if (dataGridView1.Rows[i].Cells[5].Value == null) // проверка g, сначало что не null
                        {

                            showTextBox("ячейки значений g пусты", "Сообщение");
                            break;
                        }
                        else
                        {
                            if (Double.TryParse(dataGridView1.Rows[i].Cells[5].Value.ToString(), out a)) // преобразуем в double 
                            {
                                if (a == 9.8)
                                    j++;
                            }
                            else
                            {
                                showTextBox("Не удалось преобразовать", "Сообщение");
                                break;
                            }
                        }
                    }
                }
                if (j == 6) // если всё преобразовалось то соответсвующее сообщение
                {
                    showTextBox("Всё ок", "Сообщение");
                }
                else if (j < 6)
                {
                    showTextBox("Неверные значения g", "Сообщение");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }
        Form3 metodichka = new Form3();
        private void button3_Click(object sender, EventArgs e)
        {
            metodichka.Show();
        }
        Form2 taskList = new Form2();
        private void button5_Click(object sender, EventArgs e)
        {
            taskList.Show();
        }
        double time = 0;
        double period = 1;

        double uoi =0; // переменная на +2 см в рассчеты 

        private void button2_Click_1(object sender, EventArgs e)
        {

            if (quantity <= 5) // проверка на количество измерений 
            {
                quantity++;
                int length = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
                Point Origin = new Point(pictureBox1.Width / 2, 0);
                float Length = length * 3;
                Point Bob = new Point(Origin.X, (int)Length);

                Graphics G = pictureBox1.CreateGraphics();
                Pen pen;
                float Angle = (float)Math.PI / 13;
                float AnglularVelocity = -0.01f;
                float AngularAcceleration = 0.0f;

                timer1.Interval = 10;



                int number = dataGridView1.Rows.Add();

                startButtonClicked = true;
                timer1.Enabled = false;
                timer1.Start();


                this.Invalidate();
                double g, l, T, t, n = 10;
                l = Convert.ToDouble(numericUpDown1.Value) / 100;
              //  uoi = uoi + 0.02;
                g = 9.8;
                T = 2 * Math.PI * Math.Sqrt(l / g);
                T = Math.Round(T, 2);
                t = T * n;
                t = Math.Round(t, 2);
                time = t;
                period = T;
                Atime = Atime + time;

                // textBox1.Text = Convert.ToString(t); ?
                dataGridView1.Rows[number].Cells[0].Value = number + 1;  // вписываем номер № действия
                dataGridView1.Rows[number].Cells[0].ReadOnly = true; // Блокировка ввода номера опыта

                dataGridView1.Rows[number].Cells[1].Value = l; // вписываем длину нити
                dataGridView1.Rows[number].Cells[1].ReadOnly = true; // Блокировка ввода длины нити 

                dataGridView1.Rows[number].Cells[2].Value = time; // ввод времени t
                dataGridView1.Rows[number].Cells[2].ReadOnly = true; // Блокировка ввода времени t

                dataGridView1.Rows[number].Cells[3].Value = 10; // кол-во колебаний, всегда 10
                dataGridView1.Rows[number].Cells[3].ReadOnly = true; // Блокировка ввода количества колебаний

                Brush brush = Brushes.Red;
                pen = new Pen(Color.Black, 2);
                do
                {

                    Bob.X = (int)(Length * Math.Sin(Angle) + Origin.X);
                    Bob.Y = (int)(Length * Math.Cos(Angle) + Origin.Y);

                    Angle += AnglularVelocity;
                    AnglularVelocity += AngularAcceleration;

                    AnglularVelocity *= (float)0.99;

                    //  G.DrawLine(pen, Origin.X, Origin.Y, Bob.X, Bob.Y);
                    G.DrawLine(pen, Origin.X, Origin.Y, Bob.X, Bob.Y);
                    // G.DrawEllipse(pen, Bob.X - 17, Bob.Y, 40, 40);
                    G.FillEllipse(brush, Bob.X - 8, Bob.Y - 2, 17, 17);
                    Application.DoEvents();


                    Thread.Sleep(14);
                    pictureBox1.Refresh();
                    AngularAcceleration = (float)(-0.005 * Math.Sin(Angle));
                    G.FillEllipse(brush, Bob.X - 8, Bob.Y - 2, 17, 17);
                    // G.DrawLine(pen, Origin.X, Origin.Y, Bob.X, Bob.Y);
                    //      G.DrawEllipse(pen, Bob.X - 17, Bob.Y, 40, 40);


                } while (timer1.Enabled);

                AngularAcceleration = 0;
                Angle = 0;
                AnglularVelocity = 0;

            }
            else
            {
                showTextBox("Вы провели максимальное число измерений", "Сообщение");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 10;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        static bool checkNumberText(object number)
        {
            if (!double.TryParse(number.ToString(), out _))
            {
                return (false);
            }
            else
            {
                return (true);
            }

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!checkNumberText(dataGridView1[e.ColumnIndex, e.RowIndex].Value))
            {
                MessageBox.Show("Некоректные данные(Формат записи дробей: 1,33)");
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = "";
            }
        }


        private void showTextBox(String message, String description)
        {
            MessageBox.Show(
                   message,
                   description);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           label2.Text = numericUpDown1.Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}