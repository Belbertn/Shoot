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

        public void Load(ContentManager Content)
        {
            content = Content;
        }

        public Texture2D GetSprite(string name)
        {
            
        }
    }
}