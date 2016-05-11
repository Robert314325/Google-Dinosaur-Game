using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dinosaur_Game
{
    class Background
    {
        public Texture2D Texture { get; set; }

        // Initialize()
        public Background(ContentManager content)
        {
            this.Texture = content.Load<Texture2D>("Sprites/Background/Background");
        }
    }
}
