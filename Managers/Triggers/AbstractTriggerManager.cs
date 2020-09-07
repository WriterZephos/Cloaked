using Microsoft.Xna.Framework;

using Clkd.Assets.Interfaces;
using Clkd.Main;

namespace Clkd.Managers
{
    public abstract class AbstractTriggerManager : AbstractComponent
    {
        public AbstractTriggerManager() : base(canUpdate: true) { }

        public abstract void Subscribe(string eventName, ITrigger trigger);
        public abstract void Unsubscribe(string eventName, int index);
        public abstract void Publish(string eventName);
        public abstract override void Update(GameTime gameTime);
    }
}
