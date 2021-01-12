using System;
using Microsoft.Xna.Framework.Graphics;

namespace Clkd.Assets
{
    public class StringRenderableDrawStrategy : IDrawStrategy
    {
        public void Draw(IRenderable renderable, SpriteBatch spriteBatch)
        {
            if (renderable is StringRenderable r)
            {
                spriteBatch.DrawString(r.SpriteFont, r.Text, r.RenderableCoordinate.ToVector2(), r.Color);
            }
            else
            {
                throw new ArgumentException("StringRenderableDrawStrategy only supports StringRenderable types, but another type was passed to Draw().");
            }

        }
    }
}