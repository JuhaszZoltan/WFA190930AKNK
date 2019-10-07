using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFA190930AKNK.Properties;

namespace WFA190930AKNK
{
    public partial class FrmMain : Form
    {
        static Random rnd = new Random();

        static Color[] szinek =
        {
            Color.White,
            Color.Blue,
            Color.Green,
            Color.Red,
            Color.Indigo,
            Color.Brown,
            Color.Cyan,
            Color.Purple,
            Color.Black
        };

        bool elso = true;

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
                    palya[s, o].Akna = rnd.Next(100) < 10;
                    //palya[s, o].Click += AknClick;
                    palya[s, o].MouseUp += AknMouseClick;

                    palya[s, o].ImageAlign = ContentAlignment.MiddleCenter;
                    palya[s, o].BackgroundImageLayout = ImageLayout.Stretch;

                    palya[s, o].Font = new Font("Consolas", 20F, FontStyle.Bold);

                    palya[s, o].X = s;
                    palya[s, o].Y = o;

                    this.Controls.Add(palya[s, o]);
                }
            }
        }

        private void AknMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                (sender as AknButton).BackgroundImage = Resources.zaszlo;
            }
            else
            {
                if (elso && (sender as AknButton).Akna)
                {
                    int x, y;
                    do
                    {
                        x = rnd.Next(palyaX);
                        y = rnd.Next(palyaY);
                    } while (!palya[x, y].Akna);

                    palya[x, y].Akna = true;
                    (sender as AknButton).Akna = false;
                }
                elso = false;

                (sender as AknButton).BackColor = Color.White;
                (sender as AknButton).Flag = true;

                if ((sender as AknButton).Akna)
                {
                    (sender as AknButton).BackgroundImage = Resources.akna;
                }
                else
                {
                    int korbeDb = Vizsgal(sender as AknButton, e);

                    if (korbeDb != 0) (sender as AknButton).Text = korbeDb + "";
                }
            }

            if (IsWin())
            {
                MessageBox.Show("NYERTÉL!");
                Application.Restart();
            }
        }

        private bool IsWin()
        {
            for (int s = 0; s < palya.GetLength(0); s++)
            {
                for (int o = 0; o < palya.GetLength(1); o++)
                {
                    if (palya[s, o].Akna && palya[s, o].BackgroundImage != Resources.zaszlo) return false;
                }
            }
            return true;
        }

        private int Vizsgal(AknButton btn, MouseEventArgs e)
        {
            int dbAkn = 0;
            var kattintani = new List<AknButton>();

            for (int s = btn.X - 1; s <= btn.X + 1; s++)
            {
                for (int o = btn.Y - 1; o <= btn.Y + 1; o++)
                {
                    if (o >= 0 && s >= 0 && s < palyaX && o < palyaY)
                    {
                        if(palya[s, o].Akna) dbAkn++;
                        else if (!palya[s, o].Flag)
                        {
                            kattintani.Add(palya[s, o]);
                        }
                    }
                }
            }

            if (dbAkn == 0)
            {
                foreach (var b in kattintani)
                {
                    AknMouseClick(b, e);
                }
            }

            btn.ForeColor = szinek[dbAkn];

            return dbAkn;
        }
    }
}
