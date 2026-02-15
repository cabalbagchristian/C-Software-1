using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace christiancabalbag
{
    public partial class AddProducts : Form
    {
        BindingList<Part> assocGrid = new BindingList<Part>();        
        public AddProducts()
        {
            InitializeComponent();
            var top = new BindingSource();
            top.DataSource = Inventory.AllParts;
            dgvAddProductPart.DataSource = top;

            var bottom = new BindingSource();
            bottom.DataSource = assocGrid;
            dgvAddProductAssoc.DataSource = bottom;
        }

        private void button4_Click(object sender, EventArgs e) //cancel button
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e) //save button
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
            maxStock = int.Parse(maxTextBox.Text);
            minStock = int.Parse(minTextBox.Text);
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Name must not be empty");
                return;
            }
            if (dgvAddProductAssoc.CurrentRow == null)
            {
                MessageBox.Show("Please add a part");
                return;
            }
            if (minStock > maxStock)
            {
                MessageBox.Show("Max stock must not be less than Min stock");
                return;
            }
            if (inventoryStock > maxStock || inventoryStock < minStock)
            {
                MessageBox.Show("Inventory must be between Max and Min stock");
                return;
            }
            Product prod = new Product((Inventory.AllParts.Count + 1), name, inventoryStock, price, minStock, maxStock);
            Inventory.addProduct(prod);
            foreach (Part part in assocGrid)
            {
                prod.addAssociatedPart(part);
            }

            Close();
        }

        private void button3_Click(object sender, EventArgs e) //delete items in bottom
        {
            if (dgvAddProductAssoc.CurrentRow == null || !dgvAddProductAssoc.CurrentRow.Selected)
            {
                MessageBox.Show("Please select an Associated Part");
                return;
            }
            //message box confirmation yes and no
            DialogResult dialogResultPart = MessageBox.Show("Do you want to permantly remove this part?", "Delete?", MessageBoxButtons.YesNo);
            if (dialogResultPart == DialogResult.Yes)
            {
                Part S = dgvAddProductAssoc.CurrentRow.DataBoundItem as Part;                
                assocGrid.Remove(S);
            }
            else
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e) //add top to bottom
        {
            if (dgvAddProductPart.CurrentRow == null || !dgvAddProductPart.CurrentRow.Selected)
            {
                MessageBox.Show("Please select a Part");
                return;
            }
            Part addToBottom = (Part)dgvAddProductPart.CurrentRow.DataBoundItem;
            assocGrid.Add(addToBottom);
        }
    }
}
