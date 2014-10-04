using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LibChess
{
    class BlackKnightAppearance : Appearance
    {
        public BlackKnightAppearance()
        {
            bitmap = GetImage("BH");
        }
    }
}
