﻿using Client.Main.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Main.Objects.Monsters
{
    public class Ghost : MonsterObject
    {
        public Ghost()
        {
            RenderShadow = false;
        }

        public override async Task Load()
        {
            Model = await BMDLoader.Instance.Prepare($"Monster/Monster08.bmd");
            await base.Load();
        }
    }
}
