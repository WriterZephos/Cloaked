﻿using System.Collections.Generic;

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
