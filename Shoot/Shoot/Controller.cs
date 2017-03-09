using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Shoot
{
    public class Controller
    {
        public PlayerIndex Index { get; private set; }

        public GamePadState currentGamePadState { get; private set; }
        public GamePadState previousGamePadState { get; private set; }

        public Controller(PlayerIndex index)
        {
            Index = index;

            

            currentGamePadState = GamePad.GetState(Index, GamePadDeadZone.Circular);
            previousGamePadState = GamePad.GetState(Index, GamePadDeadZone.Circular);
        }

        public void Update()
        {
            previousGamePadState = currentGamePadState;
            currentGamePadState = GamePad.GetState(Index, GamePadDeadZone.Circular);
        }
    }
}