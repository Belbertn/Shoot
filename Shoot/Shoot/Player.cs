using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shoot
{
    public class Player : IEntity
    {
        public Vector2 Position { get; set; }
        public Rectangle Hitbox { get; set; }

        private const float SPEED = 5;
        private Texture2D texture;
        private ContentLoader loader;

        private CollisionActor actor;

        public void Load(ContentLoader contentLoader)
        {
            loader = contentLoader;
            texture = loader.GetSprite("hitman1_hold");

            Position = new Vector2();

            ColliderSetUp();
        }

        public void Update(GameTime gameTime)
        {
            Position = actor.Position;

            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);

            Input();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }

        void Input()
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.W))
            {
                actor.AddAcceleration(new Vector2(0, -1), SPEED);
            }
            else if (keyState.IsKeyDown(Keys.S))
            {
                actor.AddAcceleration(new Vector2(0, 1), SPEED);
            }

            if (keyState.IsKeyDown(Keys.A))
            {
                actor.AddAcceleration(new Vector2(-1, 0), SPEED);
            }
            else if (keyState.IsKeyDown(Keys.D))
            {
                actor.AddAcceleration(new Vector2(1, 0), SPEED);
            }

        }

        void ColliderSetUp()
        {
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);

            actor = new CollisionActor();
            actor.Position = Position;
            actor.Width = texture.Width;
            actor.Height = texture.Height;

            CollisionWorld.AddActor(actor);
        }
    }
}