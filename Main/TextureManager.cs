using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Clkd.Main;
using Clkd.Managers.Interfaces;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Clkd.Managers
{
    public class ContentManager : ITextureManager
    {
        public Dictionary<string, Texture2D> Textures { get; set; } = new Dictionary<string, Texture2D>();
        public Dictionary<string, SpriteFont> SpriteFonts { get; set; } = new Dictionary<string, SpriteFont>();
        public Dictionary<string, Song> Songs { get; set; } = new Dictionary<string, Song>();
        public Dictionary<string, SoundEffect> SoundEffects { get; set; } = new Dictionary<string, SoundEffect>();

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

        public void LoadTexture(string id, Texture2D texture)
        {
            if (!Textures.ContainsKey(id))
            {
                Textures.Add(id, texture);
            }
        }

        public Texture2D GetTexture(string textureID)
        {
            if (textureID == null) return null;
            LoadTexture(textureID);
            return Textures[textureID];
        }

        public void LoadSpriteFont(string spriteFontID)
        {
            if (!SpriteFonts.ContainsKey(spriteFontID))
            {
                SpriteFont spriteFont = Cloaked.Game.Content.Load<SpriteFont>(spriteFontID);
                SpriteFonts.Add(spriteFontID, spriteFont);
            }
        }

        public SpriteFont GetSpriteFont(string spriteFontID)
        {
            if (spriteFontID == null) return null;
            LoadSpriteFont(spriteFontID);
            return SpriteFonts[spriteFontID];
        }

        public void LoadSong(string songID)
        {
            if (!Songs.ContainsKey(songID))
            {
                Song song = Cloaked.Game.Content.Load<Song>(songID);
                Songs.Add(songID, song);
            }
        }

        public Song GetSong(string songID)
        {
            if (songID == null) return null;
            LoadSong(songID);
            return Songs[songID];
        }

        public void LoadSoundEffect(string soundEffectID)
        {
            if (!Songs.ContainsKey(soundEffectID))
            {
                SoundEffect song = Cloaked.Game.Content.Load<SoundEffect>(soundEffectID);
                SoundEffects.Add(soundEffectID, song);
            }
        }

        public SoundEffect GetSoundEffect(string soundEffectID)
        {
            if (soundEffectID == null) return null;
            LoadSong(soundEffectID);
            return SoundEffects[soundEffectID];
        }
    }
}
