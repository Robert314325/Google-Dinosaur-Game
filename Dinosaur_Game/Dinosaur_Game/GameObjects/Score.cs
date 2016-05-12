using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System.Text;
using System;

namespace Dinosaur_Game
{
    class Score
    {
        public SpriteFont ScoreFont { get; set; }
        public string Text { get; set; } = string.Format("{0:D5}",0);
        public string BestScore { get; set; }

        public Score(ContentManager content)
        {
            //this.ScoreFont = content.Load<SpriteFont>("Font/ScoreFont");
        }

        public void UpdateText(int currentScore)
        {
            this.Text = string.Format("{0:D5}",currentScore);
        }
    }
}
