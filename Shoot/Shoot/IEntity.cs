using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public interface IEntity
    {
        Texture2D Texture { get; set; }
        Vector2 Position { get; set; }
        void Load(ContentManager Content);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}