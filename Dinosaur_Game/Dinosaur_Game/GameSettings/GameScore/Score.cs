using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Dinosaur_Game
{
    class Score
    {
        public Numbers numbers;

        public Texture2D ScoreTexture;
        public Vector2 Position = new Vector2(550, 20);
        public static int NextGoal { get; set; } = 100;

        private static string text { get; set; }

        private static int currentScore;

        public static int CurrentScore
        {
            get { return currentScore; }

            set
            {
                text = string.Format("{0:D5}", value);
                currentScore = value;
            }
        }

        public void LoadContent(ContentManager content)
        {
            numbers = new Numbers();

            this.ScoreTexture = content.Load<Texture2D>("Sprites/Screen/Numbers");
            numbers.Texture = this.ScoreTexture;
            CurrentScore = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int X = (int)this.Position.X;
            foreach (char number in text)
            {
                spriteBatch.Draw(this.ScoreTexture, new Vector2(X, this.Position.Y), numbers[number], Color.White);
                X += 9;
            }
        }
    }
}
