using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace christiancabalbag
{
    public partial class ModifyParts : Form
    {
        Form1 MainWindow = (Form1)Application.OpenForms["MainWindow"];
        public ModifyParts(Inhouse inPart)
        {
            InitializeComponent();
            radioButton1.Checked = true;
            textBox1.ReadOnly = true;
            textBox1.Text = inPart.PartId.ToString();
            textBox2.Text = inPart.Name;
            textBox3.Text = inPart.InStock.ToString();
            textBox4.Text = inPart.Price.Substring(1).ToString();
            textBox5.Text = inPart.Max.ToString();
            textBox6.Text = inPart.Min.ToString();
            textBox7.Text = inPart.MachineID.ToString();
        }
        public ModifyParts(OutSourced outPart)
        {
            InitializeComponent();
            radioButton2.Checked = true;
            textBox1.ReadOnly = true;
            textBox1.Text = outPart.PartId.ToString();
            textBox2.Text = outPart.Name;
            textBox3.Text = outPart.InStock.ToString();
            textBox4.Text = outPart.Price.Substring(1).ToString();
            textBox5.Text = outPart.Max.ToString();
            textBox6.Text = outPart.Min.ToString();
            textBox7.Text = outPart.CompanyName;
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "Machine ID"; //radio  changes label to machineid
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "Company Name"; //radio changes to company name
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //save button
            int minstock;
            int maxstock;
            int instock;
            decimal price;

            int id = int.Parse(textBox1.Text);
            string name = textBox2.Text;
            instock = int.Parse(textBox3.Text);
            price = decimal.Parse(textBox4.Text);
            minstock = int.Parse(textBox6.Text);
            maxstock = int.Parse(textBox5.Text);

            if (minstock > maxstock)
            {
                MessageBox.Show("Min value cannot be more than Max.");
                return;
            }
            if (instock > maxstock || instock < minstock)
            {
                MessageBox.Show("Inventory cannot be more than Max and less than Min.");
                return;
            }
            if (radioButton1.Checked)
            {
                Inhouse inHouse = new Inhouse(id, name, instock, price, maxstock, minstock, int.Parse(textBox7.Text));                
                Inventory.updatePart(id, inHouse);  
            }

            else if (radioButton2.Checked) 
            {
                OutSourced outSourced = new OutSourced(id, name, instock, price, maxstock, minstock, textBox7.Text);               
                Inventory.updatePart(id, outSourced);                
            }
            Close();
        }

    }
}
