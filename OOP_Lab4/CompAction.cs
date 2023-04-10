using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Lab2
{
    /// <summary>
    /// Страница для редактирования экземпляра
    /// </summary>
    public partial class CompAction : Form
    {

        Computer localComp;

        public static void actionCompMessage(string message) => MessageBox.Show(message);
        public CompAction()
        {
            InitializeComponent();
            CompCollection.findComp += actionCompMessage;
        }

        public CompAction(string id)
        {
            InitializeComponent();
            textBox1.Text = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            localComp = CompCollection.find(textBox1.Text);
            if (localComp != null)
            {
                label2.Visible = true;
                label2.Text = localComp.ToString();
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            localComp = CompCollection.find(textBox1.Text);
            if (localComp != null)
            {
                this.Hide();
                EditComp ec = new EditComp(localComp);
                ec.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            localComp = CompCollection.find(textBox1.Text);
            if (localComp != null)
            {
                localComp.idConvertor();
                label2.Visible = true;
                label2.Text = $"ID компьютера {textBox1.Text} преобразовано в ID:{localComp.ComputerID}";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ComputerUI ui = new ComputerUI();
            ui.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            int[] res = CompCollection.stressTest();

            ListViewItem item = new ListViewItem(res[0].ToString());
            item.SubItems.Add(res[1].ToString());
            item.SubItems.Add(res[2].ToString());
            listView1.Items.Add(item);
            listView1.Visible = true;
        }

        private void CompAction_Load(object sender, EventArgs e)
        {
            CompCollection.findComp += actionCompMessage;
        }

        private void CompAction_VisibleChanged(object sender, EventArgs e)
        {
            CompCollection.findComp -= actionCompMessage;
        }


    }
}
