using Clkd.Assets;
using Clkd.Assets.Interfaces;
using Clkd.Main;
using Clkd.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Clkd.State
{
    public abstract class AbstractTimedEffectState : AbstractComponent
    {
        public TimeSpan RemainingDuration { get; set; }
        public int RemainingIterations { get; set; }
        public TimeSpan TimeSinceLast { get; set; }
        public bool Started { get; set; }
        public bool Activated { get; set; }
        public bool Completed { get; set; }
        public AbstractTimedEffect Effect { get; set; }

        public AbstractTimedEffectState(AbstractTimedEffect effect, bool canUpdate = false, bool canGetRenderables = false, bool canDraw = false) 
            : base(canUpdate: canUpdate, canGetRenderables: canGetRenderables, canDraw: canDraw)
        {
            Effect = effect;
        }

        /// <summary>
        /// Resets the TimedEffectState to it's default state, as if it has just been instantiated.
        /// </summary>
        public virtual void Reset()
        {
            RemainingDuration = default(TimeSpan);
            RemainingIterations = 0;
            TimeSinceLast = default(TimeSpan);
            Started = false;
            Activated = false;
            Completed = false;
        }

        /// <summary>
        /// Primes the TimedEffectState to begin execution.
        /// Calls Reset().
        /// </summary>
        public virtual void Prime()
        {
            Reset();
            Started = true;
            TimeSinceLast = TimeSpan.Zero;
            if (Effect.DurationLimit.Ticks > 0)
            {
                RemainingDuration = Effect.DurationLimit;
            }

            if (Effect.IterationLimit > 0)
            {
                RemainingIterations = Effect.IterationLimit;
            }
        }
    }
}
