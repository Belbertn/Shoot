﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoot
{
    class Animation
    {
        private string[] assetList;

        public Animation(string assetFile)
        {
            assetList = ContentLoader.GetAssetFile(assetFile);
        }

        private void CreateAnimationSequences()
        {

        }
    }
}
