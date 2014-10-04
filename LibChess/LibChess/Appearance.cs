using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;

namespace LibChess
{
    public abstract class Appearance
    {
        protected static string path;
        Assembly assembly;

        public Appearance()
        {
            assembly = Assembly.GetExecutingAssembly();
        }

        protected Bitmap bitmap;

        public Bitmap Image
        {
            get { return bitmap; }
        }

        protected Bitmap GetImage(string Piece)
        {
            return new Bitmap(assembly.GetManifestResourceStream("LibChess.Resources." + Piece + ".png"));
        }
    }
}
