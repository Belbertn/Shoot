using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Shoot
{
    class AnimationSequence
    {
        private Dictionary<int, Texture2D> sequence = new Dictionary<int, Texture2D>();

        private int currentFrame = 1;

        private bool loop;

        public AnimationSequence(List<string> frameList, bool Loop)
        {
            Getframes(frameList);

            loop = Loop;
        }

        private void Getframes(List<string> frameList)
        {
            int counter = 1;
            foreach (string str in frameList)
            {
                Texture2D temp = ContentLoader.GetSprite(str);

                sequence[counter] = temp; 

                counter++;
            }
        }

        public Texture2D GetCurrentFrame()
        {
            return sequence[currentFrame];
        }

        public int GetFrameCount()
        {
            return sequence.Count;
        }

        public void AdvanceFrame()
        {
            if(currentFrame == sequence.Count)
            {
                currentFrame = 1;
            }
            else
            {
                currentFrame++;
            }
        }
    }
}
