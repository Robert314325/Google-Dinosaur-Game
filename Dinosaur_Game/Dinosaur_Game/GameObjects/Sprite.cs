using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dinosaur_Game
{
    abstract class Sprite
    {
        public Vector2 Position;
        private Texture2D texture;

        public Texture2D Texture
        {
            get { return this.texture; }

            set { this.texture = value; }
        }
    }
}
