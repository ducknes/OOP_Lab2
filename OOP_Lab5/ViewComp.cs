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
    /// <summary>
    /// Вывод списка экземпляров
    /// </summary>
    public partial class ViewComp : Form
    {
        public ViewComp()
        {
            InitializeComponent();
        }
        private void ViewComp_Load(object sender, EventArgs e)
        {            
            label2.Text = CompCollection.print(); //список пк по ID
            label4.Text = CompCollection.getComputerCount().ToString(); //их кол.во
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ComputerUI ui = new ComputerUI();
            ui.Show();
        }
    }
}
