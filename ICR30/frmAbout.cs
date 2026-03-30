using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICR30
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            this.Text = "About IC-R30 PC Remote Version " + Application.ProductVersion;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            lblProductName.Text = Application.ProductName;
            lblVersion.Text = "Version " + Application.ProductVersion;
            lblAuthor.Text = "Author: Chis Anderson <canderson@foxtwo.net>";
            lblLicense.Text = "This is free software, do whatever you want with it.";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
