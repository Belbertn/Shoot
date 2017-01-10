using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public class ContentLoader
    {
        private Dictionary<string,Texture2D> Sprites { get; set; }
        private ContentManager content;

        public void Initialize(ContentManager Content)
        {
            content = Content;
        }

        public void LoadAssets(string filename)
        {
            string[] lines = ReadFile(filename);

            if(filename.Contains("Texture"))
            {
                LoadSprites(lines);
            }
        }

        public Texture2D GetSprite(string name)
        {
            if(Sprites.ContainsKey("name"))
            {
                return Sprites["name"];
            }
            else if(Sprites.Count <= 0)
            {
                throw new System.ArgumentException("Dictionary is empty at this time. Maybe it's not finished loading");
            }
            else
            {
                throw new System.ArgumentException( name + "Sprite does not exist");
            }     
        }

        private string[] ReadFile(string TextFile)
        {
            string[] lines = File.ReadAllLines(TextFile);

            return lines;
        }
        
        private void LoadSprites(string[] lines)
        {
            for(int i = 0; i < lines.Length; i++)
            {
                Sprites.Add(lines[i], content.Load<Texture2D>(lines[i]));
            }
        }
    }
}