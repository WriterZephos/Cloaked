using Microsoft.Xna.Framework;

namespace Clkd.Assets
{
    public struct RenderableCoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public int HalfWidth { get; private set; }
        public int HalfHeight { get; private set; }

        private int _width;
        public int Width
        {
            get => _width;
            set
            {
                _width = value;
                HalfWidth = value / 2;
            }
        }

        private int _height;
        public int Height
        {
            get => _height;
            set
            {
                _height = value;
                HalfHeight = value / 2;
            }
        }

        public bool IsOffset { get; set; }

        public RenderableCoordinate(int x, int y, int z, int width, int height, bool isOffset = false)
        {
            IsOffset = isOffset;
            X = x;
            Y = y;
            Z = z;
            _width = width;
            _height = height;
            HalfWidth = _width / 2;
            HalfHeight = _height / 2;
        }

        public int GetDrawX()
        {
            return IsOffset ? X - HalfWidth : X;
        }

        public int GetDrawY()
        {
            return IsOffset ? Y - HalfHeight : Y;
        }

        public Vector2 ToVector2()
        {
            return new Vector2(X, Y);
        }
    }
}
