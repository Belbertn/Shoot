using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Shoot
{
    class Player : IEntity, IShootable
    {
        public Vector2 Position { get; set; }

        public Rectangle Hitbox { get; set; }
        public ShootableLayer Layer { get; private set; }

        private float angle = 0;
        private Vector2 origin;
        Vector2 aimDirection = new Vector2();

        private const float SPEED = 40;
        private Texture2D texture;

        private CollisionActor actor;

        public int Health { get; set; }

        private PlayerIndex index;

        private CountDownTimer shootDelay;
        private const float DELAY = 2F;

        public Player(PlayerIndex Index)
        {
            index = Index;

            Layer = (ShootableLayer)Index;

            shootDelay = new CountDownTimer(DELAY);
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

            shootDelay.Update(gameTime);
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

            ProjectileManager.AddTargetToList(this);
        }

        public void TakeDamage(int Damage)
        {
            Health -= Damage;
        }

        public PlayerIndex GetPlayerIndex()
        {
            return index;
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

            if (InputManager.GetButtonDown(index, Buttons.RightTrigger) && shootDelay.Delay <= 0)
            {
                Vector2 firePoint = new Vector2();
                firePoint.X = (float)Math.Cos(angle -90) * 25 + Position.X;
                firePoint.Y = (float)Math.Sin(angle -90) * 25 + Position.Y;

                if (InputManager.GetRightThumbStick(index) != new Vector2(0, 0))
                {
                    aimDirection = InputManager.GetRightThumbStick(index);
                    aimDirection.Y *= -1;
                }

                ProjectileManager.AddProjectile(firePoint, Vector2.Normalize(aimDirection), 10, 10, Layer);

                shootDelay = new CountDownTimer(DELAY);
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
                ProjectileManager.AddProjectile(Position, new Vector2(1, 0), 10, 10, Layer);
            }
        }
    }
}