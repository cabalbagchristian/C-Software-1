using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace christiancabalbag
{
    public partial class ModifyProducts : Form
    {
        BindingList<Part> assocGrid = new BindingList<Part>();
        public ModifyProducts(Product prod)
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
            textBox1.Text = prod.ProductId.ToString();
            textBox2.Text = prod.Name;
            textBox3.Text = prod.InStock.ToString();
            textBox4.Text = prod.Price.Substring(1).ToString();
            maxTextBox.Text = prod.Max.ToString();
            minTextBox.Text = prod.Min.ToString();
            
            var top = new BindingSource();
            top.DataSource = Inventory.AllParts;
            dgvModifyProductPart.DataSource = top;

            var bottom = new BindingSource();
            bottom.DataSource = assocGrid;
            dgvModifyProductAssoc.DataSource = bottom;            
            dgvModifyProductPart.ReadOnly = true;
            Inventory.exampleLists();

            foreach (Part part in prod.AssociatedParts) //test this first
            {
                assocGrid.Add(part);
            }

        }        

        private void button4_Click(object sender, EventArgs e) //cancel
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e) //delete
        {
            if (dgvModifyProductAssoc.CurrentRow == null || !dgvModifyProductAssoc.CurrentRow.Selected)
            {
                MessageBox.Show("Please select an Associated Part");
                return;
            }
            //message box confirmation yes and no
            DialogResult dialogResultPart = MessageBox.Show("Do you want to permantly remove this part?", "Delete?", MessageBoxButtons.YesNo);
            if (dialogResultPart == DialogResult.Yes)
            {
                Part S = dgvModifyProductAssoc.CurrentRow.DataBoundItem as Part;
                assocGrid.Remove(S);
            }
            else
            {
                return;
            }
        }
        private void button5_Click(object sender, EventArgs e) //save
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
            int id = int.Parse(textBox1.Text);
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
            if (dgvModifyProductPart.CurrentRow == null)
            {
                MessageBox.Show("Please add a part");
                return;
            }
            Product prod = new Product((Inventory.AllParts.Count + 1), name, inventoryStock, price, minStock, maxStock);
           
            foreach (Part part in assocGrid)
            {
                prod.addAssociatedPart(part);
            }
            Inventory.updateProduct(id, prod);
            Close();

        }
        private void button2_Click(object sender, EventArgs e) //add button
        {
            if (dgvModifyProductPart.CurrentRow == null || !dgvModifyProductPart.CurrentRow.Selected)
            {
                MessageBox.Show("Please select a Part");
                return;
            }
            Part addToBottom = (Part)dgvModifyProductPart.CurrentRow.DataBoundItem;
            assocGrid.Add(addToBottom);
        }
        private void button1_Click(object sender, EventArgs e) //search
        {
            if (textBox7.Text.Length < 1)
                return;
            string textBox = textBox7.Text.ToUpper();
            foreach (DataGridViewRow row in dgvModifyProductPart.Rows)
            {
                string value1 = row.Cells["Partid"].Value.ToString().ToUpper();
                string value2 = row.Cells["Name"].Value.ToString().ToUpper();
                if (value1.Contains(textBox) || (value2.Contains(textBox)))
                {
                    row.Selected = true;
                    break;
                }
                else
                {
                    row.Selected = false;
                }
            }
        
        }

        //random label
        private void label8_Click(object sender, EventArgs e)
        {

        }

        
    }
}
