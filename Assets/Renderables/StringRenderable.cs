using Clkd.Assets;
using Clkd.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Clkd.Assets
{
    public class StringRenderable : IRenderable
    {
        public RenderableCoordinate RenderableCoordinate { get; set; }
        public SpriteFont SpriteFont { get; set; }
        public string DrawStrategy { get; set; }
        public string BatchStrategy { get; set; }
        public string RenderTargetStrategy { get; set; }
        public string Text { get; set; }
        public Color Color { get; set; }

        public StringRenderable(
            string text,
            string spriteFontID,
            Color color,
            RenderableCoordinate renderableCoordinate,
            string drawStrategy = "string",
            string batchStrategy = "basic",
            string renderTargetStrategy = "basic")
        {
            Initialize(text, spriteFontID, color, renderableCoordinate, drawStrategy, batchStrategy, renderTargetStrategy);
        }

        private void Initialize(
            string text,
            string spriteFontID,
            Color color,
            RenderableCoordinate renderableCoordinate,
            string drawStrategy,
            string batchStrategy,
            string renderTargetStrategy)
        {
            Text = text;
            SpriteFont = Cloaked.TextureManager.GetSpriteFont(spriteFontID);
            Color = color;
            RenderableCoordinate = renderableCoordinate;
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

            return -1;
        }
    }
}