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
    class Animation
    {
        private string[] assetList;

        private Dictionary<string, AnimationSequence> animations = new Dictionary<string, AnimationSequence>();

        private bool loop;

        private string currentAnimation;

        private CountDownTimer timer;

        public Animation(string assetFile, bool Loop)
        {
            assetList = ContentLoader.GetAssetFile(assetFile);

            loop = Loop;

            CreateAnimationSequences(0);

            timer = new CountDownTimer(1 / 4);
        }

        public void Update(GameTime gameTime)
        {
            timer.Update(gameTime);

            Debug.WriteLine(1F / (float)animations[currentAnimation].GetFrameCount());

            if(timer.Delay <= 0)
            {
                UpdateFrame();
            }
        }

        public Texture2D GetFrame()
        {
            return animations[currentAnimation].GetCurrentFrame();
        }

        public void SetAnimation(string animationName)
        {
            currentAnimation = animationName;
        }

        private void UpdateFrame()
        {
            animations[currentAnimation].AdvanceFrame();
            timer = new CountDownTimer(1F / (float)animations[currentAnimation].GetFrameCount());
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
                        string[] animationName = new string[2];
                        for (int j = i; j < assetList.Length; j++)
                        {
                            if (!assetList[j].Contains("animation"))
                            { 
                                temp.Add(assetList[j]);
                            }
                            else if (assetList[j].Contains("animation"))
                            {
                                animationName = assetList[i].Split('_');
                                
                                CreateAnimationSequences(j + 1);
                            }
                        }
                        CreateNewAnimationSequence(animationName[0], temp);
                    }
                }
            }
        }

        private void CreateNewAnimationSequence(string name, List<string> sequence)
        {
            AnimationSequence temp = new AnimationSequence(sequence, loop);
            animations.Add(name, temp);
        }
    }
}
