﻿using Client.Data;
using Client.Main.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Threading.Tasks;

namespace Client.Main.Objects
{
    [MapObjectType(ModelType.Logo)]
    public class LogoObject : WorldObject
    {
        public LogoObject()
        {
            LightEnabled = false;
        }

        public override async Task Load(GraphicsDevice graphicsDevice)
        {
            Model = await BMDLoader.Instance.Prepare("Logo/Logo01.bmd");
            await base.Load(graphicsDevice);
        }
    }
}