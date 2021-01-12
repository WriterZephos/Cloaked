using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Clkd.Main;
using Microsoft.Xna.Framework.Graphics;

namespace Clkd.Assets
{
    public class Sprite : AbstractRenderableComponent
    {
        public SpriteCoordinate SpriteCoordinate { get; set; }

        public Sprite(SpriteCoordinate spriteCoordinate)
        {
            SpriteCoordinate = spriteCoordinate;
        }

        public Sprite(string textureId, int x, int y, int width, int height) : this(new SpriteCoordinate(textureId, x, y, width, height)) { }

        public Sprite(Texture2D texture, int x, int y, int width, int height) : this(new SpriteCoordinate(texture, x, y, width, height)) { }

        public Sprite(Color color)
        {
            SpriteCoordinate = new SpriteCoordinate("generic_white", 0, 0, 100, 100, color);
        }

        public override List<IRenderable> GetRenderables(RenderableCoordinate? renderableCoordinate = null)
        {
            return renderableCoordinate.HasValue ?
                new List<IRenderable>() { new Renderable2D(SpriteCoordinate, renderableCoordinate.Value, IsOffset, DrawStrategy, BatchStrategy, RenderTargetStrategy) } : null;
        }
    }
}
