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
        }
        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            AddParts addParts = new AddParts();
            addParts.Show();
        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            AddProducts addProducts = new AddProducts();
            addProducts.Show();
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            ModifyParts modifyParts = new ModifyParts();
            modifyParts.Show();
        }

        private void button7_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
