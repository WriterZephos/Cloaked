namespace Clkd.Assets.Interfaces
{
    public interface IInputTrigger<T> where T : IInputStatus
    {
        bool Evaluate(T status);
    }
}
