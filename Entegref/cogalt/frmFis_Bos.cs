using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Entegref
{
    public partial class frmFis_Bos : DevExpress.XtraEditors.XtraForm
    {
        SqlConnectionObject conn = new SqlConnectionObject();
        public frmFis_Bos()
        {
            InitializeComponent();
        }

        private void frmTransferFisi_Load(object sender, EventArgs e)
        {
        }

        private void btnCikandepo_Click(object sender, EventArgs e)
        {

        }

        private void btnGirendepo_Click(object sender, EventArgs e)
        {

        }

        private void btnTamamlanmamis_Click(object sender, EventArgs e)
        {

        }

        private void btnFisno_Click(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtCikandepo.Text != null && txtCikandepo.Text != "")
            {

            }
            else if (txtGirendepo.Text != null && txtGirendepo.Text != "")
            {

            }
            else if (txtFisNo .Text!= null && txtFisNo.Text != "")
            {

            }
        }
    }
}