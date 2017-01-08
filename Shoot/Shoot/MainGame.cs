using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public class MainGame
    {
        public ContentManager Content { get; private set; }
        public SpriteBatch Batch { get; private set; }

        public List<IEntity> entities { get; private set; }

        public void Load(ContentManager content, SpriteBatch spriteBatch)
        {
            Content = content;
            Batch = spriteBatch;

            foreach(IEntity entity in entities)
            {
                entity.Load(Content);
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