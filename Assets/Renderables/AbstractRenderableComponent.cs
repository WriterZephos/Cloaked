using Clkd.Main;

namespace Clkd.Assets
{
    public class AbstractRenderableComponent : AbstractComponent
    {
        public string DrawStrategy { get; set; } = "basic";
        public string BatchStrategy { get; set; } = "basic";
        public string RenderTargetStrategy { get; set; } = "null";
        public bool IsOffset { get; set; } = false;

        public AbstractRenderableComponent() : base(canGetRenderables: true) { }

    }
}