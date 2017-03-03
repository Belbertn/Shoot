using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shoot
{
    public class Player : IEntity, IShootable
    {
        public Vector2 Position { get; set; }
        public Rectangle Hitbox { get; set; }

        private float angle = 0;
        private Vector2 origin;

        private const float SPEED = 40;
        private Texture2D texture;

        private CollisionActor actor;

        public int Health { get; set; }

        private PlayerIndex index;

        public Player(PlayerIndex Index)
        {
            index = Index;
        }

        public void Load()
        {       
            texture = ContentLoader.GetSprite("hitman1_hold");

            Position = new Vector2();

            ColliderSetUp();

            Health = 100;

            origin = new Vector2(texture.Width/2, texture.Height/2);
        }

        public void Update(GameTime gameTime)
        {
            Position = actor.Position;

            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);

            Input();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, angle, origin, 1f, SpriteEffects.None, 1);
        }

        private void Input()
        {
            if(!GamePad.GetState(index).IsConnected)
            {
                KeyboardInput();
            }
            else
            {
                GamePadInput();
            }
        }

        private void ColliderSetUp()
        {
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);

            actor = new CollisionActor();
            actor.Position = Position;
            actor.Width = texture.Width;
            actor.Height = texture.Height;

            CollisionWorld.AddActor(actor);
        }

        public void TakeDamage(int Damage)
        {
            Console.WriteLine(Health);
            Health -= Damage;
        }

        private void GamePadInput()
        {
            Vector2 direction = InputManager.GetLeftThumbStick(index);
            direction.Y *= -1;
            actor.AddAcceleration(direction, SPEED);

            if (InputManager.GetRightThumbStick(index) != new Vector2(0, 0))
            {
                Vector2 angleInput = InputManager.GetRightThumbStick(index);
                angle = (float)Math.Atan2(angleInput.X, angleInput.Y);
            }

            if (InputManager.GetButtonDown(index, Buttons.RightTrigger))
            {
                Vector2 projectileDir = InputManager.GetRightThumbStick(index);
                projectileDir.Y *= -1;
                ProjectileManager.AddProjectile(new Vector2(Position.X + projectileDir.X, Position.Y + projectileDir.Y), projectileDir, 10, 10);
            }
        }

        private void KeyboardInput()
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

            if (keyState.IsKeyDown(Keys.Space))
            {
                ProjectileManager.AddProjectile(new Vector2(Position.X + 50, Position.Y + 15), new Vector2(1, 0), 10, 10);
            }
        }
    }
}