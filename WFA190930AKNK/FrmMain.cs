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
    public partial class FrmMain : Form
    {
        static Random rnd = new Random();

        public int palyaX;
        public int palyaY;

        AknButton[,] palya;

        public FrmMain()
        {
            InitializeComponent();

            var meretAblak = new FrmMeret(this);
            meretAblak.ShowDialog();
            //MessageBox.Show($"palya: [{palyaX};{palyaY}]");
            SetPalya();
        }

        private void SetPalya()
        {
            palya = new AknButton[palyaX, palyaY];

            for (int s = 0; s < palya.GetLength(0); s++)
            {
                for (int o = 0; o < palya.GetLength(1); o++)
                {
                    palya[s, o] = new AknButton();
                    palya[s, o].SetBounds(o * 50, s * 50, 50, 50);
                    palya[s, o].Akna = rnd.Next(100) < 25;
                    palya[s, o].Click += AknClick;

                    palya[s, o].X = s;
                    palya[s, o].Y = o;

                    palya[s, o].Text = $"[{s};{o}]";

                    this.Controls.Add(palya[s, o]);
                }
            }
        }

        private void AknClick(object sender, EventArgs e)
        {
            if((sender as AknButton).Akna)
            {
                (sender as AknButton).BackColor = Color.Red;
            }
            else
            {
                (sender as AknButton).BackColor = Color.Green;
            }
        }
    }
}
