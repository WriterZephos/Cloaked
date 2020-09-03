using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clkd.Main
{
    public class Camera2D
    {
        public Rectangle ViewRectangle { get; set; }
        public int OriginX { get; set; }
        public int OriginY { get; set; }

        public Camera2D()
        {
            ViewRectangle = new Rectangle(0, 0, 500, 500);
        }
    }
}
