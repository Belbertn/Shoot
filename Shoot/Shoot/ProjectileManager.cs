using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Shoot
{
    public class ProjectileManager
    {
        private List<IEntity> entities;
        private List<Projectile> projectiles;

        public void Initialize(List<IEntity> Entities)
        {
            entities = Entities;

            projectiles = new List<Projectile>();
        }

        public void Update()
        {

        }
    }
}