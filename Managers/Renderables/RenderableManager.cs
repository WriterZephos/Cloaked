using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Clkd.Assets;
using Clkd.Main;

namespace Clkd.Managers
{
    public class RenderableManager : AbstractComponent
    {
        public GraphicsDeviceManager GraphicsDeviceManager { get; set; }
        public RenderTarget2D RenderTarget { get; set; }

        public List<Renderable> RenderablesInScope { get; set; }
        public int RenderMargin { get; set; }
        private int LeftBoundary = 0;
        private int RightBoundary = 0;
        private int TopBoundary = 0;
        private int BottomBoundary = 0;

        public Camera2D Camera { get; set; }

        public Rectangle ViewPort { get; set; }

        public int WindoWidth { get; set; }
        public int WindowHeight { get; set; }
        // TODO: use a rectangle for the view and implement a camera system

        public RenderableManager(GraphicsDeviceManager graphicsDeviceManager,
            Camera2D camera,
            int renderMargin = 0,
            int windoWidth = 500,
            int windowHeight = 500) : base(true, false, true)
        {
            RenderablesInScope = new List<Renderable>();
            Camera = camera;

            RenderMargin = renderMargin;
            WindoWidth = windoWidth;
            WindowHeight = windowHeight;

            ViewPort = new Rectangle(0, 0, WindoWidth, WindowHeight);

            GraphicsDeviceManager = graphicsDeviceManager;

            GraphicsDeviceManager.PreferredBackBufferWidth = WindoWidth;
            GraphicsDeviceManager.PreferredBackBufferHeight = windowHeight;
            GraphicsDeviceManager.ApplyChanges();

            RenderTarget = new RenderTarget2D(
                GraphicsDeviceManager.GraphicsDevice,
                GraphicsDeviceManager.GraphicsDevice.PresentationParameters.BackBufferWidth + RenderMargin,
                GraphicsDeviceManager.GraphicsDevice.PresentationParameters.BackBufferHeight + RenderMargin,
                false,
                GraphicsDeviceManager.GraphicsDevice.PresentationParameters.BackBufferFormat,
                DepthFormat.Depth24);
        }

        public RenderableManager SetWindowSize(int windoWidth, int windowHeight)
        {
            WindoWidth = windoWidth;
            WindowHeight = windowHeight;

            ViewPort = new Rectangle(0, 0, WindoWidth, WindowHeight);

            GraphicsDeviceManager.PreferredBackBufferWidth = WindoWidth;  // set this value to the desired width of your window
            GraphicsDeviceManager.PreferredBackBufferHeight = WindowHeight;
            GraphicsDeviceManager.ApplyChanges();

            RenderTarget = new RenderTarget2D(
                GraphicsDeviceManager.GraphicsDevice,
                GraphicsDeviceManager.GraphicsDevice.PresentationParameters.BackBufferWidth + RenderMargin,
                GraphicsDeviceManager.GraphicsDevice.PresentationParameters.BackBufferHeight + RenderMargin,
                false,
                GraphicsDeviceManager.GraphicsDevice.PresentationParameters.BackBufferFormat,
                DepthFormat.Depth24);

            return this;
        }

        public RenderableManager SetCameraView(Rectangle viewRectangle)
        {
            Camera.ViewRectangle = viewRectangle;
            return this;
        }

        public override void Update(GameTime gameTime)
        {
            SetBoundaries();
            GetRenderablesInScope();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawToRenderTarget(spriteBatch, RenderTarget);
            DrawRenderTarget(spriteBatch, RenderTarget);
        }

        public override List<Renderable> GetRenderables(RenderableCoordinate? renderableCoordinate = null)
        {
            throw new System.NotImplementedException();
        }

        private bool IsInScope(Renderable renderable)
        {
            return renderable.RenderableCoordinate.X > LeftBoundary
                && renderable.RenderableCoordinate.X < RightBoundary
                && renderable.RenderableCoordinate.Y > TopBoundary
                && renderable.RenderableCoordinate.Y < BottomBoundary;
        }

        private void SetBoundaries()
        {
            int horizontalRenderHalf = (WindoWidth / 2) + RenderMargin;
            int verticalRenderHalf = (WindowHeight / 2) + RenderMargin;

            LeftBoundary = (int)(Camera.OriginX - horizontalRenderHalf);
            RightBoundary = ((int)Camera.OriginX + horizontalRenderHalf);
            TopBoundary = (int)(Camera.OriginY - verticalRenderHalf);
            BottomBoundary = (int)(Camera.OriginY + verticalRenderHalf);
        }

        private void GetRenderablesInScope()
        {
            // Refactor this entire rendering process!!! It sucks

            // Filters out inactive or out of view objects.
            // Orders by z index so things are drawn in the correct order.
            // Also orders by texture to avoid uneccessary switching between textures.
            RenderablesInScope = Cloaked.GetCurrentContext().GetRenderables();
            //.Where((r) => r.IsActive && IsInScope(r))
            RenderablesInScope.Sort();
        }

        private void DrawToRenderTarget(SpriteBatch spriteBatch, RenderTarget2D renderTarget)
        {
            GraphicsDeviceManager.GraphicsDevice.SetRenderTarget(RenderTarget);
            spriteBatch.Begin();
            RenderablesInScope.ForEach((r) => r.Draw(spriteBatch));
            spriteBatch.End();
            GraphicsDeviceManager.GraphicsDevice.SetRenderTarget(null);
        }

        private void DrawRenderTarget(SpriteBatch spriteBatch, RenderTarget2D renderTarget)
        {
            spriteBatch.Begin();
            GraphicsDeviceManager.GraphicsDevice.Clear(Color.Red);
            spriteBatch.Draw(RenderTarget, ViewPort, Camera.ViewRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
