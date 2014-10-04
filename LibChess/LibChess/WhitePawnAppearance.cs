using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LibChess
{
    class WhitePawnAppearance : Appearance
    {
        public WhitePawnAppearance()
        {
            bitmap = GetImage("WP");
        }
    }
}
