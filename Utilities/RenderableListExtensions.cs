using System.Collections.Generic;
using Clkd.Assets;

namespace Clkd.Assets
{
    public static class RenderableListExtensions
    {
        public static List<Renderable> Condense(this List<Renderable> existingList, List<Renderable> additionalList)
        {
            if (additionalList != null) existingList.AddRange(additionalList);
            return existingList;
        }
    }
}
