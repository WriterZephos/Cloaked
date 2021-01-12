using System;
using Clkd.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Clkd.Assets
{
    public class Renderable2D : IRenderable
    {
        public RenderableCoordinate RenderableCoordinate { get; set; }
        public Texture2D Texture { get; set; }
        public SpriteCoordinate SpriteCoordinate { get; set; }
        public string DrawStrategy { get; set; }
        public string BatchStrategy { get; set; }
        public string RenderTargetStrategy { get; set; }

        // Constructor for creating a Renderable.
        // Position properties (X and Y) are optional, as they are likely dynamic.
        // textureName, width, and height are all required to render anything to the screen.
        public Renderable2D(
            SpriteCoordinate spriteCoordinate,
            RenderableCoordinate renderableCoordinate,
            bool isOffset = false,
            string drawStrategy = "basic",
            string batchStrategy = "basic",
            string renderTargetStrategy = "basic")
        {
            Initialize(spriteCoordinate, renderableCoordinate, drawStrategy, batchStrategy, renderTargetStrategy);
        }

        private void Initialize(
            SpriteCoordinate spriteCoordinate,
            RenderableCoordinate renderableCoordinate,
            string drawStrategy,
            string batchStrategy,
            string renderTargetStrategy)
        {
            RenderableCoordinate = renderableCoordinate;
            Texture = spriteCoordinate.Texture;
            SpriteCoordinate = spriteCoordinate;
            DrawStrategy = drawStrategy;
            BatchStrategy = batchStrategy;
            RenderTargetStrategy = renderTargetStrategy;
        }

        public int CompareTo(IRenderable other)
        {
            if (other == null) return 1;

            // This Renderable will follow the other in rendering order, so lower 
            // z values are renderd first.
            if (RenderableCoordinate.Z > other.RenderableCoordinate.Z) return 1;

            // This Renderable will go before the other in rendering order, so lower 
            // z values are renderd first.
            if (RenderableCoordinate.Z < other.RenderableCoordinate.Z) return -1;

            if (other is Renderable2D renderable)
            {
                // Render them in the order they are gathered.
                if (SpriteCoordinate.TextureId == null || renderable?.SpriteCoordinate.TextureId == null) return -1;

                // The two Renderables will be sorted by their TextureIds.
                return SpriteCoordinate.TextureId.CompareTo(renderable.SpriteCoordinate.TextureId);
            }
            else
            {
                return -1;
            }
        }
    }
}
