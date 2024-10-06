﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Main.Objects.Effects
{
    public class LightEffect : SpriteObject
    {
        public override string TexturePath => "Effect/flare01.jpg";

        public LightEffect()
        {
            BlendState = BlendState.Additive;
            LightEnabled = true;
            Light = new Vector3(1f, 0.2f, 0f);
        }
    }
}
