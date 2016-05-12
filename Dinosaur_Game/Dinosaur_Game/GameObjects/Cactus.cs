using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;

namespace Dinosaur_Game
{
    class Cactus : Sprite
    {
        public static Random Random = new Random();

        public static List<Texture2D> CactusTextures = new List<Texture2D>() { null, null, null, null, null };
        public static List<Cactus> CactusList = new List<Cactus>();

        public Cactus()
        {
        }

        public Cactus(ContentManager content, Vector2 position)
        {
            this.InitializeList(content);

            int random = Random.Next(0,5);
            this.Texture = CactusTextures[random];

            switch (random)
            {
                case 0: position.Y = 99; break;
                case 1: position.Y = 115 ; break;
                case 2: position.Y = 112; break;
                case 3: position.Y = 114; break;
                case 4: position.Y = 100; break;
            }
            this.Position = position;
        }

        public Rectangle BoundingBox(Cactus cactus)
        {
            return new Rectangle((int)cactus.Position.X, (int)cactus.Position.Y, cactus.Texture.Width, cactus.Texture.Height);

        }

        private void InitializeList(ContentManager content)
        {
            Texture2D cactus = content.Load<Texture2D>("Sprites/Cactus/Cactus");
            Texture2D cactus2 = content.Load<Texture2D>("Sprites/Cactus/Cactus2");
            Texture2D cactus3 = content.Load<Texture2D>("Sprites/Cactus/Cactus3");
            Texture2D cactus4 = content.Load<Texture2D>("Sprites/Cactus/Cactus4");
            Texture2D cactus5 = content.Load<Texture2D>("Sprites/Cactus/Cactus5");

            CactusTextures[0] = cactus;
            CactusTextures[1] = cactus2;
            CactusTextures[2] = cactus3;
            CactusTextures[3] = cactus4;
            CactusTextures[4] = cactus5;
        }
    }
}
