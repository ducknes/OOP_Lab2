using OOP_Lab2.ClubReport;
using OOP_Lab2.LR6;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace OOP_Lab2
{
    /// <summary>
    /// Главное меню
    /// </summary>
    public partial class ComputerUI : Form 
    {

        CashRegisterProxy cashRegisterProxy = new CashRegisterProxy();

        public ComputerUI() 
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewComp viewComp = new ViewComp();
            viewComp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateComp createComp = new CreateComp();
            createComp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CompAction createAct = new CompAction();
            createAct.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteComp dc = new DeleteComp();
            dc.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //* нужно полное завершение проги, ибо при использовании кучи форм и закрытие одной из них потом тупо нельзя завершить работу проги
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                throw new StackOverflowException();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            LR4 lr4 = new LR4();
            lr4.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Strings strings = new Strings();
            strings.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Preview preview = new Preview();
            preview.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            cashRegisterProxy.AddMoney(150);
            textBox1.Clear();
            textBox1.Text = cashRegisterProxy.GetMoneyAmount().ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            cashRegisterProxy.ReleaseMoney(15);
            textBox1.Clear();
            textBox1.Text = cashRegisterProxy.GetMoneyAmount().ToString();
        }

        private async void ComputerUI_Load(object sender, EventArgs e)
        {
            await SystemTime();
        }

        private async Task SystemTime()
        {
            while (true)
            {
                time.Text = DateTime.Now.ToString();
                await Task.Delay(1000);
            }
        }

        private async Task<float> CalculateAverage(int n)
        {
            await Task.Delay(1);
            int[] array = new int[n];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                Random random = new Random();
                array[i] = random.Next(0, n);
                sum += array[i];
            }
            return sum / n;
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            float avarage = await CalculateAverage((int)numericUpDown1.Value);
            textBox2.Text = avarage.ToString();
        }
    }
}
