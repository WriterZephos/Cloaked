using System;

using Microsoft.Xna.Framework;

using Clkd.State;

namespace Clkd.Assets
{
    public abstract class AbstractTimedExecution : AbstractTimedEffect
    {
        public AbstractTimedExecution(
            TimeSpan interval,
            TimeSpan durationLimit = default(TimeSpan),
            int iterationLimit = 0
        ) : base(interval, durationLimit, iterationLimit) { }

        public abstract void Execute(GameTime gameTime, TimedExecutionState timedEffectState);
    }
}
