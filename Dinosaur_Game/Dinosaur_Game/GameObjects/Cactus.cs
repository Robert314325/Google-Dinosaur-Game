using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;

namespace Dinosaur_Game
{
    class Cactus
    {
        public Vector2 Position;
        public Texture2D Texture;
        public static Random Random = new Random();

        public static List<Texture2D> CactusTextures = new List<Texture2D>() { null, null, null, null, null };
        public static List<Cactus> CactusList = new List<Cactus>();

        public Cactus(ContentManager content, Vector2 position)
        {
            this.InitializeList(content);

            int random = Random.Next(0,2);
            this.Texture = CactusTextures[random];

            switch (random)
            {
                case 0: position.Y = 99; break;
                case 1: position.Y = 115 ; break;
            }
            this.Position = position;
        }

        private void InitializeList(ContentManager content)
        {
            Texture2D cactus = content.Load<Texture2D>("Sprites/Cactus/Cactus");
            Texture2D cactus2 = content.Load<Texture2D>("Sprites/Cactus/Cactus2");
            //Texture2D cactus3 = content.Load<Texture2D>("Sprites/Cactus/Cactus3");
            //Texture2D cactus4 = content.Load<Texture2D>("Sprites/Cactus/Cactus4");
            //Texture2D cactus5 = content.Load<Texture2D>("Sprites/Cactus/Cactus5");

            CactusTextures[0] = cactus;
            CactusTextures[1] = cactus2;
            //CactusTextures.Add(cactus3);
            //CactusTextures.Add(cactus4);
            //CactusTextures.Add(cactus5);
        }
    }
}
