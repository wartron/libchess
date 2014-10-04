using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LibChess
{
    class WhiteBishopAppearance : Appearance
    {
        public WhiteBishopAppearance()
        {
            bitmap = GetImage("WB");
        }
    }
}
