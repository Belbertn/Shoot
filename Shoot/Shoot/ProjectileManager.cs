using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public class ProjectileManager
    {
        private List<IShootable> targets = new List<IShootable>();
        private static List<Projectile> projectiles = new List<Projectile>();

        private SpriteBatch spriteBatch;
        public void Initialize(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public void Update(GameTime gameTime)
        {
            foreach (Projectile proj in projectiles)
            {
                proj.Update(gameTime);
            }
        }

        public void Draw()
        {
            foreach (Projectile proj in projectiles)
            {
                proj.Draw(spriteBatch);
            }
        }

        private void CollisionCheck()
        {
            foreach (Projectile proj in projectiles)
            {

            }
        }

        public static void AddProjectile(Vector2 Position, Vector2 Direction, float Speed, int Damage)
        {
            Rectangle tempHitbox = new Rectangle((int)Position.X, (int)Position.Y, 2, 2);

            Projectile temp = new Projectile();
            temp.Initialize(tempHitbox, Position, Direction, Speed, Damage);

            projectiles.Add(temp);
        }

        public void AddTargetToList(IShootable target)
        {
            targets.Add(target);
        } 
    }
}