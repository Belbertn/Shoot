using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public class MainGame
    {   
        public ContentLoader Loader { get; private set; }

        public IGameState gameState { get; private set; }

        public void Initialize(ContentManager content, SpriteBatch spriteBatch)
        {
            Loader = new ContentLoader();
            Loader.Initialize(content);
            
            gameState = new InGame();
            gameState.Initialize(Loader, spriteBatch);
        }

        public void Load()
        {
            gameState.Load();
        }

        public void UnLoad()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            gameState.Update(gameTime);
        }

        public void Draw()
        {
            gameState.Draw();
        }
    }
}