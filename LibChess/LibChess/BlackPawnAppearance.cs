using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LibChess
{
    class BlackPawnAppearance : Appearance
    {
        public BlackPawnAppearance()
        {
            bitmap = GetImage("BP");
        }
    }
}
