using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Clkd.Assets
{
    public class Renderable2DDrawStrategy : IDrawStrategy
    {
        public void Draw(IRenderable renderable, SpriteBatch spriteBatch)
        {
            if (renderable is Renderable2D r)
            {
                spriteBatch.Draw(
                    r.Texture,
                    new Rectangle(r.RenderableCoordinate.GetDrawX(),
                                r.RenderableCoordinate.GetDrawY(),
                                r.RenderableCoordinate.Width,
                                r.RenderableCoordinate.Height),
                    new Rectangle(r.SpriteCoordinate.X,
                                r.SpriteCoordinate.Y,
                                r.SpriteCoordinate.Width,
                                r.SpriteCoordinate.Height),
                    r.SpriteCoordinate.Color);
            }
            else
            {
                throw new ArgumentException("Renderable2DRenderingStrategy only supports Renderable2D types, but another type was passed to Draw().");
            }

        }
    }
}