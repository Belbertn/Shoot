using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public interface IGameState
    {
        ContentLoader Loader { get; }
        InputManager Input { get; }
        List<IEntity> Entities { get; }
        void Initialize(ContentLoader loader, InputManager inputManager, SpriteBatch SpriteBatch);
        void Load();
        void Update(GameTime gameTime);
        void Draw();
    }
}