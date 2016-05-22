using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dinosaur_Game
{
    public static class Screen 
    {
        public static void GameOver (SpriteBatch spriteBatch, ContentManager content) 
        {
            Texture2D gameOverTexture = content.Load<Texture2D>("Sprites/Screen/GameOver");

            spriteBatch.Begin();
            spriteBatch.Draw(gameOverTexture, new Vector2(150, 50),
                             new Rectangle(0,0,gameOverTexture.Width,gameOverTexture.Height), Color.White);
            spriteBatch.End();
        }
    }
}
