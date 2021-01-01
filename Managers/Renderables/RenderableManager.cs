using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Clkd.Assets;
using Clkd.Main;

namespace Clkd.Managers
{
    public class RenderableManager : AbstractComponent
    {
        public static Dictionary<string, IDrawStrategy> RenderingStrategies { get; set; }
        public static Dictionary<string, IBatchStrategy> BatchStrategies { get; set; }
        public static Dictionary<string, IRenderTargetStrategy> RenderTargetStrategies { get; set; }
        static RenderableManager()
        {
            RenderingStrategies = new Dictionary<string, IDrawStrategy>();
            RenderingStrategies.Add("basic", new BasicRenderingStrategy());

            BatchStrategies = new Dictionary<string, IBatchStrategy>();
            BatchStrategies.Add("basic", new BasicBatchStrategy());

            RenderTargetStrategies = new Dictionary<string, IRenderTargetStrategy>();
            RenderTargetStrategies.Add("null", new NullRenderTargetStrategy());
        }

        Color? ClearColor { get; set; }
        public GraphicsDeviceManager GraphicsDeviceManager { get; set; }
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

            RenderableManager.RenderTargetStrategies.Add("basic", new BasicRenderTargetStrategy(GraphicsDeviceManager.GraphicsDevice, RenderMargin));
        }

        public RenderableManager SetWindowSize(int windoWidth, int windowHeight)
        {
            WindoWidth = windoWidth;
            WindowHeight = windowHeight;

            ViewPort = new Rectangle(0, 0, WindoWidth, WindowHeight);

            GraphicsDeviceManager.PreferredBackBufferWidth = WindoWidth;  // set this value to the desired width of your window
            GraphicsDeviceManager.PreferredBackBufferHeight = WindowHeight;
            GraphicsDeviceManager.ApplyChanges();

            foreach (IRenderTargetStrategy strategy in RenderableManager.RenderTargetStrategies.Values)
            {
                strategy.WindowSizeChanged(GraphicsDeviceManager.GraphicsDevice, RenderMargin);
            }

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
            DrawToRenderTarget(spriteBatch);
            DrawRenderTarget(spriteBatch);
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

        private void DrawToRenderTarget(SpriteBatch spriteBatch)
        {
            string currentBatchStrategy = null;
            string currentRenderTargetStrategy = null;
            RenderablesInScope.ForEach(
                (r) =>
                {
                    currentRenderTargetStrategy = SetRenderTarget(currentRenderTargetStrategy, r);
                    currentBatchStrategy = DrawRenderable(currentBatchStrategy, spriteBatch, r);
                }
            );
            BatchStrategies[currentBatchStrategy].End(spriteBatch);
            GraphicsDeviceManager.GraphicsDevice.SetRenderTarget(null);
        }

        private string SetRenderTarget(string currentRenderTargetStrategy, Renderable renderable)
        {
            if (currentRenderTargetStrategy != renderable.RenderTargetStrategy)
            {
                RenderTargetStrategies[renderable.RenderTargetStrategy].SetRenderTarget(GraphicsDeviceManager.GraphicsDevice);
            }
            return renderable.RenderTargetStrategy;
        }

        private string DrawRenderable(string currentBatchStrategy, SpriteBatch spriteBatch, Renderable renderable)
        {
            if (currentBatchStrategy == null)
            {
                BatchStrategies[renderable.BatchStrategy].Begin(spriteBatch);
            }
            else if (currentBatchStrategy != renderable.BatchStrategy)
            {
                BatchStrategies[currentBatchStrategy].End(spriteBatch);
                BatchStrategies[renderable.BatchStrategy].Begin(spriteBatch);
            }

            RenderingStrategies[renderable.DrawStrategy].Draw(renderable, spriteBatch);
            return renderable.BatchStrategy;
        }

        private void DrawRenderTarget(SpriteBatch spriteBatch)
        {
            if (ClearColor != null)
            {
                GraphicsDeviceManager.GraphicsDevice.Clear(ClearColor.Value);
            }
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            foreach (IRenderTargetStrategy strategy in RenderableManager.RenderTargetStrategies.Values)
            {
                strategy.DrawRenderTarget(spriteBatch, ViewPort, Camera.ViewRectangle, Color.White);
            }
            spriteBatch.End();
        }
    }
}
