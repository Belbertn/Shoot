using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public class Player : IEntity
    {
        public Texture2D Texture { get; private set; }

        public Vector2 Position { get; set; }

        private ContentLoader loader;

        public void Load(ContentLoader contentLoader)
        {
            loader = contentLoader;
            Texture = loader.GetSprite("hitman1_hold");

            Position = new Vector2(5, 5);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}