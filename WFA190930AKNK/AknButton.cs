using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA190930AKNK
{
    public class AknButton : Button
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Flag { get; set; } = false;
        public bool Akna { get; set; }
    }
}
