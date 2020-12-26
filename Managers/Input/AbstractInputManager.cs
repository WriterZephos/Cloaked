using Microsoft.Xna.Framework;
using Clkd.Assets.Interfaces;
using Clkd.Main;
using Clkd.Assets;

namespace Clkd.Managers
{
    public abstract class AbstractInputManager<T, J> : AbstractComponent where J : IInputStatus where T : AbstractInputTrigger<J>
    {
        public AbstractInputManager() : base(canUpdate: true)
        {
        }

        public abstract override void Update(GameTime gameTime);
    }
}
