using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Shoot
{
    public class Tile : IEntity, IShootable
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle Hitbox { get; set; }

        public CollisionObject colObject { get; set; }

        public void Load()
        {
            colObject = new CollisionObject();
            colObject.Position = Position;
            colObject.Width = Texture.Width;
            colObject.Height = Texture.Height;

            CollisionWorld.AddObject(colObject);

            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        public void Update(GameTime gameTime)
        {
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void TakeDamage(int Damage)
        {

        }
    }
}