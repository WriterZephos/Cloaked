using Clkd.Assets;
using Clkd.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Clkd.Managers.Interfaces
{
    public interface ITextureManager
    {
        void LoadTexture(string fileName);
        Texture2D GetTexture(string textureID);
    }
}
