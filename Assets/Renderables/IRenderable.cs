using System;

namespace Clkd.Assets
{
    public interface IRenderable : IComparable<IRenderable>
    {
        RenderableCoordinate RenderableCoordinate { get; set; }
        string DrawStrategy { get; set; }
        string BatchStrategy { get; set; }
        string RenderTargetStrategy { get; set; }
    }
}