using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Shoot
{
    public class Tile
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle CollisionRectangle { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}