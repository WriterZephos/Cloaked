using Clkd.Assets.Interfaces;
using System;

namespace Clkd.Assets
{
    public class KeyTrigger : IInputTrigger<KeyStatus>
    {
        public Func<KeyStatus, bool> TriggerCondition { get; set; }
        public Action TriggerAction { get; set; }

        public KeyTrigger(Func<KeyStatus, bool> triggerCondition, Action triggerAction)
        {
            TriggerCondition = triggerCondition;
            TriggerAction = triggerAction;
        }

        public bool Evaluate(KeyStatus status)
        {
            if (TriggerCondition(status))
            {
                TriggerAction();
                return true;
            }
            return false;
        }
    }
}
