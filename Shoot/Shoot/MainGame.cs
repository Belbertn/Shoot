using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public class MainGame
    {   
        public ContentLoader Loader { get; private set; }

        public InputManager Input { get; private set;}

        public IGameState gameState { get; private set; }

        public void Initialize(ContentManager content, SpriteBatch spriteBatch)
        {
            Loader = new ContentLoader();
            Loader.Initialize(content);

            Input = new InputManager();
            Input.Initialize();
            
            gameState = new InGame();
            gameState.Initialize(Loader, Input, spriteBatch);
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
            Input.Update();

            gameState.Update(gameTime);         
        }

        public void Draw()
        {
            gameState.Draw();
        }
    }
}