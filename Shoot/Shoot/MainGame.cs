using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public class MainGame
    {
        public ContentManager Content { get; private set; }
        public SpriteBatch Batch { get; private set; }

        public IEntity entities { get; private set; }

        public void Load(ContentManager content, SpriteBatch spriteBatch)
        {
            Content = content;
            Batch = spriteBatch;
        }

        public void UnLoad()
        {
            
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw()
        {
            Batch.Begin();

            Batch.End();
        }
    }
}