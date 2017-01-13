using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public class Map
    {
        public List<Tile> level { get; private set; }

        private ContentLoader contentLoader;
        private SpriteBatch spriteBatch;

        public void Initialize(ContentLoader loader, SpriteBatch Batch)
        {
            level = new List<Tile>();
            contentLoader = loader;
            spriteBatch = Batch;
        }

        public void Load()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw()
        {

        }
    }
}