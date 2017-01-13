using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public class InGame : IGameState
    {
        public SpriteBatch spriteBatch;
        public ContentLoader Loader { get; private set; }

        public List<IEntity> entities { get; private set; }

        public void Initialize(ContentLoader loader, SpriteBatch Batch)
        {
            Loader = loader;
            spriteBatch = Batch;

            entities = new List<IEntity>();
        }

        public void Load()
        {
            Loader.LoadAssets(AssetList.Level1);
            
            foreach (IEntity entity in entities)
            {
                entity.Load(Loader);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (IEntity entity in entities)
            {
                entity.Update(gameTime);
            }
        }

        public void Draw()
        {
            spriteBatch.Begin();
            foreach (IEntity entity in entities)
            {
                entity.Draw(spriteBatch);
            }
            spriteBatch.End();
        }
    }
}