using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;

using Clkd.Assets.Interfaces;

namespace Clkd.Managers
{
    public class TriggerManager : AbstractTriggerManager
    {
        public Dictionary<string, List<ITrigger>> Subscriptions { get; set; } = new Dictionary<string, List<ITrigger>>();
        public Queue<string> Events { get; set; } = new Queue<string>();

        public override void Subscribe(string eventName, ITrigger trigger)
        {
            List<ITrigger> trigger_list =
                Subscriptions.ContainsKey(eventName) ?
                Subscriptions[eventName] : new List<ITrigger>();

            int index = trigger_list.Count;
            trigger_list.Add(trigger);
            Subscriptions[eventName] = trigger_list;
        }

        public override void Unsubscribe(string eventName, int index)
        {
            List<ITrigger> triggerList = Subscriptions[eventName];
            if (triggerList != null && triggerList.Count > index)
            {
                triggerList.RemoveAt(index);
            }
        }

        public override void Publish(string eventName)
        {
            Events.Enqueue(eventName);
        }

        public override void Update(GameTime gameTime)
        {
            while (Events.Count > 0)
            {
                string eventName = Events.Dequeue();

                if (Subscriptions.TryGetValue(eventName, out List<ITrigger> triggerList))
                {
                    List<ITrigger> sortedList = triggerList.OrderByDescending((t) => t.Priority).ToList();

                    foreach (ITrigger trigger in sortedList)
                    {
                        if (trigger.Evaluate() && trigger.RemoveOnExecute)
                        {
                            triggerList.Remove(trigger);
                        }
                        if (trigger.Final)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
