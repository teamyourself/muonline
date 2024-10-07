﻿using Client.Data;
using Client.Main.Controls;
using Client.Main.Controls.UI;
using Client.Main.Objects.Effects;
using Client.Main.Objects.Login;
using Client.Main.Objects.Lorencia;
using Client.Main.Objects.Particles;
using Client.Main.Objects.Particles.Effects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Main.Scenes
{
    public class TestScene : BaseScene
    {
        public WorldControl World { get; private set; }

        public TestScene()
        {
            Controls.Add(World = new WorldControl(-1));
            Camera.Instance.Position = new Vector3(10, 10, 10);
            Camera.Instance.Target = new Vector3(1, 1, 1);
        }

        public override void AfterLoad()
        {
            base.AfterLoad();

            // await World.AddObject(new StatueTorchObject() { World = World });

            //MessageWindow.Show("Press the button to change scene", () =>
            //{
            //    MuGame.Instance.ChangeScene<LoginScene>();
            //});

            var nonEventGroup = new ServerGroupSelector(false)
            {
                X = 100
            };

            for (byte i = 0; i < 5; i++)
                nonEventGroup.AddServer(i, $"Server {i + 1}");

            var eventGroup = new ServerGroupSelector(true)
            {
                X = 400
            };

            for (byte i = 0; i < 5; i++)
                eventGroup.AddServer(i, $"Event {i + 1}");

            nonEventGroup.SelectedIndexChanged += (sender, e) =>
            {
                eventGroup.UnselectServer();
            };

            eventGroup.SelectedIndexChanged += (sender, e) =>
            {
                nonEventGroup.UnselectServer();
            };

            Controls.Add(nonEventGroup);
            Controls.Add(eventGroup);
        }

        public override void Update(GameTime time)
        {
            Camera.Instance.Position = new Vector3(300, 300, 300);
            Camera.Instance.Target = new Vector3(150, 150, 150);

            base.Update(time);
        }
    }
}
