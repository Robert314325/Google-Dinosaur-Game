using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dinosaur_Game
{
    class Dinosaur 
    {
        private float jumpSpeed = -11.2f;

        public Vector2 Position;
        public Texture2D DinosaurTexture { get; set; }
        public float yStart { get; set; }
        public float JumpSpeed { get; set; }
        public bool IsJumping { get; set; }
        public bool IsCollide { get; set; }
        public int Frame { get; set; }
        
        public Rectangle BoundingBox { get; set; }

        private ContentManager content;

        public Dinosaur(ContentManager content)
        {
            this.content = content;
            this.Frame = 0;
            this.Position = new Vector2(20,102);
            this.DinosaurTexture = content.Load<Texture2D>("Sprites/Player/Dinosaur");
            this.yStart = this.Position.Y;
            this.IsJumping = false;
            this.IsCollide = false;
            this.JumpSpeed = 0;

            this.BoundingBox = new Rectangle((int)this.Position.X + 6, (int)this.Position.Y,
                                                                        this.DinosaurTexture.Width - 52, this.DinosaurTexture.Height);
        }

        public void SetDefaultDinosaur()
        {
            this.DinosaurTexture = content.Load<Texture2D>("Sprites/Player/DefaultDinosaur");
        }

        public void UpdateFrame()
        {
            int frameOne = 0;
            int frameTwo = 40;

            if (this.Frame == frameOne)
            {
                this.Frame = frameTwo;
            }
            else
            {
                this.Frame = frameOne;
            }   
        }

        public bool CheckCollision()
        {
            // return true if a collistion happened !
            return true;
        }

        public void Jump()
        {
            // Set Dinosaur Frame to default !
            SetDefaultDinosaur();

            this.IsJumping = true;
            this.JumpSpeed = this.jumpSpeed;
        }

        float increasingValue = 0f;
        public void WaitJump ()
        {
            // Update Y position : Dinosaur and BoundingBox
            if (Options.GameState == GameState.GameOn) { this.Position.Y += this.JumpSpeed; }

            Rectangle boundingBox = this.BoundingBox;
            boundingBox.Y = (int)this.Position.Y;
            this.BoundingBox = boundingBox;

            increasingValue = 0.7f;
            this.JumpSpeed += increasingValue;

            if (this.Position.Y >= this.yStart)
            {
                this.Position.Y = this.yStart;

                boundingBox = this.BoundingBox;
                boundingBox.Y = (int)this.Position.Y;
                this.BoundingBox = boundingBox;

                this.IsJumping = false;
            }
        }
    }
}
