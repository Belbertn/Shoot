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

        private int currentFrame;

        public AnimationSequence(List<string> frameList)
        {
            Getframes(frameList);
        }

        private void Getframes(List<string> frameList)
        {
            int counter = 0;
            foreach (string str in frameList)
            {
                Texture2D temp = ContentLoader.GetSprite(str);

                sequence[counter] = temp;

                counter++;
            }
        }

        public Texture2D GetCurrentFrame()
        {

        }

        public void AdvanceFrame()
        {

        }
    }
}
