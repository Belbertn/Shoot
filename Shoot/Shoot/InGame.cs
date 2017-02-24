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
        public Map Level { get; private set; }
        public CollisionWorld World { get; private set; }

        public List<IEntity> Entities { get; private set; }

        public void Initialize(ContentLoader loader, SpriteBatch Batch)
        {
            Loader = loader;
            spriteBatch = Batch;

            World = new CollisionWorld();
            World.Initialize();

            Level = new Map();
            Level.Initialize(Loader, spriteBatch);

            Entities = new List<IEntity>();
            Entities.Add(new Player());
        }

        public void Load()
        {
            Loader.LoadAssets(AssetList.Level1);

            World.Load();

            Level.Load();
            
            foreach (IEntity entity in Entities)
            {
                entity.Load(Loader);
            }
        }

        public void Update(GameTime gameTime)
        {
            World.Update(gameTime);

            Level.Update(gameTime);

            foreach (IEntity entity in Entities)
            {
                entity.Update(gameTime);
            }
        }

        public void Draw()
        {
            spriteBatch.Begin();
            Level.Draw();
            
            foreach (IEntity entity in Entities)
            {
                entity.Draw(spriteBatch);
            }
            spriteBatch.End();
        }
    }
}