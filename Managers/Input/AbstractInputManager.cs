using Microsoft.Xna.Framework;

using Clkd.Assets.Interfaces;
using Clkd.Main;

namespace Clkd.Managers
{
    public abstract class AbstractInputManager<T, J> : AbstractComponent where J : IInputStatus where T : IInputTrigger<J>
    {
        public AbstractInputManager() : base(canUpdate: true)
        {
        }

        public abstract override void Update(GameTime gameTime);
    }
}
