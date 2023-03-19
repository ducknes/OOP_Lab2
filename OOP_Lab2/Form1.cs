using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Lab2
{
    public partial class Form1 : Form
    {

        static List<Bank> banks = new List<Bank>();

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void oneParamConstructor_Click(object sender, EventArgs e)
        {
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            groupBox5.Hide();

            if (!groupBox1.Visible)
            {
                groupBox1.Show();
            }
            else 
            { 
                groupBox1.Hide(); 
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].Width = 79;
            }
            textBox11.Text = Bank.banksCounter.ToString();
        }

        private void nonParamsContructor_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox3.Hide();
            groupBox3.Hide();
            groupBox5.Hide();

            if (!groupBox4.Visible)
            {
                groupBox4.Show();
                Bank bank = new Bank();
                banks.Add(bank);
                Bank.banksCounter++;
                textBox11.Text = Bank.banksCounter.ToString();
                dataGridView1.Rows.Add();
            }
            else
            {
                groupBox4.Hide();
            }
        }

        private void twoParamConstructor_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            groupBox5.Hide();

            if (!groupBox2.Visible)
            {
                groupBox2.Show();
            }
            else
            {
                groupBox2.Hide();
            }
        }

        private void createBank_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox4.Hide();
            groupBox5.Hide();

            if (!groupBox3.Visible)
            {
                groupBox3.Show();
            }
            else
            {
                groupBox3.Hide();
            }
        }

        private void viewBanks_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();

            if (!groupBox5.Visible)
            {
                groupBox5.Show();
                for (int i = 0; i < banks.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = banks[i]._bankName;
                    dataGridView1.Rows[i].Cells[1].Value = banks[i].get_countDeposits();
                    dataGridView1.Rows[i].Cells[2].Value = banks[i].get_amountDeposits();
                    dataGridView1.Rows[i].Cells[3].Value = banks[i].get_interestRate();
                    dataGridView1.Rows[i].Cells[4].Value = banks[i].get_numClients();
                    dataGridView1.Rows[i].Cells[5].Value = banks[i].get_yearFoundation();
                    dataGridView1.Rows[i].Cells[6].Value = banks[i].get_location();
                }
            }
            else
            {
                groupBox5.Hide();
            }
        }

        private void createOneParamBank_Click(object sender, EventArgs e)
        {
            try
            {
                if (isString(textBox1.Text, "Название банка"))
                {
                    Bank bank = new Bank(textBox1.Text);
                    banks.Add(bank);
                    Bank.banksCounter++;
                    dataGridView1.Rows.Add();
                    textBox11.Text = Bank.banksCounter.ToString();
                }
                textBox1.Clear();
            }
            catch(MyException MyExp)
            {
                Win32.MessageBox(0, MyExp.Message, "Ошибка!", 0);
            }
            
        }

        private void createTwoParamBank_Click(object sender, EventArgs e)
        {
            try
            {
                if (isString(textBox2.Text, "Название банка") && isInteger(textBox3.Text, "Количество депозитов"))
                {
                    Bank bank = new Bank(textBox2.Text, Convert.ToInt32(textBox3.Text));
                    banks.Add(bank);
                    Bank.banksCounter++;
                    textBox11.Text = Bank.banksCounter.ToString();
                    dataGridView1.Rows.Add();
                }
                textBox2.Clear();
                textBox3.Clear();
            }
            catch (MyException MyExp)
            {
                Win32.MessageBox(0, MyExp.Message, "Ошибка!", 0);
            }
        }

        private void createAllParamBank_Click(object sender, EventArgs e)
        {
            try
            {
                if (isString(textBox5.Text, "Название банка") && isInteger(textBox4.Text, "Количество депозитов") && 
                    isFloat(textBox7.Text, "Сумма депозитов") && isFloat(textBox6.Text, "Процентная ставка") && 
                    isInteger(textBox9.Text, "Количество клиентов") && isInteger(textBox8.Text, "Год основания") && 
                    isString(textBox10.Text, "Локация банка"))
                {
                    Bank bank = new Bank(
                        textBox5.Text,
                        Convert.ToInt32(textBox4.Text),
                        Convert.ToDouble(textBox7.Text),
                        float.Parse(textBox6.Text),
                        Convert.ToInt32(textBox9.Text),
                        Convert.ToInt32(textBox8.Text),
                        textBox10.Text
                    );
                    banks.Add(bank);
                    Bank.banksCounter++;
                    textBox11.Text = Bank.banksCounter.ToString();
                    dataGridView1.Rows.Add();
                }
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
            }
            catch (MyException MyExp)
            {
                Win32.MessageBox(0, MyExp.Message, "Ошибка!", 0);
            }
        }

        static bool isString(string str, string where)
        {
            string pattern = @"^[A-Za-zА-Яа-я]+$";
            Match match = Regex.Match(str, pattern);
            if (match.Success)
            {
                return match.Success;
            }
            throw new MyException("Вы ввели не буквенное значение в " + where);
        }

        static bool isInteger(string str, string where)
        {
            string pattern = "^[0-9]+$";
            Match match = Regex.Match(str, pattern);
            if (match.Success)
            {
                return match.Success;
            }
            throw new MyException("Вы ввели не целое число в " + where);
        }

        static bool isFloat(string str, string where)
        {
            string pattern = "^[0-9]*[.][0-9]*$";
            Match match = Regex.Match(str, pattern);
            if (match.Success)
            {
                return match.Success;
            }
            throw new MyException("Вы ввели не дробное число в " + where);
        }

        private void boom_Click(object sender, EventArgs e)
        {
            try
            {
                OOME();
            }
            catch (OutOfMemoryException OOME)
            {
                Win32.MessageBox(0, OOME.Message, "Ошибка!", 0);
            }
        }

        static void OOME()
        {
            throw new OutOfMemoryException("Вызвано OutOfMemoryException");
        }

    }
}
