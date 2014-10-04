using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LibChess
{
    class WhiteQueenAppearance : Appearance
    {
        public WhiteQueenAppearance()
        {
            bitmap = GetImage("WQ");
        }
    }
}
