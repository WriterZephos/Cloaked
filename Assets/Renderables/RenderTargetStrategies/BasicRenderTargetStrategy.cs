using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Clkd.Assets
{
    public class BasicRenderTargetStrategy : IRenderTargetStrategy
    {
        public RenderTarget2D RenderTarget { get; set; }

        public BasicRenderTargetStrategy(GraphicsDevice graphicsDevice, int RenderMargin)
        {
            RenderTarget = new RenderTarget2D(
                graphicsDevice,
                graphicsDevice.PresentationParameters.BackBufferWidth + RenderMargin,
                graphicsDevice.PresentationParameters.BackBufferHeight + RenderMargin,
                false,
                graphicsDevice.PresentationParameters.BackBufferFormat,
                DepthFormat.Depth24);
        }
        public void DrawRenderTarget(SpriteBatch spriteBatch, Rectangle viewPort, Rectangle cameraView, Color tint)
        {
            spriteBatch.Draw(RenderTarget, viewPort, cameraView, Color.White);
        }

        public void SetRenderTarget(GraphicsDevice graphicsDevice)
        {
            graphicsDevice.SetRenderTarget(RenderTarget);
        }

        public void WindowSizeChanged(GraphicsDevice graphicsDevice, int RenderMargin)
        {
            RenderTarget = new RenderTarget2D(
                graphicsDevice,
                graphicsDevice.PresentationParameters.BackBufferWidth + RenderMargin,
                graphicsDevice.PresentationParameters.BackBufferHeight + RenderMargin,
                false,
                graphicsDevice.PresentationParameters.BackBufferFormat,
                DepthFormat.Depth24);
        }
    }
}