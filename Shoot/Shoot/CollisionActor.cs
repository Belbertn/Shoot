using Microsoft.Xna.Framework;

namespace Shoot
{
    public class CollisionActor
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle Rectangle { get; set;}

        private const float FRICTION = 0.8F; 

        public void Initialize()
        {
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        }

        public void Update(GameTime gameTime)
        {
            Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

            Velocity *= FRICTION;
        }

        public void AddAcceleration(Vector2 Direction, float Acc)
        {
            Velocity += Direction * Acc;
        }
    }
}