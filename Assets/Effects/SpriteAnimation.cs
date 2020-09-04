using Clkd.Main;
using Clkd.Assets.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace Clkd.Assets
{
    public class SpriteAnimation : AbstractTimedEffect
    {
        public List<SpriteCoordinate> Frames { get; set; }
        public bool HoldLastFrame { get; set; }

        // Constructors
        public SpriteAnimation(
            List<SpriteCoordinate> frames,
            TimeSpan interval = default(TimeSpan),
            TimeSpan durationLimit = default(TimeSpan),
            int iterationLimit = 1,
            bool holdLastFrame = true) : base(interval, durationLimit, iterationLimit)
        {
            Frames = frames;
            HoldLastFrame = holdLastFrame;
        }
        
    }
}
