using System;
using Clkd.Assets.Interfaces;

namespace Clkd.Assets
{
    public delegate void ConditionSatisfiedHandler<K>(K status) where K : IInputStatus;

    public class GenericInputEventTrigger<T> : AbstractInputTrigger<T> where T : IInputStatus
    {
        public Func<T, bool> ConditionFunction { get; set; }
        public event ConditionSatisfiedHandler<T> OnConditionSatisfied;

        public GenericInputEventTrigger(Func<T, bool> conditionFunction, params ConditionSatisfiedHandler<T>[] triggerActions)
        {
            ConditionFunction = conditionFunction;
            foreach (ConditionSatisfiedHandler<T> handler in triggerActions)
            {
                OnConditionSatisfied += handler;
            }

        }

        public override bool Evaluate(T status)
        {
            if (ConditionFunction(status))
            {
                OnConditionSatisfied.Invoke(status);
                return true;
            }
            return false;
        }
    }
}