using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LibChess
{
    class WhiteKnightAppearance : Appearance
    {
        public WhiteKnightAppearance()
        {
            bitmap = GetImage("WH");
        }
    }
}
