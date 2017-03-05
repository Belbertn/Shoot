using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public class Projectile
    {
        public Rectangle hitbox { get; set; }
        public ShootableLayer Layer { get; private set; }

        public Vector2 Position { get; set; }

        public int Damage { get; set; }
        
        private Vector2 velocity = new Vector2();

        private Texture2D texture;

        private float angle = 0;
        private Vector2 origin;

        public bool isDestroyed = false;

        public void Initialize(Rectangle HitBox, Vector2 Position, Vector2 Direction, float Speed, int Damage, ShootableLayer layer)
        {
            hitbox = HitBox;
            this.Position = Position;

            velocity = new Vector2();
            velocity += Direction * Speed * Speed;

            this.Damage = Damage;

            Layer = layer;

            texture = ContentLoader.GetSprite("Projectile_1");

            origin = new Vector2(texture.Width / 2, texture.Height / 2);

            Direction.Y *= -1;
            angle = (float)Math.Atan2(Direction.X, Direction.Y);
        }

        public void Update(GameTime gameTime)
        {
            Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            hitbox = new Rectangle((int)Position.X, (int)Position.Y, hitbox.Width, hitbox.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, angle, origin, 1f, SpriteEffects.None, 1);
        }
    }
}