using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP_Lab2
{
    /// <summary>
    /// Расширенный создатель экземпляров
    /// </summary>
    public partial class CreateCompMore : Form 
    {
        private string status = "";

        public CreateCompMore(string param)
        {
            CompCollection.createComp += CreateComp.createCompMessage;

            status = param;
            InitializeComponent();
            if (status == "price")
            {
                label3.Visible = true;
                textBox3.Visible = true;
            }
            else if (status == "processor")
            {
                label1.Visible = true;
                textBox1.Visible = true;
                label2.Visible = true;
                textBox2.Visible = true;
            }
            else if (status == "fullComp")
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
            
                Computer computer = null;
                switch (status)
                {
                    case "price": //пустой с ценой
                        int computerCost = MyException.isInteger(textBox3.Text, "поле цена");
                        computer = new Computer(computerCost);           
                        break;

                    case "processor": //с процессором
                        
                        String processorType = MyException.isString(textBox1.Text, "поле тип процессора");
                        double processorFrequency = MyException.isDouble(textBox2.Text, "поле частота процессора");
                        computer = new Computer(processorType, processorFrequency);    
                        break;

                    case "fullComp": //полный
                        String processorType2 = MyException.isString(textBox1.Text, "поле тип процессора");
                        double processorFrequency2 = MyException.isDouble(textBox2.Text, "поле частота процессора");
                        int computerCost2 = MyException.isInteger(textBox3.Text, "поле цена");
                        int memoryCapacity = MyException.isInteger(textBox4.Text, "поле объем ОЗУ");
                        String videoCard = MyException.isString(textBox5.Text, "поле тип видеокарты");
                        int videoCapacity = MyException.isInteger(textBox6.Text, "поле объем видеопамяти");
                        int powerUnit = MyException.isInteger(textBox7.Text, "поле мощность БП");
                        computer = new Computer(processorType2, processorFrequency2, memoryCapacity, computerCost2,
                            videoCard, videoCapacity, powerUnit);
                        break;
                    default:
                        break;
                }
                CompCollection.add(computer);
            }
            catch(Exception ex)
            {
                Win32.MessageBox(0, ex.Message, "Ошибка!", 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ComputerUI ui = new ComputerUI();
            ui.Show();
        }

        private void CreateCompMore_Load(object sender, EventArgs e)
        {
            CompCollection.createComp += CreateComp.createCompMessage;
        }

        private void CreateCompMore_VisibleChanged(object sender, EventArgs e)
        {
            CompCollection.createComp -= CreateComp.createCompMessage;
        }
    }
}
