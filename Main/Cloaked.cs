using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Clkd.Managers;
using Clkd.Managers.Interfaces;

namespace Clkd.Main
{
    // TODO:
    // Implement more input managers.
    // Implement object pools for animation, gamestate, timedeffects, etc. Probably use generics for this.

    /// <summary>
    /// This class is the root node of a game, containing references to all state and functionality of the game
    /// and providing entry points for executing game loop routines (updates and rendering).
    /// 
    /// 
    /// </summary>
    public static class Cloaked
    {
        public static ContentManager Content { get; private set; }
        public static GraphicsDeviceManager GraphicsDeviceManager { get; set; }
        public static ITextureManager TextureManager { get; set; } = new TextureManager();
        public static ContextManager ContextManager { get; set; }
        public static bool Initialized = false;
        public static bool Ready { get; set; } = false;

        /// <summary>
        /// Initializes Cloaked with the provided ContentManager, GraphicsDeviceManager and ContextManager.
        /// </summary>
        /// <param name="content">A ContentManager.</param>
        /// <param name="gameState">An AbstractGameState.</param>
        /// <param name="provider">An AbstractManagerProvider.</param>
        public static void Initialize(ContentManager content, GraphicsDeviceManager graphicsDeviceManager, ContextManager provider)
        {
            Content = content;
            GraphicsDeviceManager = graphicsDeviceManager;
            ContextManager = provider;
            Initialized = true;
        }

        /// <summary>
        /// Updates the active GameContext.
        /// 
        /// This method should be called from the Update method in your Game class.
        /// </summary>
        /// <param name="gameTime"></param>
        public static void Update(GameTime gameTime)
        {
            if (!Initialized || !Ready) return;

            GetCurrentContext().Update(gameTime);
        }

        /// <summary>
        /// Calls the Draw method for all components in the active GameContext with CanDraw = true.
        /// 
        /// This method should be called from the Draw method of your Game class.
        /// </summary>
        /// <param name="spriteBatch">A SpriteBatch to use for drawing.</param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            if (!Initialized || !Ready) return;
            GetCurrentContext().Draw(spriteBatch);
        }

        /// <summary>
        /// Gets a component of the specified type with the specified id by calling GetComponent<T>(string id) on the ContextProvider. 
        /// The returned AbstractComponent is not guaranteed to belong to the active GameContext, as ContextProvider
        /// will search all other contexts in ranked order (descending) if it cannot find the requested component
        /// in the active context.
        /// </summary>
        /// <typeparam name="T">A type derived from AbstractComponent.</typeparam>
        /// <param name="id">The id of the AbstractComponent being retrieved.</param>
        /// <returns>An AbstractComponent, or Null if it was not found.</returns>
        public static T GetComponent<T>(string id) where T : AbstractComponent
        {
            return ContextManager.GetComponent<T>(id);
        }

        /// <summary>
        /// Gets a component of the specified type by calling GetComponent<T>(string id) on the ContextProvider. 
        /// The returned AbstractComponent is not guaranteed to belong to the active GameContext, as ContextProvider
        /// will search all other contexts in ranked order (descending) if it cannot find the requested component
        /// in the active context.
        /// </summary>
        /// <typeparam name="T">A type derived from AbstractComponent.</typeparam>
        /// <returns>An AbstractComponent, or Null if it was not found.</returns>
        public static T GetComponent<T>() where T : AbstractComponent
        {
            return ContextManager.GetComponent<T>();
        }

        /// <summary>
        /// Returns the active GameContext by calling GetContext() on
        /// the ContextProvider.
        /// </summary>
        /// <returns>A GameContext.</returns>
        public static GameContext GetCurrentContext()
        {
            return ContextManager.GetContext();
        }

        /// <summary>
        /// Returns the GameContext specified by calling GetContext() on
        /// the ContextProvider.
        /// </summary>
        /// <param name="contextId">The id of the GameContext being retrieved.</param>
        /// <returns>A GameContext.</returns>
        public static GameContext GetContext(string contextId)
        {
            return ContextManager.GetContext(contextId);
        }

    }
}
