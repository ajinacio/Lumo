using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LumoForm
{
    public partial class FrmSplash : Form
    {
        public FrmSplash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();

            frm.Show();
            this.Visible = false;
            timer1.Enabled =  false;
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
