using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LibChess
{
    class WhiteRookAppearance : Appearance
    {
        public WhiteRookAppearance()
        {
            bitmap = GetImage("WR");
        }
    }
}
