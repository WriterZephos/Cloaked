using System;
using Clkd.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Clkd.Assets
{
    public class Renderable : IComparable<Renderable>
    {
        public RenderableCoordinate RenderableCoordinate { get; set; }

        public Texture2D Texture { get; set; }
        public SpriteCoordinate SpriteCoordinate { get; set; }

        // Constructor for creating a Renderable.
        // Position properties (X and Y) are optional, as they are likely dynamic.
        // textureName, width, and height are all required to render anything to the screen.
        public Renderable(SpriteCoordinate spriteCoordinate, RenderableCoordinate renderableCoordinate,
                                bool isOffset = true)
        {
            var texture = Cloaked.TextureManager.GetTexture(spriteCoordinate.TextureId);
            Initialize(texture, spriteCoordinate, renderableCoordinate);
        }

        public Renderable(Texture2D texture, SpriteCoordinate spriteCoordinate,
                                RenderableCoordinate renderableCoordinate)
        {
            Initialize(texture, spriteCoordinate, renderableCoordinate);
        }

        public void Initialize(Texture2D texture,
            SpriteCoordinate spriteCoordinate,
            RenderableCoordinate renderableCoordinate)
        {
            RenderableCoordinate = renderableCoordinate;
            Texture = texture;
            SpriteCoordinate = spriteCoordinate;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Texture,
                new Rectangle(RenderableCoordinate.GetDrawX(),
                              RenderableCoordinate.GetDrawY(),
                              RenderableCoordinate.Width,
                              RenderableCoordinate.Height),
                new Rectangle(SpriteCoordinate.X,
                              SpriteCoordinate.Y,
                              SpriteCoordinate.Width,
                              SpriteCoordinate.Height),
                SpriteCoordinate.Color);
        }

        public int CompareTo(Renderable other)
        {
            if (other == null) return 1;

            if (RenderableCoordinate.Z > other.RenderableCoordinate.Z) return 1;

            if (other.RenderableCoordinate.Z > RenderableCoordinate.Z) return -1;

            return SpriteCoordinate.TextureId.CompareTo(other.SpriteCoordinate.TextureId);
        }

    }
}
