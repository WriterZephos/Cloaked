using Microsoft.Xna.Framework.Graphics;

namespace Clkd.Assets
{
    public class BasicBatchStrategy : IBatchStrategy
    {
        public void Begin(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(blendState: BlendState.AlphaBlend);
        }

        public void End(SpriteBatch spriteBatch)
        {
            spriteBatch.End();
        }
    }
}