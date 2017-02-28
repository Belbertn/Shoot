using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Shoot
{
    public class ProjectileManager
    {
        private List<IShootable> targets = new List<IShootable>();
        private static List<Projectile> projectiles = new List<Projectile>();

        public void Initialize()
        {
            

            
        }

        public void Update(GameTime gameTime)
        {
            foreach (Projectile proj in projectiles)
            {
                proj.Update(gameTime);
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