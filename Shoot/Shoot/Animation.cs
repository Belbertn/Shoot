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

            CreateAnimationSequences(0);
        }

        

        public void Update(GameTime gameTime)
        {

        }

        public Texture2D GetFrame()
        {

        }

        private void CreateAnimationSequences(int startingPointInFile)
        {
            for (int i = startingPointInFile; i < assetList.Length; i++)
            {
                if (assetList[i].Contains("animation"))
                {
                    if (!animations.ContainsKey(assetList[i]))
                    {
                        List<string> temp = new List<string>();
                        for (int j = i + 1; j < assetList.Length; j++)
                        {
                            if (!assetList[j].Contains("animation"))
                            {
                                temp.Add(assetList[j]);
                            }
                            else if (assetList[j].Contains("animation"))
                            {
                                CreateNewAnimationSequence(assetList[i], temp);
                                CreateAnimationSequences(j);
                            }
                        }
                    }
                }
            }
        }

        private void CreateNewAnimationSequence(string name, List<string> sequence)
        {
            AnimationSequence temp = new AnimationSequence(sequence);
            animations.Add(name, temp);
        }
    }
}
