using System;
using Clkd.Assets.Interfaces;

namespace Clkd.Assets
{
    public abstract class AbstractInputTrigger<T> where T : IInputStatus
    {
        public Guid Guid { get; } = Guid.NewGuid();
        public abstract bool Evaluate(T status);
    }
}
