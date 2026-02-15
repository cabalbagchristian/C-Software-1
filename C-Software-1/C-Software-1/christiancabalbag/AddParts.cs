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
    public partial class AddParts : Form
    {
        public AddParts()
        {
            InitializeComponent();
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close(); //cancel button            
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "Machine ID"; //radio inhouse changes label to machineid            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "Company Name"; //radio outsource to company name
        }

        private void button1_Click(object sender, EventArgs e) //save button
        {            
            int minStock;
            int maxStock;
            int inventoryStock;
            decimal price;

            try
            {                
                minStock = int.Parse(minTextBox.Text);
                maxStock = int.Parse(maxTextBox.Text);
                inventoryStock = int.Parse(textBox3.Text);
                price = decimal.Parse(textBox4.Text);
            }
            catch
            {
                MessageBox.Show("Please enter numeric values for Min, Max, Inventory and Price");                
                return;
            }
            
            string name = textBox2.Text;
            inventoryStock = int.Parse(textBox3.Text);
            price = decimal.Parse(textBox4.Text);
            maxStock =int.Parse(maxTextBox.Text);
            minStock = int.Parse(minTextBox.Text);
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Name must not be empty");
                return;
            }
            if (string.IsNullOrEmpty(textBox7.Text) && (radioButton1.Checked) )
            {
                MessageBox.Show("Machine ID must not be empty");
                return;
            }
            if (radioButton1.Checked && int.TryParse(textBox7.Text, out _) == false )
            {
                MessageBox.Show("Machine ID must be numeric values");
                return; 
            }
    
            if  (minStock > maxStock)
            {
                MessageBox.Show("Max stock must not be less than Min stock");
                return;
            }
            if (inventoryStock > maxStock || inventoryStock < minStock)
            {
                MessageBox.Show("Inventory must be between Max and Min stock");
                return;
            }

            if (radioButton1.Checked)
            {
                int machineID = int.Parse(textBox7.Text);
                Inhouse inPart = new Inhouse((Inventory.AllParts.Count + 1), name, inventoryStock, price, maxStock, minStock, machineID);
                Inventory.addPart(inPart);

            }
            else if (radioButton2.Checked) 
            {
                string company = textBox7.Text;
                OutSourced outPart = new OutSourced((Inventory.AllParts.Count + 1), name, inventoryStock, price, maxStock, minStock, company);
                Inventory.addPart(outPart);
            }
 
             
                Close();
        }
    }
}
