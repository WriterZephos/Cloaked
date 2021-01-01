using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Clkd.Assets
{
    public class BasicRenderingStrategy : IDrawStrategy
    {
        public void Draw(Renderable renderable, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                renderable.Texture,
                new Rectangle(renderable.RenderableCoordinate.GetDrawX(),
                              renderable.RenderableCoordinate.GetDrawY(),
                              renderable.RenderableCoordinate.Width,
                              renderable.RenderableCoordinate.Height),
                new Rectangle(renderable.SpriteCoordinate.X,
                              renderable.SpriteCoordinate.Y,
                              renderable.SpriteCoordinate.Width,
                              renderable.SpriteCoordinate.Height),
                renderable.SpriteCoordinate.Color);
        }
    }
}