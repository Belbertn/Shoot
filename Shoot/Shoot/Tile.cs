using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Shoot
{
    public class Tile : IEntity
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public CollisionObject colObject { get; set; }

        public void Load(ContentLoader contentLoader)
        {
            colObject = new CollisionObject();
            colObject.Position = Position;
            colObject.Width = Texture.Width;
            colObject.Height = Texture.Height;

            CollisionWorld.AddObject(colObject);
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