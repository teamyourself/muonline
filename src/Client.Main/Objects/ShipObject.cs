﻿using Client.Data;
using Client.Main.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Main.Objects
{
    [MapObjectType(ModelType.Ship)]
    public class ShipObject : WorldObject
    {
        public ShipObject()
        {
            LightEnabled = false;
        }

        public override async Task Load(GraphicsDevice graphicsDevice)
        {
            Model = await BMDLoader.Instance.Prepare($"Object1/Ship01.bmd");
            await base.Load(graphicsDevice);
        }
    }
}