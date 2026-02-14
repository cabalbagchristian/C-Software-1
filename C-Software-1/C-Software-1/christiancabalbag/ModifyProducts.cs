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
    public partial class ModifyProducts : Form
    {
        public ModifyProducts()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) //cancel
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e) //delete
        {
            //if (dgvProducts.CurrentRow == null || !dgvProducts.CurrentRow.Selected)
            //{
            //    MessageBox.Show("Nothing is Selected, Please make a selection");
            //    return;
            //}
            //DialogResult dialogResultPart = MessageBox.Show("Do you want to permantly remove this part?", "Delete?", MessageBoxButtons.YesNo);
            //if (dialogResultPart == DialogResult.Yes)
            //{
            //    Product p = dgvProducts.CurrentRow.DataBoundItem as Product;
            //    int Index = dgvProducts.CurrentCell.RowIndex; // leave this just in case i need it
            //    Inventory.Products.Remove(p);
            //}
            //else
            //{
            //    return;
            //}
        }
    }
}
