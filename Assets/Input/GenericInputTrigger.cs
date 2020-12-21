using System;
using Clkd.Assets.Interfaces;

namespace Clkd.Assets
{
    public class GenericInputTrigger<T> : IInputTrigger<T> where T : IInputStatus
    {
        public Func<T, bool> TriggerCondition { get; set; }
        public Action<T> TriggerAction { get; set; }

        public GenericInputTrigger(Func<T, bool> triggerCondition, Action<T> triggerAction)
        {
            TriggerCondition = triggerCondition;
            TriggerAction = triggerAction;
        }

        public bool Evaluate(T status)
        {
            if (TriggerCondition(status))
            {
                TriggerAction(status);
                return true;
            }
            return false;
        }
    }
}