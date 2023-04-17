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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace OOP_Lab2
{
    public partial class LR4 : Form
    {

        CollectionType<Computer> _comps = new CollectionType<Computer>();

        public LR4()
        {
            InitializeComponent();

            _comps.Add(new Computer("AMD", 4.2, 32, MyException.randomPrice(), "4090", 24, 800));
            _comps.Add(new Computer("Intel", 4.3, 16, MyException.randomPrice(), "4060", 8, 700));
            _comps.Add(new Computer("AMD", 4.4, 32, MyException.randomPrice(), "4090", 24, 800));
            _comps.Add(new Computer("Intel", 4.5, 20, MyException.randomPrice(), "4060", 12, 700));
            _comps.Add(new Computer("AMD", 4.6, 32, MyException.randomPrice(), "4090", 24, 800));
        }

        private void LR4_Load(object sender, EventArgs e)
        {
            tableShow();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ComputerUI computerUI = new ComputerUI();
            computerUI.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = _comps.GetList().Count(computer => computer.ProcessorType == "Intel").ToString();
            textBox2.Text = _comps.GetList().Max(computer => computer.ProcessorFrequency).ToString();
            textBox3.Text = _comps.GetList().Min(computer => computer.ProcessorFrequency).ToString();
            textBox4.Text = _comps.GetList().Where(comp => comp.VideoCard == "4090").Take(1).First().ComputerID.ToString();
            textBox5.Text = _comps.GetList().Where(comp => comp.VideoCard == "4090").Reverse().Average(comp => comp.ComputerCost).ToString();
            textBox6.Text = _comps.GetList().Skip(2).Take(3).Sum(comp => comp.ComputerCost).ToString();
            textBox7.Text = _comps.GetList().Where(comp => comp.VideoCard == "4060").Reverse().All(comp=>comp.MemoryCapacity == 8).ToString();
            textBox8.Text = _comps.GetList().Take(2).Select(comp => comp.MemoryCapacity).Average().ToString();
        }

        private void tableShow()
        {
            dataGridView1.Rows.Clear();
            foreach (Computer computer in _comps)
            {
                dataGridView1.Rows.Add(
                    computer.ComputerID,
                    computer.ProcessorType,
                    computer.ProcessorFrequency,
                    computer.MemoryCapacity,
                    computer.VideoCard,
                    computer.VideoCapacity,
                    computer.PowerUnit,
                    computer.ComputerCost
                );
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _comps.Sort(_comps.GetList().OrderBy(comp=>comp.ComputerCost).ToList());
            tableShow();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var library in _comps)
            {
                stringBuilder.AppendLine(library.ToString());
            }
            using (StreamWriter writer = new StreamWriter(@"C:\dev\projects\max oop lab\OOP_Lab2\comps.txt", false))
            {
                await writer.WriteLineAsync(stringBuilder.ToString());
            }
        }
    }
}
