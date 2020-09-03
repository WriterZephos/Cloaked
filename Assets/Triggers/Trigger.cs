using Clkd.Assets.Interfaces;
using System;

namespace Clkd.Assets
{
    public class Trigger : ITrigger
    {
        public string Name { get; set; }
        public Func<bool> TriggerCondition { get; set; }
        public Action TriggerAction { get; set; }
        public int Priority { get; set; }
        public bool Final { get; set; }
        public bool RemoveOnExecute { get; set; }

        public Trigger(string name, Func<bool> condition, Action action, int priority = 3, bool final = false, bool removeOnExecute = true) 
        {
            Name = name;
            TriggerCondition = condition;
            TriggerAction = action;
            Priority = priority;
            Final = final;
            RemoveOnExecute = removeOnExecute;
        }

        /// <summary>
        /// Calls this trigger's Condition function and calls its Action function if it returns true.
        /// </summary>
        /// <returns>Returns true if the Condition function returned true and the Action function was called. False otherwise.</returns>
        public bool Evaluate()
        {
            if (TriggerCondition())
            {
                TriggerAction();
                return true;
            }
            return false;
        }
    }
}
