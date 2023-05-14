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

namespace OOP_Lab2.ClubReport
{
    public partial class Preview : Form
    {
        public Preview()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void Preview_Load(object sender, EventArgs e)
        {
            List<Computer> comps = new List<Computer>()
            {
                new Computer("Intel Core i5-12400F", 4.4, 16,
                    80300, "GeForce RTX 3060", 12,650),
                new Computer("Intel Core i5-12400F", 4.4, 32,
                    104000, "GeForce RTX 3070", 8, 650),
                new Computer("Intel Core i5-12400F", 4.4, 16,
                    87000, "GeForce RTX 3060Ti", 8, 700),
                new Computer("Intel Core i5-12400F", 4.4, 16,
                    65000, "GeForce RTX 3050", 8,650),
                new Computer( "Intel Core i3-10105F", 4.4, 16,
                    40000, "GeForce GTX 1650", 4, 500)
            };

            var builder = new ClubReportBuilder(comps);

            var admin = new Admin(builder);

            admin.Build();

            var report = builder.GetReport();

            richTextBox1.AppendText(report.ToString());

            using (StreamWriter writer = new StreamWriter(@"Z:\Downloads\2 курс\ООП\Labs\OOP_Lab5\ClubReport\report.txt", false))
            {
                await writer.WriteLineAsync(report.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ComputerUI computerUI = new ComputerUI();
            computerUI.Show();
        }
    }
}
