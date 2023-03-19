using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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
            groupBox6.Hide();

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
            groupBox4.Hide();

            if (!groupBox6.Visible)
            {
                groupBox6.Show();
                Bank bank = new Bank();
                banks.Add(bank);
                Bank.banksCounter++;
                textBox11.Text = Bank.banksCounter.ToString();
                dataGridView1.Rows.Add();
                comboBox1.Items.Add(bank._bankName);
            }
            else
            {
                groupBox6.Hide();
            }
        }

        private void twoParamConstructor_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            groupBox5.Hide();
            groupBox6.Hide();

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
            groupBox6.Hide();

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
            groupBox6.Hide();

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
                if (Functions.isString(textBox1.Text, "Название банка"))
                {
                    Bank bank = new Bank(textBox1.Text);
                    banks.Add(bank);
                    Bank.banksCounter++;
                    dataGridView1.Rows.Add();
                    textBox11.Text = Bank.banksCounter.ToString();
                    comboBox1.Items.Add(bank._bankName);
                }
                MessageBox.Show("Банк успешно создан", "Успешный успех!");
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
                if (Functions.isString(textBox2.Text, "Название банка") && Functions.isInteger(textBox3.Text, "Количество депозитов"))
                {
                    Bank bank = new Bank(textBox2.Text, Convert.ToInt32(textBox3.Text));
                    banks.Add(bank);
                    Bank.banksCounter++;
                    textBox11.Text = Bank.banksCounter.ToString();
                    dataGridView1.Rows.Add();
                    comboBox1.Items.Add(bank._bankName);
                }
                MessageBox.Show("Банк успешно создан", "Успешный успех!");
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
                if (Functions.isString(textBox5.Text, "Название банка") && Functions.isInteger(textBox4.Text, "Количество депозитов") &&
                    Functions.isFloat(textBox7.Text, "Сумма депозитов") && Functions.isFloat(textBox6.Text, "Процентная ставка") &&
                    Functions.isInteger(textBox9.Text, "Количество клиентов") && Functions.isInteger(textBox8.Text, "Год основания") &&
                    Functions.isString(textBox10.Text, "Локация банка"))
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
                    comboBox1.Items.Add(bank._bankName);
                }
                MessageBox.Show("Банк успешно создан", "Успешный успех!");
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

        private void changeFields_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox6.Hide();
            groupBox5.Hide();

            if (!groupBox4.Visible)
            {
                groupBox4.Show();
            }
            else
            {
                groupBox4.Hide();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void find_Click(object sender, EventArgs e)
        {
            textBox18.Text = banks[findIdByName(comboBox1.SelectedItem.ToString())]._bankName;
            textBox17.Text = banks[findIdByName(comboBox1.SelectedItem.ToString())].get_countDeposits().ToString();
            textBox16.Text = banks[findIdByName(comboBox1.SelectedItem.ToString())].get_amountDeposits().ToString();
            textBox15.Text = banks[findIdByName(comboBox1.SelectedItem.ToString())].get_interestRate().ToString();
            textBox14.Text = banks[findIdByName(comboBox1.SelectedItem.ToString())].get_numClients().ToString();
            textBox13.Text = banks[findIdByName(comboBox1.SelectedItem.ToString())].get_yearFoundation().ToString();
            textBox12.Text = banks[findIdByName(comboBox1.SelectedItem.ToString())].get_location();
        }

        static int findIdByName(string name)
        {
            for (int i = 0; i < banks.Count; i++)
            {
                if (name.Equals(banks[i]._bankName))
                {
                    return i;
                }
            }
            return 0;
        }

        private void change_Click(object sender, EventArgs e)
        {
            int currentIndex = findIdByName(comboBox1.SelectedItem.ToString());
            try
            {
                if (Functions.isString(textBox18.Text, "Название банка") && Functions.isInteger(textBox17.Text, "Количество депозитов") &&
                    Functions.isFloat(textBox16.Text, "Сумма депозитов") && Functions.isFloat(textBox15.Text, "Процентная ставка") &&
                    Functions.isInteger(textBox14.Text, "Количество клиентов") && Functions.isInteger(textBox13.Text, "Год основания") &&
                    Functions.isString(textBox12.Text, "Локация банка"))
                {
                    Bank bank = new Bank(
                        textBox18.Text,
                        Convert.ToInt32(textBox17.Text),
                        Convert.ToDouble(textBox16.Text),
                        float.Parse(textBox15.Text),
                        Convert.ToInt32(textBox14.Text),
                        Convert.ToInt32(textBox13.Text),
                        textBox12.Text
                    );
                    banks[currentIndex] = bank;
                    comboBox1.Items.Add(bank._bankName);
                }
                comboBox1.Items.Remove(comboBox1.SelectedItem);
                MessageBox.Show("Банк успешно изменён", "Успешный успех!");
                textBox12.Clear();
                textBox13.Clear();
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
                textBox17.Clear();
                textBox18.Clear();
            }
            catch (MyException MyExp)
            {
                Win32.MessageBox(0, MyExp.Message, "Ошибка!", 0);
            }
        }
    }
}
