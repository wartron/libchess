﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LibChess
{
    class BlackKingAppearance : Appearance
    {
        public BlackKingAppearance()
        {
            bitmap = GetImage("BK");
        }
    }
}
