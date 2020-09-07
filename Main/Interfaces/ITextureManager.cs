using Microsoft.Xna.Framework.Graphics;

namespace Clkd.Managers.Interfaces
{
    public interface ITextureManager
    {
        void LoadTexture(string fileName);
        Texture2D GetTexture(string textureID);
    }
}
