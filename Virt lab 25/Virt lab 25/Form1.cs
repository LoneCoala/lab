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
        public string name = "123123";



        public bool startButtonClicked = false;
        public double amountOfFluctations;
        public double solutionForProblemNumber;
        public Form1()
        {
            
            InitializeComponent();
            pictureBox1.Enabled = false;

            // Bob = new Point(Origin.X,(int)Length);
            label4.Text = name;
            timer1.Interval = 10;
        }

        private dynamic converDataFromTable(int row, int column)
        {
            if (dataGridView1.Rows[row].Cells[column].Value == null)
            {
                showTextBox("ячейки значений T пусты", "Сообщение");
                return null;
            }
            else
            {
                return (Convert.ToDouble(dataGridView1.Rows[row].Cells[column].Value));
            }
        }

        bool checkIsEqual(double periodCalculated,double periodInATable)
        {
            return (periodCalculated == periodInATable);
        }

        private void check_Results_Click(object sender, System.EventArgs e)
        {
            Register reg = new Register();
            // проверка значений в таблице, сначала проверяю 6 измерений или нет, затем что значения T не равны нулю(введены), затем что g == 9.8, если работает то должно выдаваться "всё ок", иначе соответсвующие сообщения
            bool isAmountOfDataCorrect = dataGridView1.Rows.Count == 6;
            if (isAmountOfDataCorrect)
            {
                double g = 0;
                int amountOfCorrect = 0;
                for (int row = 0; row <= 5; row++)
                {
                    double timeFromTable = converDataFromTable(row, 2);
                    double periodInATable = converDataFromTable(row, 4);
                    bool isGNotNull = dataGridView1.Rows[row].Cells[5].Value != null;

                    if (isGNotNull)
                    {

                        var gForce = converDataFromTable(row, 5);
                        if (gForce == 9.8 && checkIsEqual(timeFromTable, periodInATable * amountOfFluctations))
                        {
                            showTextBox("Успешно преобразовали T", "Сообщение");
                        }
                        else
                        {
                            showTextBox("Плохо преобразовали", "Сообщение");
                        }

                    }

                }
                showTextBox("OK", "Сообщение");

            }
            else
            {
                showTextBox("ERROR", "КОЛ-ВА ИЗМЕРЕНИЙ НЕ СООТВЕТСВУЮТ ДРУГ ДРУГУ");
            }
        }



        int quantity = 0; // Счетчик измерений 
        double Atime = 0; // время 10 колебаний 
        
        bool checkGValue(float amountOfFluctations, float tsmall, float tbig)
        {
            if ((tsmall / amountOfFluctations) == tbig)
            {
                return true;
            }
            else
            {
                return false;
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
        private void button2_Click_1(object sender, EventArgs e)
        {

            if (quantity <= 5) // проверка на количество измерений 
            {
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
                startButtonClicked = true;
                timer1.Enabled = false;
                timer1.Start();
                this.Invalidate();
                double g, l, T, t,n;
                Register reg = new Register();
                n = reg.amountOfFluctationsInput;
                n = (int)amountOfFluctations;
                l = Convert.ToDouble(numericUpDown1.Value) / 100;
                bool check = false;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if ( l == Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value))
                    {
                        showTextBox("Вы уже провели измерение с данной длиной", "Сообщение");
                        check = true;
                    }
                }
                if (check == false)
                {
                    quantity++;
                    int number = dataGridView1.Rows.Add();
                    dataGridView1.Rows[number].Cells[1].Value = l;
                    g = 9.8;
                    g = Math.Round(g, 2);
                    T = 2 * Math.PI * Math.Sqrt(l / g);
                    T = Math.Round(T, 2);
                    t = T * n;
                    t = Math.Round(t, 2);
                    if (l == 0.32)
                    {
                        solutionForProblemNumber = T;
                    }
                    time = t;
                    Atime = Atime + time;

                    // textBox1.Text = Convert.ToString(t); ?
                    dataGridView1.Rows[number].Cells[0].Value = number + 1;  // вписываем номер № действия
                    dataGridView1.Rows[number].Cells[0].ReadOnly = true; // Блокировка ввода номера опыта

                    //dataGridView1.Rows[number].Cells[1].Value = l; // вписываем длину нити
                    dataGridView1.Rows[number].Cells[1].ReadOnly = true; // Блокировка ввода длины нити 

                    dataGridView1.Rows[number].Cells[2].Value = time; // ввод времени t
                    dataGridView1.Rows[number].Cells[2].ReadOnly = true; // Блокировка ввода времени t

                    dataGridView1.Rows[number].Cells[3].Value = n; // кол-во колебаний, всегда 10
                    dataGridView1.Rows[number].Cells[3].ReadOnly = true; // Блокировка ввода количества колебаний
                    dataGridView1.Rows[number].Cells[4].Value = 0;
                    dataGridView1.Rows[number].Cells[5].Value = 0;
                }
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
                    AngularAcceleration = (float)(-0.01 * Math.Sin(Angle));
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        private void button4_Click(object sender, EventArgs e)
        {
            Protocol protocol = new Protocol();
            protocol.fullName = name;
            protocol.Show();
        }
    }
}