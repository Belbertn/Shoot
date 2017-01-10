using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public class MainGame
    {
        public SpriteBatch Batch { get; private set; }
        
        public ContentLoader Loader { get; private set; }
        public List<IEntity> entities { get; private set; }

        public void Initialize(ContentManager content, SpriteBatch spriteBatch)
        {
            Loader = new ContentLoader();
            Loader.Initialize(content);
            entities = new List<IEntity>();

            Batch = spriteBatch;
        }

        public void Load()
        {
            Loader.LoadAssets("Level1_Texture_List.txt");

            foreach(IEntity entity in entities)
            {
                entity.Load();
            }
        }

        public void UnLoad()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            foreach(IEntity entity in entities)
            {
                entity.Update(gameTime);
            }
        }

        public void Draw()
        {
            Batch.Begin();
            foreach(IEntity entity in entities)
            {
                entity.Draw(Batch);
            }
            Batch.End();
        }
    }
}