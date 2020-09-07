using System.Collections.Generic;
using System.Linq;

namespace Clkd.Main
{
    public class ContextManager
    {
        private GameContext ActiveGameContext;
        public Dictionary<string, GameContext> ContextStore { get; set; } = new Dictionary<string, GameContext>();

        public ContextManager() { }

        public ContextManager(GameContext startingContext)
        {
            ActiveGameContext = startingContext;
            ContextStore.Add(startingContext.Id, startingContext);
        }

        public ContextManager(GameContext startingContext, params GameContext[] contexts)
        {
            var allContexts = new GameContext[] { startingContext }.Concat(contexts).ToList();
            foreach (GameContext context in allContexts)
            {
                ContextStore[context.Id] = context;
                if (context.Rank == 0)
                {
                    context.Rank = ContextStore.Count;
                }
            }

            ActiveGameContext = allContexts[0];
        }

        public GameContext ActivateContext(string id)
        {
            GameContext context;
            if (ContextStore.TryGetValue(id, out context))
            {
                ActiveGameContext = context;
            }

            return context;
        }

        public void ActivateContext(GameContext context)
        {
            ActiveGameContext = context;
            ContextStore.Add(context.Id, context);
        }

        public GameContext AddContext(GameContext context)
        {
            ContextStore[context.Id] = context;
            if (context.Rank == 0)
            {
                context.Rank = ContextStore.Count;
            }
            return context;
        }

        /// <summary>
        /// Creates a shallow copy of the specified GameContext and adds it to this ContextProvider,
        /// resulting in the AbstractComponents of that GameContext existing in both GameContexts. 
        /// They can then be overrided, removed or added to independently to have a GameContexts 
        /// that shares some but not all of their AbstractComponents.
        /// </summary>
        /// <see cref="GameContext.ShallowCopy(string)">See ShallowCopy</see>
        /// <param name="id">The Id of the new GameContext</param>
        /// <returns>The shallow copy of the specified GameContext.</returns>
        public GameContext AddShallowCopyOf(string id, string newId)
        {
            return AddContext(GetContext(id).ShallowCopy(newId));
        }

        public GameContext AddNewContext(string newId)
        {
            GameContext context = new GameContext(newId);
            AddContext(context);
            return context;
        }

        public GameContext RemoveContext(string id)
        {
            GameContext context;
            if (ContextStore.TryGetValue(id, out context))
            {
                ContextStore.Remove(id);
            }

            return context;
        }

        public GameContext GetContext()
        {
            return ActiveGameContext;
        }

        public GameContext GetContext(string id)
        {
            return ContextStore[id];
        }

        public T GetComponent<T>(string id, bool activeContextOnly = true) where T : AbstractComponent
        {
            if (ActiveGameContext.HasComponent<T>(id))
            {
                return ActiveGameContext.GetComponent<T>(id);
            }
            else if (!activeContextOnly)
            {
                foreach (GameContext gc in GetContextsRanked())
                {
                    if (gc.HasComponent<T>(id))
                    {
                        return gc.GetComponent<T>(id);
                    }
                }
            }
            return null;
        }

        public T GetComponent<T>(bool activeContextOnly = true) where T : AbstractComponent
        {
            if (ActiveGameContext.HasComponent<T>())
            {
                return ActiveGameContext.GetComponent<T>();
            }
            else if (!activeContextOnly)
            {
                foreach (GameContext gc in GetContextsRanked())
                {
                    if (gc.HasComponent<T>())
                    {
                        return gc.GetComponent<T>();
                    }
                }
            }
            return null;
        }

        public List<GameContext> GetContextsRanked()
        {
            return ContextStore.Values.OrderByDescending<GameContext, int>((GameContext) => GameContext.Rank).ToList();
        }
    }
}
