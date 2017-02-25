using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Shoot
{
    public class CollisionWorld
    {
        private static List<CollisionActor> actors;
        private static List<CollisionObject> objects;
        public void Initialize()
        {
            actors = new List<CollisionActor>();
            objects = new List<CollisionObject>();
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

            CollisionCheck();
        }

        public static void AddActor(CollisionActor actor)
        {
            actor.Initialize();
            actors.Add(actor);
        }

        public static void AddObject(CollisionObject colObject)
        {
            colObject.Inititalize();
            objects.Add(colObject);
        }

        private void CollisionCheck()
        {
            foreach (CollisionActor actor in actors)
            {
                foreach (CollisionObject obj in objects)
                {
                    if (actor.Rectangle.Intersects(obj.Rect))
                    {
                        if (actor.Rectangle.Center.X < obj.Rect.Center.X)
                        {
                            actor.Velocity = new Vector2(0, actor.Velocity.Y);
                            actor.Position = new Vector2(actor.Position.X - 0.2f, actor.Position.Y);
                        }
                        if (actor.Rectangle.Center.X > obj.Rect.Center.X)
                        {
                            actor.Velocity = new Vector2(0, actor.Velocity.Y);
                            actor.Position = new Vector2(actor.Position.X + 0.2f, actor.Position.Y);
                        }
                        if (actor.Rectangle.Center.Y < obj.Rect.Center.Y)
                        {
                            actor.Velocity = new Vector2(actor.Velocity.X, 0);
                            actor.Position = new Vector2(actor.Position.X, actor.Position.Y - 0.2f);
                        }
                        if (actor.Rectangle.Center.Y > obj.Rect.Center.Y)
                        {
                            actor.Velocity = new Vector2(actor.Velocity.X, 0);
                            actor.Position = new Vector2(actor.Position.X, actor.Position.Y + 0.2f);
                        }
                    }
                }
            }
        }
    }
}