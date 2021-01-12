using Microsoft.Xna.Framework.Graphics;

namespace Clkd.Assets
{
    public interface IDrawStrategy
    {
        void Draw(IRenderable renderable, SpriteBatch spriteBatch);
    }
}