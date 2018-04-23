using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinqServerModeSource
{
    public partial class EditForm : Form
    {
        public EditForm(Customer customer)
        {
            InitializeComponent();
            textEdit1.DataBindings.Add("EditValue", customer, "CompanyName");
            textEdit2.DataBindings.Add("EditValue", customer, "ContactName");
            textEdit3.DataBindings.Add("EditValue", customer, "Address");
            textEdit4.DataBindings.Add("EditValue", customer, "Country");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

    }
}
