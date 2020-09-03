using Clkd.Assets;
using Clkd.Assets.Interfaces;
using Clkd.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

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
