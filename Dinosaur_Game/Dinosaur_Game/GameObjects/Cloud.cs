using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;

namespace Dinosaur_Game
{
    class Cloud
    {
        public Vector2 Position;
        public Texture2D Texture;

        public static Random Random = new Random();
        public static List<Cloud> CloudList = new List<Cloud>(); 

        public Cloud(ContentManager content, Vector2 position)
        {
            this.Texture = content.Load<Texture2D>("Sprites/Background/Cloud");
            this.Position = position;
        }
    }
}
