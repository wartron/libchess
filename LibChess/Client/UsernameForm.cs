using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class UsernameForm : Form
    {
        public UsernameForm()
        {
            InitializeComponent();
            AcceptButton = UsernameOK;
        }

        private void usernameOk_Click(object sender, EventArgs e)
        {
            if(this.Text.Trim().Length > 0) this.Hide();
        }

        private void UsernameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
