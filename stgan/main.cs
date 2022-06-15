using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace stgan
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            CODING c = new CODING();
            c.ShowDialog();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            DECODING d = new DECODING();
            d.ShowDialog();
        }
    }
}
