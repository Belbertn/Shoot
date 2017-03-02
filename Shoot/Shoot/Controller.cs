using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Shoot
{
    public class Controller
    {
        public PlayerIndex Index { get; private set; }

        private GamePadState currentGamePadState;
        private GamePadState previousGamePadState;

        public Controller(PlayerIndex index)
        {
            Index = index;

            currentGamePadState = GamePad.GetState(Index);
            previousGamePadState = currentGamePadState;
        }

        public void Update()
        {
            currentGamePadState = GamePad.GetState(Index);
        }

        public void LateUpdate()
        {
            previousGamePadState = currentGamePadState;
        }
    }
}