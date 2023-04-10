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
    /// Редактор полей экземляров
    /// </summary>
    public partial class EditComp : Form
    {
        private Computer localEditComp;

        public static void editCompMessage(string type, string value) => MessageBox.Show($"В поле {type} значение успешно заменено на {value}");
        public static void printCompFieldMessage(string type, string value) => MessageBox.Show($"Значение поля {type} - {value}");

        public EditComp(Computer localComp)
        {
            InitializeComponent();
            localEditComp = localComp;
            CompCollection.editComp += editCompMessage;
            CompCollection.printCompField += printCompFieldMessage;
        }

        //вывести выбранное поле
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                CompCollection.printField(localEditComp, "ProcessorType");
            }

            if (radioButton2.Checked)
            {
                CompCollection.printField(localEditComp, "ProcessorFrequency");
            }

            if (radioButton3.Checked)
            {
                CompCollection.printField(localEditComp, "MemoryCapacity");
            }

            if (radioButton4.Checked)
            {
                CompCollection.printField(localEditComp, "VideoCard");
            }

            if (radioButton5.Checked)
            {
                CompCollection.printField(localEditComp, "VideoCapacity");
            }

            if (radioButton6.Checked)
            {
                CompCollection.printField(localEditComp, "PowerUnit");
            }

            if (radioButton7.Checked)
            {
                CompCollection.printField(localEditComp, "ComputerCost");
            }
        }


        //изменить выбранное поле
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (radioButton1.Checked)
                {
                    string newProcessorType = MyException.isString(textBox1.Text, "поле процессор");
                    CompCollection.editField(localEditComp, "ProcessorType", newProcessorType);
                    textBox1.Text = "";
                }

                if (radioButton2.Checked)
                {
                    string newProcessorFrequency = MyException.isDouble(textBox2.Text, "поле частота процессора").ToString();
                    CompCollection.editField(localEditComp, "ProcessorFrequency", newProcessorFrequency);
                    textBox2.Text = "";
                }

                if (radioButton3.Checked)
                {
                    string newMemoryCapacity = MyException.isInteger(textBox3.Text, "поле объем ОЗУ").ToString(); ;
                    CompCollection.editField(localEditComp, "MemoryCapacity", newMemoryCapacity);
                    textBox3.Text = "";
                }

                if (radioButton4.Checked)
                {
                    string newVideoCard = MyException.isString(textBox4.Text, "поле тип видеокарты");
                    CompCollection.editField(localEditComp, "VideoCard", newVideoCard);
                    textBox4.Text = "";
                }

                if (radioButton5.Checked)
                {
                    string newVideoCapacity = MyException.isInteger(textBox5.Text, "поле объем видеопамяти").ToString();
                    CompCollection.editField(localEditComp, "VideoCapacity", newVideoCapacity);
                    textBox5.Text = "";
                }

                if (radioButton6.Checked)
                {
                    string newPowerUnit = MyException.isInteger(textBox6.Text, "поле мощность БП").ToString();
                    CompCollection.editField(localEditComp, "PowerUnit", newPowerUnit);
                    textBox6.Text = "";
                }

                if (radioButton7.Checked)
                {            
                    string newComputerCost = MyException.isInteger(textBox7.Text, "поле цена").ToString();
                    CompCollection.editField(localEditComp, "ComputerCost", newComputerCost);
                    textBox7.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CompAction createAct = new CompAction(localEditComp.ComputerID);
            createAct.Show();
        }

        private void EditComp_Load(object sender, EventArgs e)
        {
            CompCollection.printCompField += printCompFieldMessage;
            CompCollection.editComp += editCompMessage;
        }

        private void EditComp_VisibleChanged(object sender, EventArgs e)
        {
            CompCollection.editComp -= editCompMessage;
            CompCollection.printCompField -= printCompFieldMessage;
        }
    }
}
