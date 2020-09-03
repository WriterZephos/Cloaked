using Microsoft.Xna.Framework;

namespace Clkd.Assets
{
    public struct SpriteCoordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string TextureId { get; set; }
        public Color Color { get; set; }

        public SpriteCoordinate(string textureId, int x, int y, int width, int height, Color? color = null)
        {
            TextureId = textureId;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Color = color ?? Color.White;
        }
    }
}
