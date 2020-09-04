using Clkd.Assets;
using Clkd.Assets.Interfaces;
using Clkd.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Clkd.State
{
    public class SpriteAnimationState : AbstractTimedEffectState
    {
        public SpriteAnimation Animation
        {
            get => (SpriteAnimation) Effect;
            set => Effect = value;
        }

        public int CurrentFrame { get; set; }
        public RenderableCoordinate RenderableCoordinate { get; set; }

        public SpriteAnimationState(SpriteAnimation animation, int currentFrame = 0) 
            : base(animation, canUpdate: true, canGetRenderables: true) 
        {
            CurrentFrame = currentFrame;
        }

        public override void Update(GameTime gameTime)
        {
            if (TimedEffectUtility.ProgressEffect(gameTime, this))
            {
                CurrentFrame++;
                if (CurrentFrame >= Animation.Frames.Count) CurrentFrame = 0;
            }
        }

        public override List<Renderable> GetRenderables(RenderableCoordinate? renderableCoordinate = null)
        {
            if (Completed && !Animation.HoldLastFrame) return null;

            SpriteCoordinate spriteCoordinate = Animation.Frames[CurrentFrame];
            return new List<Renderable>() {
                new Renderable(spriteCoordinate, RenderableCoordinate)
            };
        }

        /// <summary>
        /// Overrides AbstractTimedEffectState to reset additional properties.
        /// Calls base.Reset().
        /// </summary>
        public override void Reset()
        {
            base.Reset();
            CurrentFrame = 0;
        }
    }
}
