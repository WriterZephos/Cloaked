using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Clkd.Assets;

namespace Clkd.Main
{
    public abstract class AbstractComponent
    {
        public bool CanUpdate { get; private set; }
        public bool CanGetRenderables { get; private set; }
        public bool CanDraw { get; private set; }


        public T CastTo<T>() where T : AbstractComponent
        {
            return (T)this;
        }

        public AbstractComponent(bool canUpdate = false, bool canGetRenderables = false, bool canDraw = false)
        {
            CanUpdate = canUpdate;
            CanGetRenderables = canGetRenderables;
            CanDraw = canDraw;
        }

        public virtual void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public virtual List<Renderable> GetRenderables(RenderableCoordinate? renderableCoordinate = null)
        {
            throw new NotImplementedException();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
