using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Shoot
{
    class StopWatch
    {
        public float Time { get; private set; }

        public StopWatch()
        {

        }
        
        public void Update(GameTime gameTime)
        {
            Time += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Reset()
        {
            Time = 0;
        }
    }
}
