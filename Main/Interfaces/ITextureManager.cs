using Microsoft.Xna.Framework.Graphics;

namespace Clkd.Managers.Interfaces
{
    public interface ITextureManager
    {
        void LoadTexture(string fileName);
        void LoadTexture(string id, Texture2D texture);
        Texture2D GetTexture(string textureID);
        void LoadSpriteFont(string spriteFontID);
        SpriteFont GetSpriteFont(string spriteFontID);
    }
}
