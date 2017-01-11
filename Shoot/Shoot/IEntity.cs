using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public interface IEntity
    {
        Texture2D Texture { get; }
        Vector2 Position { get; set; }

        void Load(ContentLoader contentLoader);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}