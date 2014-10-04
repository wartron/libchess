using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LibChess
{
    class WhiteKingAppearance : Appearance
    {
        public WhiteKingAppearance()
        {
            bitmap = GetImage("WK");
        }
    }
}
