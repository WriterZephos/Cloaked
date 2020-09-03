namespace Clkd.Assets.Interfaces
{
    public interface ITrigger
    {
        int Priority { get; set; }
        bool Final { get; set; }
        bool RemoveOnExecute { get; set; }
        bool Evaluate();
    }
}
