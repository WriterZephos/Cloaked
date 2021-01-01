using Clkd.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Clkd.Assets
{
    public struct SpriteCoordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        private Texture2D _texture;
        public Texture2D Texture
        {
            get
            {
                if (_texture != null)
                {
                    return _texture;
                }
                else
                {
                    return Cloaked.TextureManager.GetTexture(TextureId);
                }
            }
        }
        public string TextureId { get; set; }
        public Color Color { get; set; }

        public SpriteCoordinate(string textureId, int x, int y, int width, int height, Color? color = null)
        {
            _texture = null;
            TextureId = textureId;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Color = color ?? Color.White;
        }

        public SpriteCoordinate(Texture2D texture, int x, int y, int width, int height, Color? color = null)
        {
            _texture = texture;
            TextureId = null;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Color = color ?? Color.White;
        }
    }
}
