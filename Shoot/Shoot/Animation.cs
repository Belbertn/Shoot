using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    class Animation
    {
        private string[] assetList;

        private Dictionary<string, AnimationSequence> animations = new Dictionary<string, AnimationSequence>();

        public Animation(string assetFile)
        {
            assetList = ContentLoader.GetAssetFile(assetFile);
        }

        private void CreateAnimationSequences()
        {
            for(int i = 0; i < assetList.Length; i++)
            {
                if(assetList[i].Contains("animation"))
                {
                    string[] temp = assetList[i].Split();
                }
            }
        }

        public void Update(GameTime gameTime)
        {

        }

        public Texture2D GetFrame()
        {

        }
    }
}
