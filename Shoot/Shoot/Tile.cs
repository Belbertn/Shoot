using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Shoot
{
    public class Tile : IEntity
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle CollisionRectangle { get; set; }

        public void Load(ContentLoader contentLoader)
        {
            CollisionRectangle = new Rectangle((int)Position.X, 
                                            (int)Position.Y,
                                            Texture.Width,
                                            Texture.Height);
                                
            PhysicsWorld.AddStaticEntity(this);
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