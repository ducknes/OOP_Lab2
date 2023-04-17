using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Lab2
{
    

    public partial class DeleteComp : Form
    {
        public static void deleteCompMessage(string message) => MessageBox.Show(message);

        public DeleteComp()
        {
            InitializeComponent();
            CompCollection.deleteComp += deleteCompMessage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CompCollection.remove(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ComputerUI ui = new ComputerUI();
            ui.Show();
        }

        private void DeleteComp_VisibleChanged(object sender, EventArgs e)
        {
            CompCollection.deleteComp -= deleteCompMessage;
        }

        private void DeleteComp_Load(object sender, EventArgs e)
        {
            CompCollection.deleteComp += deleteCompMessage;
        }
    }
}
