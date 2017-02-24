using Microsoft.Xna.Framework;

namespace Shoot
{
    public class CollisionObject
    {
        public Vector2 Position { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle Rect { get; set; }

        public void Inititalize()
        {
            Rect = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        }
    }
}