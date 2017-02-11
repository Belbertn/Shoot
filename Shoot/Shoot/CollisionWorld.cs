using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Shoot
{
    public class CollisionWorld
    {
        private static List<CollisionActor> actors;
        public void Initialize()
        {

        }

        public void Load()
        {

        }

        public void Update()
        {
            
        }

        public static void AddActor(CollisionActor actor)
        {
            actors.Add(actor);
        }
    }
}