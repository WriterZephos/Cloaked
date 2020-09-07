using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Clkd.Assets;
using Clkd.Main;

namespace Clkd.State
{
    public class BasicGameState : AbstractGameState
    {
        public Dictionary<string, AbstractTimedEffect> ActionEffects { get; set; } = new Dictionary<string, AbstractTimedEffect>();
        public Dictionary<string, SpriteAnimation> Animations { get; set; } = new Dictionary<string, SpriteAnimation>();
        public Dictionary<string, Trigger> Triggers { get; set; } = new Dictionary<string, Trigger>();
        public Dictionary<string, AbstractComponent> StateComponents { get; set; } = new Dictionary<string, AbstractComponent>();

        public override List<Renderable> GetRenderables(RenderableCoordinate? renderableCoordinate = null)
        {
            List<Renderable> renderables = new List<Renderable>();
            foreach (KeyValuePair<string, AbstractComponent> kvp in StateComponents)
            {
                if (kvp.Value.CanGetRenderables)
                {
                    renderables.Condense(kvp.Value.GetRenderables(renderableCoordinate));
                }
            }
            return renderables;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<string, AbstractComponent> kvp in StateComponents)
            {
                if (kvp.Value.CanUpdate)
                {
                    kvp.Value.Update(gameTime);
                }
            }
        }

        public T GetComponent<T>(string key) where T : AbstractGameState
        {
            return StateComponents[key].CastTo<T>();
        }
    }
}
