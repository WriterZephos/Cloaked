using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Clkd.Assets;
using Clkd.Main;

namespace Clkd.State
{
    public abstract class AbstractGameState : AbstractComponent
    {
        public AbstractGameState() : base(canUpdate: true, canGetRenderables: true) { }
        public abstract override void Update(GameTime gameTime);
        public abstract override List<Renderable> GetRenderables(RenderableCoordinate? renderableCoordinate = null);
    }
}
