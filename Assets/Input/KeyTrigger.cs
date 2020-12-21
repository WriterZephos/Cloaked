using System;

using Clkd.Assets.Interfaces;

namespace Clkd.Assets
{
    public class KeyTrigger : IInputTrigger<KeyStatus>
    {
        public Func<KeyStatus, bool> TriggerCondition { get; set; }
        public Action<KeyStatus> TriggerAction { get; set; }

        public KeyTrigger(Func<KeyStatus, bool> triggerCondition, Action<KeyStatus> triggerAction)
        {
            TriggerCondition = triggerCondition;
            TriggerAction = triggerAction;
        }

        public bool Evaluate(KeyStatus status)
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
