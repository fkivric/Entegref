using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entegref
{
    public partial class frmFirma : XtraForm
    {
        public frmFirma()
        {
            InitializeComponent();
        }
        SqlConnectionObject conn = new SqlConnectionObject();
        private void frmFirma_Load(object sender, EventArgs e)
        {
            IL();
        }
        private void comboIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilce(comboIl.SelectedValue.ToString());
            txtAdresFull.Text = txtAdresFull.Text + comboIl.Text;
        }

        private void combosemt_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAdresFull.Text = combosemt.Text +"/"+ txtAdresFull.Text ;
        }

        private void ultraTextEditor5_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtAdresFull.Text = txtCadde.Text + " " + txtSokak.Text + " " + combosemt.Text + combosemt.Text + "/" + comboIl.Text;
        }

        private void ultraTextEditor6_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtAdresFull.Text = txtCadde.Text + " " + txtSokak.Text + " " + txtBina.Text + " " + combosemt.Text + combosemt.Text + "/" + comboIl.Text;
        }

        private void ultraTextEditor7_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        void IL()
        {
            comboIl.DisplayMember = "İl";
            comboIl.ValueMember = "sira";
            var dt = conn.Query1("İl");
            comboIl.DataSource = dt;
        }
        void ilce(string _semt)
        {
            combosemt.DisplayMember = "Semt";
            combosemt.ValueMember = "sira";
            Dictionary<string, string> Semt = new Dictionary<string, string>();
            Semt.Add("@ilid", _semt);
            var dt = conn.Query("semt", Semt);
            combosemt.DataSource = dt;

        }
    }
}
