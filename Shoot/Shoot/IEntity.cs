using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public interface IEntity
    {
        Vector2 Position { get; set; }

        Rectangle Hitbox { get; set; }

        void Load();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}