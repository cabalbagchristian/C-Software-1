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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var part1 = new BindingSource(); 
            part1.DataSource = Inventory.AllParts; //this shows and populate grid
            dgvParts.DataSource = Inventory.AllParts;
            dgvParts.ReadOnly = true; //add product grid readonly !!!!!

            var prod1 = new BindingSource();
            prod1.DataSource = Inventory.Products;
            dgvProducts.DataSource = Inventory.Products;
            dgvProducts.ReadOnly = true;
            Inventory.exampleLists(); //calls example list
            Inventory.exampleLists2();

        }
         //click event start add,modify, cancel
        private void button3_MouseClick(object sender, MouseEventArgs e) //addPart
        {            
            new AddParts().ShowDialog(); //don't use hide();           
        }

        private void button6_MouseClick(object sender, MouseEventArgs e) //addproduct
        {            
            new AddProducts().ShowDialog();
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (dgvParts.CurrentRow == null || dgvParts.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an item.");
                    return;
                }
                if (dgvParts.CurrentRow.DataBoundItem.GetType() == typeof(Inhouse))
                {
                    Inhouse inPart = (Inhouse)dgvParts.CurrentRow.DataBoundItem;
                    new ModifyParts(inPart).ShowDialog();
                }
                else
                {
                    OutSourced outPart = (OutSourced)dgvParts.CurrentRow.DataBoundItem;
                    new ModifyParts(outPart).ShowDialog();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select an item.");
            }            
        }
        private void button7_MouseClick(object sender, MouseEventArgs e)
        {                
            if (dgvProducts.CurrentRow == null || dgvProducts.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an item.");
                    return;
                }
            Product newprod = (Product)dgvProducts.CurrentRow.DataBoundItem;
            new ModifyProducts(newprod).ShowDialog();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void myBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvParts.ClearSelection();
        }

        private void myBindingComplete2(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProducts.ClearSelection(); //add clearselection
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //check for selection
            if (dgvParts.CurrentRow == null || !dgvParts.CurrentRow.Selected)
            {
                MessageBox.Show("Nothing is Selected, Please make a selection");
                return;
            }
            //message box confirmation yes and no
            DialogResult dialogResultPart = MessageBox.Show("Do you want to permantly remove this part?", "Delete?", MessageBoxButtons.YesNo);
            if (dialogResultPart == DialogResult.Yes)
            {
                Part S = dgvParts.CurrentRow.DataBoundItem as Part;
                int Index = dgvParts.CurrentCell.RowIndex; // leave this just in case i need it
                Inventory.AllParts.Remove(S);
            }
            else 
            {
                return;
            }
        }
        private void button8_Click(object sender, EventArgs e) //delete product
        {
            if (dgvProducts.CurrentRow == null || !dgvProducts.CurrentRow.Selected)
            {
                MessageBox.Show("Nothing is Selected, Please make a selection");
                return;
            }
            Product p = dgvProducts.CurrentRow.DataBoundItem as Product;

            if (p.AssociatedParts.Count > 0)
            {
                MessageBox.Show("Cannot delete product unless associated parts are removed. Please remove associated parts first");
                return;
            }
            DialogResult dialogResultPart = MessageBox.Show("Do you want to permantly remove this part?", "Delete?", MessageBoxButtons.YesNo);
            if (dialogResultPart == DialogResult.Yes)
            {
                int Index = dgvProducts.CurrentCell.RowIndex; // leave this just in case i need it
                Inventory.Products.Remove(p);
                
            }
            else
            {
                return;
            }
        }
                 
        private void button1_Click(object sender, EventArgs e) //search
        {
            if (textBox1.Text.Length < 1)
            return;
            string textBox = textBox1.Text.ToUpper();
            foreach (DataGridViewRow row in dgvParts.Rows)
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
        private void button2_Click(object sender, EventArgs e) //search2
        {
            if (textBox2.Text.Length < 1)
                return;
            string textBox2a = textBox2.Text.ToUpper();
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                string value1 = row.Cells["Productid"].Value.ToString().ToUpper();
                string value2 = row.Cells["Name"].Value.ToString().ToUpper();
                if (value1.Contains(textBox2a) || (value2.Contains(textBox2a)))
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



        // testing zone**********************


        //testing zone*************************

    }
}
