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

        private ProjectileManager projectileManager = new ProjectileManager();

        public List<IEntity> Entities { get; private set; }

        public void Initialize(ContentLoader loader, SpriteBatch Batch)
        {
            Loader = loader;
            spriteBatch = Batch;

            World = new CollisionWorld();
            World.Initialize();

            Level = new Map();
            Level.Initialize(spriteBatch);

            projectileManager.Initialize(spriteBatch);

            Entities = new List<IEntity>();

            SetUpPlayers();
        }

        public void Load()
        {
            Loader.LoadAssets(AssetList.Level1);

            World.Load();

            Level.Load();
            
            foreach (IEntity entity in Entities)
            {
                entity.Load();
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

            projectileManager.Update(gameTime);

            CheckForDeath();
        }

        public void Draw()
        {
            spriteBatch.Begin();
            Level.Draw();
            projectileManager.Draw();
            
            foreach (IEntity entity in Entities)
            {
                entity.Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        private void SetUpPlayers()
        {
            Player temp = new Player();
            Entities.Add(temp);
            ProjectileManager.AddTargetToList(temp);
        }

        private void CheckForDeath()
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                if (Entities[i].Health <= 0)
                {
                    Entities.Remove(Entities[i]);
                }
            }
        }
    }
}