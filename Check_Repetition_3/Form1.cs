using System;
using System.Windows.Forms;

namespace Check_Repetition_3
{
    public partial class Form1 : Form
    {
        int j = 0;
        byte g = 0, q = 0;
        string str = "";
        string[] strings;
        string[] strings2 = { "elder", "ypypy", "dersten", "sikama", "huko", "jode", "boss", "jordan" };
        string[] strings3, strings4;
        public Form1() { InitializeComponent(); }
        private void button1_Click(object sender, EventArgs e) { Close(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            // виведення массиву слів
            for (int i = 0; i < strings2.Length; i++)
            {
                if (i == 0)
                    textBox1.Text = strings2[i];
                else
                    textBox1.Text += ", "+strings2[i];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            // оновлення
            textBox2.Text = "";
            textBox5.Text = "";
            j = 0;
            g = 0;
            CheckMethod();
        }
        public void CheckMethod()
        {
            if (textBox3.Text[0] == ' ')
            {
                MessageBox.Show(
                    "На почту першого поля стоїть пробіл",
                    "Увага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            else if (textBox4.Text[0] == ' ')
            {
                MessageBox.Show(
                    "На почту другого поля стоїть пробіл",
                    "Увага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            else if (textBox3.Text[textBox3.Text.Length-1] == ' ')
            {
                MessageBox.Show(
                    "В кінці першого поля стоїть пробіл",
                    "Увага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            else if (textBox4.Text[textBox4.Text.Length-1] == ' ')
            {
                MessageBox.Show(
                    "В кінці другого поля стоїть пробіл",
                    "Увага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            else
            {
                // перетворення введеного списку слів у масив
                strings3 = textBox3.Text.Split(' ');
                strings4 = textBox4.Text.Split(' ');
                // перевірка на наявність повторення та запис номеру позиції
                for (int i = 0; i < strings3.Length; i++)
                {
                    for (int f = 0; f < strings2.Length; f++)
                    {
                        if (strings3[i] == strings2[f])
                        {
                            if (q == 0)
                            {
                                // запис номеру позиції у простий рядок
                                str = i.ToString();
                                q = 1;
                            }
                            else
                                str += $" {i}";
                        }
                    }
                }
                // перетворення простого рядка у масив
                strings = str.Split(' ');
                // видалення слів які повторюються у списках
                for (int i = 0; i < strings3.Length; i++)
                {
                    if (j != strings.Length)
                    {
                        if (i == Convert.ToInt32(strings[j]))
                        {
                            j++;
                            continue;
                        }
                        else
                        {
                            if (g == 0)
                            {
                                g = 1;
                                textBox2.Text = strings3[i];
                            }
                            else
                                textBox2.Text += $", {strings3[i]}";
                        }
                    }
                    else
                    {
                        if (g == 0)
                        {
                            g = 1;
                            textBox2.Text = strings3[i];
                        }
                        else
                            textBox2.Text += $", {strings3[i]}";
                    }
                }
                //------------------------------
                j = 0;
                g = 0;
                for (int i = 0; i < strings4.Length; i++)
                {
                    if (j != strings.Length)
                    {
                        if (i == Convert.ToInt32(strings[j]))
                        {
                            j++;
                            continue;
                        }
                        else
                        {
                            if (g == 0)
                            {
                                g = 1;
                                textBox5.Text = strings4[i];
                            }
                            else
                                textBox5.Text += $", {strings4[i]}";
                        }
                    }
                    else
                    {
                        if (g == 0)
                        {
                            g = 1;
                            textBox5.Text = strings4[i];
                        }
                        else
                            textBox5.Text += $", {strings4[i]}";
                    }
                }
            }
        }
    }
}