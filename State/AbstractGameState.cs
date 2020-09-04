using Clkd.Assets;
using Clkd.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Clkd.State
{
    public abstract class AbstractGameState : AbstractComponent
    {
        public AbstractGameState() : base(canUpdate: true, canGetRenderables: true) {}
        public abstract override void Update(GameTime gameTime);
        public abstract override List<Renderable> GetRenderables(RenderableCoordinate? renderableCoordinate = null);
    }
}
