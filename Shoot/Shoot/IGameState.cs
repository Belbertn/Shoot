using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public interface IGameState
    {
        ContentLoader Loader { get; }
        List<IEntity> entities { get; }
        void Initialize(ContentLoader loader, SpriteBatch SpriteBatch);
        void Load();
        void Update(GameTime gameTime);
        void Draw();
    }
}