using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dinosaur_Game
{
    static class Options
    {
        public static int SpeedValue = 0;
        public static int IncreadingSpeedValue = 5;
        public static bool IsPlaying = true;
        public static bool isNewGame = false;
        public static Dinosaur Player { get; set; }
        public static SpriteBatch spriteBatch;
        public static ContentManager content;


        private static GameState gameState = GameState.GameOn;

        public static GameState GameState
        {
            get { return gameState; }

            set
            {
                gameState = value;

                switch (value)
                {
                    case GameState.GameOver:
                    {
                        //Set Dinosaur Texture to default and Clear Cactus List and BoundingBox List

                        Player.SetGameOverDinosaur();

                        break;
                    }
                }
            }
        }
    }
}
