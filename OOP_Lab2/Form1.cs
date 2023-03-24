using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace OOP_Lab2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            MyDictionary.objectCreated += newObjectCreated;
            MyDictionary.objectDeleted += newObjectDeleted;
        }

        public static void newObjectCreated(object sender, EventArgs e)
        {
            MessageBox.Show("объект создан");
        }

        public static void newObjectDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("объект удален");
        }

        private void oneParamConstructor_Click(object sender, EventArgs e)
        {
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            groupBox5.Hide();
            groupBox6.Hide();
            groupBox7.Hide();

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
            textBox11.Text = MyDictionary.BankCount().ToString();

            listView1.Columns.Add("Коллекция");
            listView1.Columns.Add("Генерирование");
            listView1.Columns.Add("Последовательный выбор");
            listView1.Columns.Add("Случайный выбор");
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void nonParamsContructor_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox3.Hide();
            groupBox3.Hide();
            groupBox5.Hide();
            groupBox4.Hide();
            groupBox7.Hide();

            if (!groupBox6.Visible)
            {
                groupBox6.Show();
                Bank bank = new Bank();
                bool addCheck = false;
                while (!addCheck) {
                    addCheck = MyDictionary.Add(bank._bankName, bank);
                }
                textBox11.Text = MyDictionary.BankCount().ToString();
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
            groupBox7.Hide();

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
            groupBox7.Hide();

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
            groupBox7.Hide();

            dataGridView1.Rows.Clear();

            if (!groupBox5.Visible)
            {
                groupBox5.Show();

                int currentRow = 0;
                foreach (var bank in MyDictionary.GetMyDictionary())
                {

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[currentRow].Cells[0].Value = bank.Key;
                    dataGridView1.Rows[currentRow].Cells[1].Value = bank.Value.get_countDeposits();
                    dataGridView1.Rows[currentRow].Cells[2].Value = bank.Value.get_amountDeposits();
                    dataGridView1.Rows[currentRow].Cells[3].Value = bank.Value.get_interestRate();
                    dataGridView1.Rows[currentRow].Cells[4].Value = bank.Value.get_numClients();
                    dataGridView1.Rows[currentRow].Cells[5].Value = bank.Value.get_yearFoundation();
                    dataGridView1.Rows[currentRow].Cells[6].Value = bank.Value.get_location();
                    currentRow++;
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
                    bool addCheck = MyDictionary.Add(textBox1.Text, new Bank(textBox1.Text));
                    if (!addCheck) 
                    {
                        throw new MyException("Такой банк уже есть в базе");
                    }
                    textBox11.Text = MyDictionary.BankCount().ToString();
                    comboBox1.Items.Add(textBox1.Text);
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
                    bool addCheck = MyDictionary.Add(textBox2.Text, new Bank(textBox2.Text, Convert.ToInt32(textBox3.Text)));
                    if (!addCheck)
                    {
                        throw new MyException("Такой банк уже есть в базе");
                    }
                    textBox11.Text = MyDictionary.BankCount().ToString();
                    comboBox1.Items.Add(textBox2.Text);
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
                    bool addCheck = MyDictionary.Add(textBox5.Text, new Bank(
                            textBox5.Text,
                            Convert.ToInt32(textBox4.Text),
                            Convert.ToDouble(textBox7.Text),
                            float.Parse(textBox6.Text),
                            Convert.ToInt32(textBox9.Text),
                            Convert.ToInt32(textBox8.Text),
                            textBox10.Text
                            )
                        );
                    if (!addCheck)
                    {
                        throw new MyException("Такой банк уже есть в базе");
                    }
                    textBox11.Text = MyDictionary.BankCount().ToString();
                    comboBox1.Items.Add(textBox5.Text);
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
            groupBox7.Hide();

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
            Bank bank = MyDictionary.FindBankByName(comboBox1.SelectedItem.ToString());
            textBox18.Text = bank._bankName;
            textBox17.Text = bank.get_countDeposits().ToString();
            textBox16.Text = bank.get_amountDeposits().ToString();
            textBox15.Text = bank.get_interestRate().ToString();
            textBox14.Text = bank.get_numClients().ToString();
            textBox13.Text = bank.get_yearFoundation().ToString();
            textBox12.Text = bank.get_location();
        }

        private void change_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (Functions.isString(textBox18.Text, "Название банка") && Functions.isInteger(textBox17.Text, "Количество депозитов") &&
                    Functions.isFloat(textBox16.Text, "Сумма депозитов") && Functions.isFloat(textBox15.Text, "Процентная ставка") &&
                    Functions.isInteger(textBox14.Text, "Количество клиентов") && Functions.isInteger(textBox13.Text, "Год основания") &&
                    Functions.isString(textBox12.Text, "Локация банка"))
                {
                    Dictionary<string, Bank> temp = MyDictionary.GetMyDictionary();
                    if (textBox18.Text != comboBox1.SelectedItem.ToString())
                    {
                        MyDictionary.Remove(textBox18.Text);
                        bool addCheck = MyDictionary.Add(textBox18.Text, new Bank(
                            textBox18.Text,
                            Convert.ToInt32(textBox17.Text),
                            Convert.ToDouble(textBox16.Text),
                            float.Parse(textBox15.Text),
                            Convert.ToInt32(textBox14.Text),
                            Convert.ToInt32(textBox13.Text),
                            textBox12.Text
                        ));
                        comboBox1.Items.Add(textBox18.Text);
                    }
                    temp[comboBox1.SelectedItem.ToString()] = new Bank(
                            textBox18.Text,
                            Convert.ToInt32(textBox17.Text),
                            Convert.ToDouble(textBox16.Text),
                            float.Parse(textBox15.Text),
                            Convert.ToInt32(textBox14.Text),
                            Convert.ToInt32(textBox13.Text),
                            textBox12.Text
                        );
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

        private void poductivity_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            groupBox5.Hide();
            groupBox6.Hide();

            if (!groupBox7.Visible)
            {
                groupBox7.Show();
            } 
            else
            {
                groupBox7.Hide();
            }
        }

        private void timeCompare_Click(object sender, EventArgs e)
        {
            ListViewItem dictItem = new ListViewItem("Словарь");
            ListViewItem arrayItem = new ListViewItem("Массив");

            MyDictionary.Clear();

            const int N = 100000;
            Bank[] bankArray = new Bank[N];

            Stopwatch timeDict = new Stopwatch();
            Stopwatch timeArray = new Stopwatch();

            // Генерация
            timeDict.Start();
            for (int i = 0; i < N; i++)
            {
                MyDictionary.AddForTest();
            }
            timeDict.Stop();
            dictItem.SubItems.Add(timeDict.ElapsedMilliseconds.ToString());

            // Последовательный выбор
            timeDict.Start();
            foreach (var bank in MyDictionary.GetMyDictionary())
            {
                Bank temp = bank.Value;
            }
            timeDict.Stop();
            dictItem.SubItems.Add(timeDict.ElapsedMilliseconds.ToString());

            // Случайный выбор
            string[] keys = MyDictionary.GetKeysList();
            timeDict.Start();
            for (int i = 0; i < N; i++)
            {
                Bank temp = MyDictionary.FindBankByName(keys[new Random().Next(1, MyDictionary.BankCount()) - 1]);
            }
            timeDict.Stop();
            dictItem.SubItems.Add(timeDict.ElapsedMilliseconds.ToString());

            // Генерация
            timeArray.Start();
            for (int i = 0; i < N; i++)
            {
                bankArray[i] = new Bank();
            }
            timeArray.Stop();
            arrayItem.SubItems.Add(timeArray.ElapsedMilliseconds.ToString());

            //Последовательный выбор
            timeArray.Start();
            foreach (var bank in bankArray)
            {
                Bank temp = bank;
            }
            timeArray.Stop();
            arrayItem.SubItems.Add(timeArray.ElapsedMilliseconds.ToString());

            // Случайный выбор
            timeArray.Start();
            for (int i = 0; i < N; i++)
            {
                Bank temp = bankArray[new Random().Next(1, bankArray.Length) - 1];
            }
            timeArray.Stop();
            arrayItem.SubItems.Add(timeArray.ElapsedMilliseconds.ToString());

            listView1.Items.Add(dictItem);
            listView1.Items.Add(arrayItem);
        }
    }
}
