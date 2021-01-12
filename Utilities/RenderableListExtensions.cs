using System.Collections.Generic;

namespace Clkd.Assets
{
    public static class RenderableListExtensions
    {
        public static List<IRenderable> Condense(this List<IRenderable> existingList, List<IRenderable> additionalList)
        {
            if (additionalList != null) existingList.AddRange(additionalList);
            return existingList;
        }
    }
}
