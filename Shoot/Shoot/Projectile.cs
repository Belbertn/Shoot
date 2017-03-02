using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public class Projectile
    {
        public Rectangle hitbox { get; set; }

        public Vector2 Position { get; set; }

        public int Damage { get; set; }
        
        private Vector2 velocity = new Vector2();

        private Texture2D texture;

        public bool isDestroyed = false;

        public void Initialize(Rectangle HitBox, Vector2 Position, Vector2 Direction, float Speed, int Damage)
        {
            hitbox = HitBox;
            this.Position = Position;
            
            velocity = new Vector2();
            velocity += Direction * Speed * Speed;

            this.Damage = Damage;

            texture = ContentLoader.GetSprite("Projectile_1");
        }

        public void Update(GameTime gameTime)
        {
            Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            hitbox = new Rectangle((int)Position.X, (int)Position.Y, hitbox.Width, hitbox.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }
    }
}