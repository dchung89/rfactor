using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics.CodeAnalysis;

namespace rfactor
{
    [ExcludeFromCodeCoverage]
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

        private void textBoxNewName_TextChanged(object sender, EventArgs e)
        {
            // this.Text = textBoxNewName.Text;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            buttonOk.Enabled = false;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonCancel.Enabled = false;
            this.Close();
        }

        private void labelNewName_Click(object sender, EventArgs e)
        {

        }
    }
}
