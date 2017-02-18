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
            actors = new List<CollisionActor>();
        }

        public void Load()
        {

        }

        public void Update(GameTime gameTime)
        {
            foreach (CollisionActor actor in actors)
            {
                actor.Update(gameTime);


            }

            
        }

        public static void AddActor(CollisionActor actor)
        {
            actor.Initialize();
            actors.Add(actor);
        }

        private void CollisionCheck()
        {
            
        }
    }
}