using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public class InGame : IGameState
    {
        public SpriteBatch Batch { get; private set; }
        public ContentLoader Loader { get; private set; }

        public List<IEntity> entities { get; private set; }

        public void Initialize(ContentLoader loader, SpriteBatch spriteBatch)
        {
            Loader = loader;
            Batch = spriteBatch;

            entities = new List<IEntity>();
        }

        public void Load()
        {
            Loader.LoadAssets(AssetList.Level1);
            entities.Add(new Player());
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
            Batch.Begin();
            foreach (IEntity entity in entities)
            {
                entity.Draw(Batch);
            }
            Batch.End();
        }
    }
}