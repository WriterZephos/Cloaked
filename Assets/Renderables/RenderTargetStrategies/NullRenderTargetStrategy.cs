using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Clkd.Assets
{
    public class NullRenderTargetStrategy : IRenderTargetStrategy
    {
        public void DrawRenderTarget(SpriteBatch spriteBatch, Rectangle viewPort, Rectangle cameraView, Color tint)
        {
            return;
        }

        public void SetRenderTarget(GraphicsDevice graphicsDevice)
        {
            graphicsDevice.SetRenderTarget(null);
        }

        public void WindowSizeChanged(GraphicsDevice graphicsDevice, int RenderMargin)
        {
            return;
        }
    }
}