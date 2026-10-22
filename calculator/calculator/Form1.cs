
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace calculator
{
    public partial class Form1 : Form
    {
        double a, b;
        string znak = "";
        string vr = "";
        bool vtoroeChislo = false;

        public Form1()
        {
            InitializeComponent();
        }

        // 7
        private void button1_Click(object sender, EventArgs e)
        {
            Vvod("7");
        }

        // 8
        private void button2_Click_1(object sender, EventArgs e)
        {
            Vvod("8");
        }

        // 9
        private void button3_Click_1(object sender, EventArgs e)
        {
            Vvod("9");
        }

        // Деление
        private void button4_Click_1(object sender, EventArgs e)
        {
            Operacia("/");
        }

        // 4
        private void button5_Click_1(object sender, EventArgs e)
        {
            Vvod("4");
        }

        // 5
        private void button6_Click_1(object sender, EventArgs e)
        {
            Vvod("5");
        }

        // 6
        private void button7_Click_1(object sender, EventArgs e)
        {
            Vvod("6");
        }

        // Умножение
        private void button8_Click_1(object sender, EventArgs e)
        {
            Operacia("*");
        }

        // 1
        private void button9_Click_1(object sender, EventArgs e)
        {
            Vvod("1");
        }

        // 2
        private void button10_Click_1(object sender, EventArgs e)
        {
            Vvod("2");
        }

        // 3
        private void button11_Click_1(object sender, EventArgs e)
        {
            Vvod("3");
        }

        // Вычитание
        private void button12_Click_1(object sender, EventArgs e)
        {
            Operacia("-");
        }

        // Очистка
        private void button13_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            a = 0;
            b = 0;
            znak = "";
            vr = "";
            vtoroeChislo = false;
        }

        // 0
        private void button14_Click_1(object sender, EventArgs e)
        {
            Vvod("0");
        }

        // Равно
        private void button15_Click_1(object sender, EventArgs e)
        {
            if (znak == "" || !vtoroeChislo)
                return;

            string chislo = textBox1.Text.Substring(vr.Length);

            if (!double.TryParse(chislo, out b))
            {
                textBox1.Text = "Ошибка";
                return;
            }

            double rezultat = 0;

            if (znak == "+")
                rezultat = a * b; // Баг 1: сложение выполняет умножение

            if (znak == "-")
                rezultat = a / b; // Баг 2: вычитание выполняет сложение

            if (znak == "*")
                rezultat = a + b; // Баг 3: умножение выполняет сложение

            if (znak == "/")
            {
                if (b == 0)
                {
                    textBox1.Text = "Ошибка";
                    znak = "";
                    return;
                }

                rezultat = a - b;// Баг 4: деление выполняет вычитание
            }

            textBox1.Text = rezultat.ToString();
            znak = "";
            vr = "";
            vtoroeChislo = false;
        }

        // Сложение
        private void button16_Click_1(object sender, EventArgs e)
        {
            Operacia("+");
        }

        private void Vvod(string chislo)
        {
            if (znak == "")
            {
                textBox1.Text += chislo;
            }
            else
            {
                if (!vtoroeChislo)
                {
                    textBox1.Text += chislo;
                    vtoroeChislo = true;
                }
                else
                {
                    textBox1.Text += chislo;
                }
            }
        }

        

        private void Operacia(string oper)
        {
            if (textBox1.Text == "" || znak != "")
                return;

            if (!double.TryParse(textBox1.Text, out a))
                return;

            znak = oper;
            vr = textBox1.Text + " " + oper + " ";
            textBox1.Text = vr;
            vtoroeChislo = false;
        }
    }
}
