using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Shoot
{
    public class PhysicsWorld
    {
        public static List<IEntity> StaticEntities { get; private set; }

        public void Initialize(ref List<IEntity> entities)
        {
            StaticEntities = entities;
        }

        public void Load()
        {

        }

        public void Update()
        {
            
        }

        public static void AddStaticEntity(IEntity entity)
        {
            StaticEntities.Add(entity);
        }
    }
}