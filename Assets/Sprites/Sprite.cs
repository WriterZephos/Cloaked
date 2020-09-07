using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Clkd.Main;

namespace Clkd.Assets
{
    public class Sprite : AbstractComponent
    {
        public SpriteCoordinate SpriteCoordinate { get; set; }

        public Sprite(SpriteCoordinate spriteCoordinate) : base(canGetRenderables: true)
        {
            SpriteCoordinate = spriteCoordinate;
        }

        public Sprite(string textureId, int x, int y, int width, int height) : this(new SpriteCoordinate(textureId, x, y, width, height)) { }

        public Sprite(Color color) : base(canGetRenderables: true)
        {
            SpriteCoordinate = new SpriteCoordinate("generic_white", 0, 0, 100, 100, color);
        }

        public override List<Renderable> GetRenderables(RenderableCoordinate? renderableCoordinate = null)
        {
            return renderableCoordinate.HasValue ?
                new List<Renderable>() { new Renderable(SpriteCoordinate, renderableCoordinate.Value) } : null;
        }

    }
}
