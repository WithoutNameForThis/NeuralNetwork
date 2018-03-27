using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 神经网络
{
    public partial class frm_pro : Form
    {
        NNOT _NNOT;
        public frm_pro(NNOT nnot)
        {
            InitializeComponent();
            _NNOT = nnot;


        }

        private void frm_pro_Load(object sender, EventArgs e)
        {
            tim_keeper.Enabled = true;
        }

        private void tim_keeper_Tick(object sender, EventArgs e)
        {
            pro_pro.Maximum = _NNOT.max;
            pro_pro.Value = _NNOT.pro;

        }
    }
}
