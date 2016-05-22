using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;

namespace Dinosaur_Game
{
    class Numbers
    {
        public Texture2D Texture { get; set; }

        public Rectangle this[char number]
        {
            private set { }

            get
            {
                switch (number)
                {
                    case '0': return new Rectangle(0, 0, 8, this.Texture.Height);
                    case '1': return new Rectangle(11, 0, 8, this.Texture.Height);
                    case '2': return new Rectangle(21, 0, 8, this.Texture.Height);
                    case '3': return new Rectangle(33, 0, 8, this.Texture.Height);
                    case '4': return new Rectangle(43, 0, 8, this.Texture.Height);
                    case '5': return new Rectangle(54, 0, 8, this.Texture.Height);
                    case '6': return new Rectangle(65, 0, 8, this.Texture.Height);
                    case '7': return new Rectangle(76, 0, 8, this.Texture.Height);
                    case '8': return new Rectangle(87, 0, 8, this.Texture.Height);
                    case '9': return new Rectangle(99, 0, 8, this.Texture.Height);
                }

                return new Rectangle(0, 0, 0, 0);
            }
        }
    }
}
