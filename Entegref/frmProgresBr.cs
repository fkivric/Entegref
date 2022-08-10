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
    public partial class frmProgresBr : DevExpress.XtraEditors.XtraForm
    {
        public frmProgresBr()
        {
            InitializeComponent();
            this.Start = 0;
            this.Finish = 100;
            this.Position = 0;
            prgProgress.Properties.Step = 1;
        }
        public int Start
        {
            get
            {
                return prgProgress.Properties.Minimum;
            }
            set
            {
                prgProgress.Properties.Minimum = value;
            }
        }

        public int Finish
        {
            get
            {
                return prgProgress.Properties.Maximum;
            }
            set
            {
                prgProgress.Properties.Maximum = value;
            }
        }

        public int Position
        {
            get
            {
                return prgProgress.Position;
            }
            set
            {
                prgProgress.Position = value;
            }
        }

        public void PerformStep(Form owner)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => PerformStep(owner)));
                return;
            }
            else if (owner.InvokeRequired)
            {
                owner.Invoke(new Action(() => PerformStep(owner)));
                return;
            }
            else
            {
                prgProgress.PerformStep();
                this.Refresh();
            }
        }

        public void Show(Form owner)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => Show(owner)));
                return;
            }
            else if (owner.InvokeRequired)
            {
                owner.Invoke(new Action(() => Show(owner)));
                return;
            }
            else
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(owner.Location.X + (owner.Width - this.Width) / 2, owner.Location.Y + (owner.Height - this.Height) / 2);
                base.Show(owner);
            }
        }

        public void Hide(Form owner)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => Hide(owner)));
                return;
            }
            else if (owner.InvokeRequired)
            {
                owner.Invoke(new Action(() => Hide(owner)));
                return;
            }
            else
            {
                base.Hide();
                this.Refresh();
            }
        }
    }
}