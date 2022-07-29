using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lisansing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            SKGL.Generate generate = new SKGL.Generate();
            generate.secretPhase = txtPassword.Text;
            txtSerial.Text = generate.doKey(Convert.ToInt32(txtDay.Text));
        }

        private void btnValid_Click(object sender, EventArgs e)
        {
            SKGL.Validate validate = new SKGL.Validate();
            validate.secretPhase = txtPassword.Text;
            validate.Key = txtSerial.Text;
            txtStatus.Text = "Creation date:"+validate.CreationDate+"\r\n"+ "ExpireDate date:" + validate.ExpireDate + "\r\n"+"Day Left:" + validate.DaysLeft;
        }
    }
}
