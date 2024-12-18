﻿using Client.Data.OZB;
using Client.Data.Texture;
using System.ComponentModel;

namespace Client.Editor
{
    public partial class CTextureEditor : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TextureData Data { get; private set; }

        public CTextureEditor()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.White;
        }

        public async void Init(string filePath)
        {
            var ext = Path.GetExtension(filePath).ToLowerInvariant();

            switch (ext)
            {
                case ".ozj":
                    {
                        var reader = new OZJReader();
                        Data = await reader.Load(filePath);
                        SetData();
                    }
                    break;
                case ".ozt":
                    {
                        var reader = new OZTReader();
                        Data = await reader.Load(filePath);
                        SetData();
                    }
                    break;
                case ".ozb":
                    {
                        var reader = new OZBReader();
                        var texture = await reader.Load(filePath);
                        Data = new TextureData
                        {
                            Components = 4,
                            Width = texture.Width,
                            Height = texture.Height,
                            Data = texture.Data.SelectMany(x => new byte[] { x.R, x.G, x.B, x.A }).ToArray()
                        };
                    }
                    break;
                case ".ozd":
                    {
                        var reader = new OZDReader();
                        Data = await reader.Load(filePath);
                        SetData();
                    }
                    break;
                case ".ozp":
                    {
                        var reader = new OZPReader();
                        Data = await reader.Load(filePath);
                        SetData();
                    }
                    break;
                default:
                    throw new NotImplementedException($"Extension {ext} not supported");
            }
        }

        public void SetData()
        {
            var textureData = Data;

            var bitmap = new Bitmap((int)textureData.Width, (int)textureData.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            for (int y = 0; y < textureData.Height; y++)
            {
                for (int x = 0; x < textureData.Width; x++)
                {
                    int index = (y * (int)textureData.Width + x) * textureData.Components;

                    byte r = textureData.Data[index];
                    byte g = textureData.Data[index + 1];
                    byte b = textureData.Data[index + 2];
                    byte a = (textureData.Components == 4) ? textureData.Data[index + 3] : (byte)255; // Si son RGB, se asume A = 255

                    Color color = Color.FromArgb(a, r, g, b);

                    bitmap.SetPixel(x, y, color);
                }
            }

            pictureBox1.Image = bitmap;
        }

        public void Export()
        {
            var bitmap = (Bitmap)pictureBox1.Image;
            using (var sfd = new SaveFileDialog())
            {
                var isPng = Data.Components == 4;
                sfd.Filter = isPng ? "PNG|*.png" : "JPG|*.jpg";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bitmap.Save(sfd.FileName, isPng ? System.Drawing.Imaging.ImageFormat.Png : System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }
    }
}
