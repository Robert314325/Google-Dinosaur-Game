using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dinosaur_Game
{
    static class Options
    {
        public static int SpeedValue = 0;
        public static int IncreadingSpeedValue = 5;
        public static bool IsPlaying = true;
        public static Dinosaur Player { get; set; }

        private static GameState gameState = GameState.GameOn;

        public static GameState GameState
        {
            get { return gameState; }

            set
            {
                gameState = value;

                switch (gameState)
                {
                    case GameState.GameOver:
                        {
                            Player.SetDefaultDinosaur();
                            break;
                        }
                }
            }
        }
    }
}
