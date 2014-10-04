using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LibChess
{
    class BlackBishopAppearance : Appearance
    {
        public BlackBishopAppearance()
        {
            bitmap = GetImage("BB");
        }
    }
}
