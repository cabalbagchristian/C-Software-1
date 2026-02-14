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
            var part1 = new BindingSource(); //do i even need this part
            part1.DataSource = Inventory.AllParts; //this shows and populate grid
            dgvParts.DataSource = Inventory.AllParts;
            dgvParts.ReadOnly = true; //add product grid readonly !!!!!

            var prod1 = new BindingSource();
            prod1.DataSource = Inventory.Products;
            dgvProducts.DataSource = Inventory.Products;
            dgvProducts.ReadOnly = true;
            Inventory.exampleLists(); //calls example list
            
        }
         //click event start add,modify, cancel
        private void button3_MouseClick(object sender, MouseEventArgs e)
        {            
            new AddParts().ShowDialog(); //don't use hide();           
        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
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
            new ModifyProducts().ShowDialog();            
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
        private void button8_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null || !dgvProducts.CurrentRow.Selected)
            {
                MessageBox.Show("Nothing is Selected, Please make a selection");
                return;
            }
            DialogResult dialogResultPart = MessageBox.Show("Do you want to permantly remove this part?", "Delete?", MessageBoxButtons.YesNo);
            if (dialogResultPart == DialogResult.Yes)
            {
                Product p = dgvProducts.CurrentRow.DataBoundItem as Product;
                int Index = dgvProducts.CurrentCell.RowIndex; // leave this just in case i need it
                Inventory.Products.Remove(p);
            }
            else
            {
                return;
            }




        }



        // testing zone**********************


        //testing zone*************************

    }
}
