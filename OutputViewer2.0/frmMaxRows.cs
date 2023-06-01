using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutputViewer2._0
{
    public partial class frmMaxRows : Form
    {
        public frmMaxRows()
        {
            InitializeComponent();
        }

        private int? max = null;

        //GetMax gets the max # of rows to keep as an integer
        public int GetMax(int current)
        {
            //Show current max rows
            txtMax.Text = current.ToString();

            this.ShowDialog();

            if (this.max == null) { return Properties.Settings.Default.rowsToKeep; }
            else { return (int)this.max; }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMax.Text, out int value))
            {
                this.max = value;
                this.Close();
            }
            else
            {
                this.max = null;
                MessageBox.Show("Please enter the number of rows you'd like to keep", "Entry Error");
                txtMax.Focus();
                txtMax.SelectAll();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Close the form
            this.Close();
        }
    }
}
