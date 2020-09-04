using System;
using Clkd.Assets;
using Clkd.Assets.Interfaces;
using Clkd.Utilities;
using Microsoft.Xna.Framework;

namespace Clkd.State
{
    public class TimedExecutionState : AbstractTimedEffectState
    {
        public TimedExecutionState(AbstractTimedExecution effect) : base(effect, canUpdate: true) {}
        public override void Update(GameTime gameTime)
        {
            if (TimedEffectUtility.ProgressEffect(gameTime, this))
            {
                ((AbstractTimedExecution) Effect).Execute(gameTime, this);
            }
        }
    }
}
