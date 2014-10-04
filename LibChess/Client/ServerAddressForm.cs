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
    public partial class ServerAddressForm : Form
    {
        public ServerAddressForm()
        {
            InitializeComponent();
            AcceptButton = ServerAddressOK;
        }

        private void ServerAddressOk_Click(object sender, EventArgs e)
        {
            if (this.Text.Trim().Length > 0) this.Hide();
        }

        private void ServerAddressForm_Load(object sender, EventArgs e)
        {

        }
    }
}
