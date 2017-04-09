using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    class AnimationSequence
    {
        private Dictionary<int, Texture2D> sequence = new Dictionary<int, Texture2D>();

        public AnimationSequence(string[] frameList)
        {
            Getframes(frameList);
        }

        private void Getframes(string[] frameList)
        {
            for (int i = 0; i < frameList.Length; i++)
            {

            }
        }
    }
}
