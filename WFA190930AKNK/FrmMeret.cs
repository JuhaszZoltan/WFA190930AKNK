using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA190930AKNK
{
    public partial class FrmMeret : Form
    {
        FrmMain fm;
        public FrmMeret(FrmMain mainForm)
        {
            InitializeComponent();
            fm = mainForm;
        }

        private void FrmMeret_FormClosing(object sender, FormClosingEventArgs e)
        {
            fm.palyaX = int.Parse(tbX.Text);
            fm.palyaY = int.Parse(tbY.Text);
        }
    }
}
