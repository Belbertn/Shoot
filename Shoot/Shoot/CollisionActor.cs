using Microsoft.Xna.Framework;

namespace Shoot
{
    public class CollisionActor
    {
        public Vector2 Position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private Vector2 velocity;
        
        private Rectangle rectangle;

        public void Initialize()
        {
            rectangle = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        }
    }
}