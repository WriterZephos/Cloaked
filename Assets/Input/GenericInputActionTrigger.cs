using System;
using Clkd.Assets.Interfaces;

namespace Clkd.Assets
{
    public class GenericInputActionTrigger<T> : AbstractInputTrigger<T> where T : IInputStatus
    {
        public Func<T, bool> TriggerCondition { get; set; }
        public Action<T> TriggerAction { get; set; }

        public GenericInputActionTrigger(Func<T, bool> triggerCondition, Action<T> triggerAction)
        {
            TriggerCondition = triggerCondition;
            TriggerAction = triggerAction;
        }

        public override bool Evaluate(T status)
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