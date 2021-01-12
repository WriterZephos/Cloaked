using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Clkd.Assets
{
    public interface IRenderTargetStrategy
    {
        void SetRenderTarget(GraphicsDevice graphicsDevice);
        void WindowSizeChanged(GraphicsDevice graphicsDevice, int RenderMargin);
        void DrawRenderTarget(SpriteBatch spriteBatch, Rectangle viewPort, Rectangle cameraView, Color tint);
    }
}