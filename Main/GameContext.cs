using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Clkd.Assets;
using Clkd.Managers;
using Clkd.Assets.Interfaces;

namespace Clkd.Main
{
    public class GameContext
    {
        public string Id { get; protected set; }
        public int Rank { get; set; }
        public Dictionary<string, AbstractComponent> Components { get; set; }
        public KeyboardInputManager DefaultKeyboardInput
        {
            get
            {
                if (HasComponent<KeyboardInputManager>())
                {
                    return GetComponent<KeyboardInputManager>();
                }
                AddComponent(new KeyboardInputManager());
                return GetComponent<KeyboardInputManager>();
            }
        }
        public MouseInputManager DefaultMouseInput
        {
            get
            {
                if (HasComponent<MouseInputManager>())
                {
                    return GetComponent<MouseInputManager>();
                }
                AddComponent(new MouseInputManager());
                return GetComponent<MouseInputManager>();
            }
        }

        public GameContext(string id)
        {
            Id = id;
            Components = new Dictionary<string, AbstractComponent>();
        }

        private GameContext(string id, Dictionary<string, AbstractComponent> components)
        {
            Id = id;
            Components = new Dictionary<string, AbstractComponent>(components);
        }

        public void Update(GameTime gameTime)
        {
            Components.Where(kvp => kvp.Value.CanUpdate)
                .Select(kvp => kvp.Value)
                .ToList()
                .ForEach((c) => c.Update(gameTime));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Components.Where(kvp => kvp.Value.CanDraw)
                .Select(kvp => kvp.Value)
                .ToList().ForEach((c) => c.Draw(spriteBatch));
        }

        public List<IRenderable> GetRenderables()
        {
            return Components.Where(kvp => kvp.Value.CanGetRenderables)
                .Select(kvp => kvp.Value.GetRenderables())
                .Where((list) => list != null).Aggregate(
                    new List<IRenderable>(),
                    (finalList, list) =>
                    {
                        finalList.AddRange(list);
                        return finalList;
                    }
                );
        }

        /// <summary>
        /// Returns a shallow copy of this GameContext, resulting in the AbstractComponents of
        /// this GameContext existing in both GameContexts. They can then be overridden, removed
        /// or added to independently to have a GameContexts that shares some
        /// but not all of their AbstractComponents.
        /// </summary>
        /// <param name="id">The Id of the new GameContext</param>
        /// <returns>The shallow copy of this GameContext.</returns>
        public GameContext ShallowCopy(string id)
        {
            return new GameContext(id, Components);
        }

        public T GetComponent<T>(string id) where T : AbstractComponent
        {
            // Components[typeof(T).Name] is assigned to c
            // and returned if it is the correct type.
            if (Components[id] is T c) return c;
            throw new ArgumentException($"Component is not a {typeof(T)}.");
        }

        public T GetComponent<T>() where T : AbstractComponent
        {
            // Components[typeof(T).Name] is assigned to c
            // and returned if it is the correct type.
            if (Components[typeof(T).Name] is T c) return c;
            throw new ArgumentException($"Component is not a {typeof(T)}.");
        }

        public GameContext AddComponent(string id, AbstractComponent component)
        {
            Components[id] = component;
            return this;
        }

        public GameContext AddComponent(AbstractComponent component)
        {
            Components[component.GetType().Name] = component;
            return this;
        }

        public bool HasComponent<T>(string id) where T : AbstractComponent
        {
            return Components.ContainsKey(id) && (Components[id] is T c);
        }

        public bool HasComponent<T>() where T : AbstractComponent
        {
            return Components.ContainsKey(typeof(T).Name);
        }
    }
}
