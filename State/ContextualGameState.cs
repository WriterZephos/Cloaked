using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;

using Clkd.Assets;
using Clkd.Main;

namespace Clkd.State
{
    public class ContextualGameState : AbstractGameState
    {
        // These properties are meant as a library for various types of effects, etc. They should probably be moved to somewhere else.
        public Dictionary<string, AbstractTimedEffect> TimedActionEffects { get; set; } = new Dictionary<string, AbstractTimedEffect>();
        public Dictionary<string, SpriteAnimation> SpriteAnimations { get; set; } = new Dictionary<string, SpriteAnimation>();
        public Dictionary<string, Trigger> Triggers { get; set; } = new Dictionary<string, Trigger>();
        public Dictionary<string, Dictionary<string, AbstractComponent>> ContextualStates { get; set; } = new Dictionary<string, Dictionary<string, AbstractComponent>>();

        public ContextualGameState(string context1 = "default", params string[] contexts)
        {
            foreach (string contextId in new string[] { context1 }.Concat(contexts))
            {
                ContextualStates[contextId] = new Dictionary<string, AbstractComponent>();
            }
        }

        public override void Update(GameTime gameTime)
        {
            Dictionary<string, AbstractComponent> contextualComponents =
                ContextualStates[Cloaked.ContextManager.GetContext().Id];

            foreach (KeyValuePair<string, AbstractComponent> kvp in contextualComponents)
            {
                if (kvp.Value.CanUpdate)
                {
                    kvp.Value.Update(gameTime);
                }
            }
        }

        public override List<IRenderable> GetRenderables(RenderableCoordinate? renderableCoordinate = null)
        {
            Dictionary<string, AbstractComponent> contextualComponents =
                ContextualStates[Cloaked.ContextManager.GetContext().Id];

            List<IRenderable> renderables = new List<IRenderable>();
            foreach (KeyValuePair<string, AbstractComponent> kvp in contextualComponents)
            {
                if (kvp.Value.CanGetRenderables)
                {
                    renderables.Condense(kvp.Value.GetRenderables(renderableCoordinate));
                }
            }
            return renderables;
        }

        public void InitializeContexts(params string[] contextIds)
        {
            foreach (string contextId in contextIds)
            {
                ContextualStates[contextId] = new Dictionary<string, AbstractComponent>();
            }
        }

        public Dictionary<string, AbstractComponent> InitializeContext(string contextId)
        {
            ContextualStates[contextId] = new Dictionary<string, AbstractComponent>();
            return ContextualStates[contextId];
        }

        public T GetComponent<T>(string contextId, string key) where T : AbstractComponent
        {
            return ContextualStates[contextId][key].CastTo<T>();
        }

        public void SetComponent<T>(string contextId, string key, T component) where T : AbstractComponent
        {
            ContextualStates[contextId][key] = component;
        }
    }
}
