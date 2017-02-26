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
                        Rectangle overlap = Rectangle.Intersect(actor.Rectangle, obj.Rect);

                        if (overlap.Width < overlap.Height)
                        {
                            //Collision on Light
                            if (actor.Rectangle.Left < obj.Rect.Left)
                            {
                                actor.Velocity = new Vector2(0, actor.Velocity.Y);
                                actor.Position = new Vector2(actor.Position.X - overlap.Width, actor.Position.Y);
                            }
                            //Collision on Left
                            if (actor.Rectangle.Right > obj.Rect.Right)
                            {
                                actor.Velocity = new Vector2(0, actor.Velocity.Y);
                                actor.Position = new Vector2(actor.Position.X + overlap.Width, actor.Position.Y);
                            }
                        }

                        if (overlap.Height < overlap.Width)
                        {
                            if (actor.Rectangle.Top < obj.Rect.Top)
                            {
                                actor.Velocity = new Vector2(actor.Velocity.X, 0);
                                actor.Position = new Vector2(actor.Position.X, actor.Position.Y - overlap.Height);
                            }
                            if (actor.Rectangle.Bottom > obj.Rect.Bottom)
                            {
                                actor.Velocity = new Vector2(actor.Velocity.X, 0);
                                actor.Position = new Vector2(actor.Position.X, actor.Position.Y + overlap.Height);
                            }
                        }                       
                    }
                }
            }
        }
    }
}