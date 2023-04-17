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
    /// начальная страница для создания экземпляров
    /// </summary>
    public partial class CreateComp : Form 
    {
        /// <summary>
        /// Обработчик события
        /// </summary>
        /// <param name="message"></param>
        public static void createCompMessage(string message) => MessageBox.Show(message);

        public CreateComp()
        {
            InitializeComponent();
            CompCollection.createComp += createCompMessage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
 
            Computer computer = new Computer();
            CompCollection.add(computer);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateCompMore ccm = new CreateCompMore("price");
            ccm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateCompMore ccm = new CreateCompMore("processor");
            ccm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateCompMore ccm = new CreateCompMore("fullComp");
            ccm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ComputerUI ui = new ComputerUI();
            ui.Show();
        }

        private void CreateComp_Load(object sender, EventArgs e)
        {
            CompCollection.createComp += createCompMessage;
            //*при использование множества форм и операции += ивент может добавить метод несколько раз,
            //поэтому его нужно добавить два раза в конструкторе и лоаде, а затем один раз удалить VisibleChanged(show,hide текущей формы)
            //без этого обработчик событий работает через жопу
        }
        private void CreateComp_VisibleChanged(object sender, EventArgs e)
        {
            CompCollection.createComp -= createCompMessage;
        }
    }
}
