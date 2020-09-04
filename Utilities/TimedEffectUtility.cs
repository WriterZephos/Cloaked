using Clkd.Assets;
using Clkd.Assets.Interfaces;
using Clkd.State;
using Microsoft.Xna.Framework;
using System;

namespace Clkd.Utilities
{
    public static class TimedEffectUtility
    {

        public static bool ProgressEffect(GameTime gameTime, AbstractTimedEffectState state)
        {
            return ProgressEffect(gameTime, state.Effect, state);
        }

        public static bool ProgressEffect(GameTime gameTime, AbstractTimedEffect effect, AbstractTimedEffectState state)
        {
            if (state.Completed) return false;
            state.Activated = false;

            PrepEffect(gameTime, effect, state);
            
            if ((effect.Interval != null && effect.Interval < state.TimeSinceLast) || effect.Interval == null)
            {
                // Check if either duration or iteration limit has been reached
                if ((effect.DurationLimit.Ticks == 0 || state.RemainingDuration.TotalMilliseconds > 0)
                    && (effect.IterationLimit == 0 || state.RemainingIterations > 0))
                {
                    state.Activated = true;
                }
                else
                {
                    state.Completed = true;
                }
            }

            if (state.Activated)
            {
                state.TimeSinceLast = TimeSpan.Zero;
                if (effect.IterationLimit > 0)
                {
                    state.RemainingIterations--;
                }
            }

            return state.Activated;
        }

        private static void PrepEffect(GameTime gameTime, AbstractTimedEffect effect, AbstractTimedEffectState state)
        {
            if (!state.Started)
            {
                state.Prime();
            }
            else
            {
                state.TimeSinceLast += gameTime.ElapsedGameTime;
                if (effect.DurationLimit.Ticks > 0)
                {
                    state.RemainingDuration -= gameTime.ElapsedGameTime;
                }
            }
        }
    }
}
