using Clkd.Assets.Interfaces;
using Clkd.State;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clkd.Assets
{
    public abstract class AbstractTimedEffect
    {
        public TimeSpan DurationLimit { get; set; }
        public int IterationLimit { get; set; }
        public TimeSpan Interval { get; set; }

        public AbstractTimedEffect(
            TimeSpan interval, 
            TimeSpan durationLimit = default(TimeSpan), 
            int iterationLimit = 0) 
        {
            DurationLimit = durationLimit;
            IterationLimit = iterationLimit;
            Interval = interval;
        }
    }
}
