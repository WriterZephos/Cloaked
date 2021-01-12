using Microsoft.Xna.Framework.Graphics;

namespace Clkd.Assets
{
    public interface IBatchStrategy
    {
        void Begin(SpriteBatch spriteBatch);
        void End(SpriteBatch spriteBatch);
    }
}