using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Lab2
{
    public partial class Strings : Form
    {

        LinkedList<string> strings = new LinkedList<string>();

        public Strings()
        {
            InitializeComponent();
        }

        private void Strings_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int min = (int)minD.Value;
            int max = (int)maxD.Value;
            Char[] pwdChars = new Char[36] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (int i = 0; i < (int)lenArray.Value; i++) {
                string result = String.Empty;
                int lenStr = rnd.Next(min, max);
                for (int j = 0; j < lenStr; j++)
                    result += pwdChars[rnd.Next(0, 36)];
                strings.AddLast(result);
                richTextBox1.AppendText(result + "\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ComputerUI computerUI = new ComputerUI();
            computerUI.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (search.Text == String.Empty)
            {
                return;
            }
            richTextBox2.Clear();
            string templateForSearch = search.Text;
            foreach (string str in strings) 
            {
                if (str.IndexOf(templateForSearch) != -1)
                {
                    richTextBox2.AppendText(str + "\n");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var temp = strings.OrderBy(str => str.Length).ToList();
            strings.Clear();
            foreach (var item in temp)
            {
                strings.AddLast(item);
            }
            richTextBox1.Clear();
            foreach (var str in strings)
            {
                richTextBox1.AppendText(str + "\n");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            count.Text = strings.Count(str =>  str.Length == (int)numericUpDown4.Value).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var temp = strings.OrderByDescending(str => str.Length).ToList();
            strings.Clear();
            foreach (var item in temp)
            {
                strings.AddLast(item);
            }
            richTextBox1.Clear();
            foreach (var str in strings)
            {
                richTextBox1.AppendText(str + "\n");
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var str in strings)
            {
                stringBuilder.AppendLine(str);
            }
            using (StreamWriter writer = new StreamWriter(@"C:\dev\projects\max oop lab\OOP_Lab2\strings.txt", false))
            {
                await writer.WriteLineAsync(stringBuilder.ToString());
            }
        }
    }
}
