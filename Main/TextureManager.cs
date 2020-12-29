using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Clkd.Main;
using Clkd.Managers.Interfaces;

namespace Clkd.Managers
{
    public class TextureManager : ITextureManager
    {
        public Dictionary<string, Texture2D> Textures { get; set; } = new Dictionary<string, Texture2D>();

        public void LoadTexture(string fileName)
        {
            if (!Textures.ContainsKey(fileName))
            {
                Texture2D texture;
                if (fileName == "generic_white")
                {
                    int size = 100;
                    texture = new Texture2D(Cloaked.GraphicsDeviceManager.GraphicsDevice, size, size);
                    Color[] data = new Color[size * size];
                    for (int i = 0; i < size * size; i++) data[i] = Color.White;
                    texture.SetData(data);
                }
                else
                {
                    texture = Cloaked.Game.Content.Load<Texture2D>(fileName);
                }
                Textures.Add(fileName, texture);
            }
        }

        public Texture2D GetTexture(string textureID)
        {
            LoadTexture(textureID);
            return Textures[textureID];
        }
    }
}
