using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoot
{
    class CountDownTimer
    {
        public float Delay { get; private set; }

        public CountDownTimer(float delay)
        {
            Delay = delay;
        }

        public void Update(GameTime gameTime)
        {
            float timer = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Delay -= timer;
        }
    }
}
