using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Shoot
{
    public class InputManager
    {
        private List<Controller> controllers;
        public void Initialize()
        {
            controllers = new List<Controller>();

            for (PlayerIndex i = PlayerIndex.One; i <= PlayerIndex.Four; i++)
            {
                if (GamePad.GetState(i).IsConnected)
                {
                    controllers.Add(new Controller(i));
                }
            }
        }

        public void Update()
        {
            foreach (Controller controller in controllers)
            {
                controller.Update();
            }

            CheckConnectionStatus();
        }

        public void LateUpdate()
        {
            foreach (Controller controller in controllers)
            {
                controller.LateUpdate();
            }
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
                    foreach (Controller controller in controllers)
                    {
                        if (controller.Index != i)
                        {
                            controllers.Add(new Controller(i));
                        }
                    }
                }
            }
        }

        private void RemoveDisconnected()
        {
            for (int i = 0; i < controllers.Count; i ++)
            {
                if (!GamePad.GetState(controllers[i].Index).IsConnected)
                {
                    controllers.Remove(controllers[i]);
                }
            }
        }
    }
}