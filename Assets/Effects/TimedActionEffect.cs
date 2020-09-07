using System;

using Microsoft.Xna.Framework;

using Clkd.State;

namespace Clkd.Assets
{
    public class TimedAction : AbstractTimedExecution
    {
        public Action<GameTime, AbstractTimedEffectState> Action { get; set; }

        public TimedAction(
            Action<GameTime, AbstractTimedEffectState> action,
            TimeSpan interval = default(TimeSpan),
            TimeSpan durationLimit = default(TimeSpan),
            int iterationLimit = 1
        ) : base(interval, durationLimit, iterationLimit)
        {
            this.Action = action;
        }

        public override void Execute(GameTime gameTime, TimedExecutionState timedEffectState)
        {
            if (Action != null)
            {
                Action(gameTime, timedEffectState);
            }
        }
    }
}
