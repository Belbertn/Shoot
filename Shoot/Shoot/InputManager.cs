using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Shoot
{
    public class InputManager
    {
        private static Dictionary<PlayerIndex,Controller> controllers;

        public void Initialize()
        {
            controllers = new Dictionary<PlayerIndex,Controller>();

            for (PlayerIndex i = PlayerIndex.One; i <= PlayerIndex.Four; i++)
            {
                if (GamePad.GetState(i).IsConnected)
                {
                    controllers[i] = new Controller(i);
                }
            }
        }

        public void Update()
        {
            for (PlayerIndex i = PlayerIndex.One; (int)i < controllers.Count; i++)
            {
                controllers[i].Update();
            }
            
            CheckConnectionStatus();
        }

        private void CheckConnectionStatus()
        {
            ConnectNew();
            RemoveDisconnected();
        }

        private void ConnectNew()
        {
            for (PlayerIndex i = PlayerIndex.One; i <= PlayerIndex.Four; i++)
            {
                if (GamePad.GetState(i).IsConnected && controllers.Count <= 3)
                {
                    if (!controllers.ContainsKey(i))
                    {
                        controllers[i] = new Controller(i);
                    }
                }
            }
        }

        private void RemoveDisconnected()
        {
            for (PlayerIndex i = PlayerIndex.One; (int)i < controllers.Count; i ++)
            {
                if (!GamePad.GetState(controllers[i].Index).IsConnected)
                {
                    controllers.Remove(i);
                }
            }
        }

        public static bool GetButtonDown(PlayerIndex index, Buttons button)
        {
            if (controllers.ContainsKey(index))
            {
                return controllers[index].currentGamePadState.IsButtonDown(button) && controllers[index].previousGamePadState.IsButtonUp(Buttons.A);
            }
            else
            { 
                return false;
            }
        }

        public static bool GetButtonUp(PlayerIndex index, Buttons button)
        {
            if (controllers.ContainsKey(index))
            {
                return controllers[index].currentGamePadState.IsButtonUp(button) && controllers[index].previousGamePadState.IsButtonDown(Buttons.A);
            }
            else
            { 
                return false;
            }
        }

        public static bool GetButton(PlayerIndex index, Buttons button)
        {
            if (controllers.ContainsKey(index))
            {
                return controllers[index].currentGamePadState.IsButtonDown(button);
            }
            else
            { 
                return false;
            }
        }

        public static Vector2 GetLeftThumbStick(PlayerIndex index)
        {
            if (controllers.ContainsKey(index))
            {
                return controllers[index].currentGamePadState.ThumbSticks.Left;
            }
            else
            {
                return new Vector2(0, 0);
            }
        }

        public static Vector2 GetRightThumbStick(PlayerIndex index)
        {
            if (controllers.ContainsKey(index))
            {
                return controllers[index].currentGamePadState.ThumbSticks.Right;
            }
            else
            {
                return new Vector2(0, 0);
            }
        }
    }
}