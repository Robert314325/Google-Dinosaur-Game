using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Dinosaur_Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteBatch backgroundSpriteBatch;

        //
        Dinosaur dinosaur;
        Background background;
        Cloud cloud;
        Cactus cactus;
        Score score;

        KeyboardState keyState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Change Window Size
            graphics.PreferredBackBufferHeight = 161;
            graphics.PreferredBackBufferWidth = 604;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Initialize Sprites
            dinosaur = new Dinosaur(this.Content);
            background = new Background(this.Content);
            cactus = new Cactus();
            
            Options.Player = dinosaur;
            Options.content = Content;

            cloud = new Cloud(this.Content,new Vector2(606,50));
            Cloud.CloudList.Add(cloud);

            //
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundSpriteBatch = new SpriteBatch(GraphicsDevice);

            score = new Score();
            score.LoadContent(this.Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        private float cloudTimeElapsed = 0f;
        private float cactusTimeElapsed = 0f;
        private float delay = 0f;
 
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            if (Options.isNewGame)
            {
                Options.IncreadingSpeedValue = 5;
                dinosaur.Position.Y = 102;
                delay += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (delay < 10f) { delay++; return; }
                delay = 0f;
                Options.isNewGame = false;
            }

            if (Options.GameState == GameState.GameOn)
            {
                // ADD a cloud to the list every <TimeInterval>
                cloudTimeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (cloudTimeElapsed > Cloud.Random.Next(4, 5))
                {
                    Cloud.CloudList.Add(new Cloud(this.Content, new Vector2(603, Cloud.Random.Next(40, 80))));
                    cloudTimeElapsed = 0f;
                }

                // ADD a Cactus to the list every <TimeInterval>
                cactusTimeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (cactusTimeElapsed > Cactus.Random.Next(1, 5))
                {
                    Cactus.CactusList.Add(new Cactus(this.Content, new Vector2(603, 99)));

                    Cactus currentCactus = Cactus.CactusList[Cactus.CactusList.Count - 1];
                    Cactus.CactusBoundingBox.Add(new Rectangle((int)currentCactus.Position.X + 7, (int)currentCactus.Position.Y,
                                                                    currentCactus.Texture.Width - 12, currentCactus.Texture.Height));
                    cactusTimeElapsed = 0f;
                }

                // Update cloud X Position
                foreach (Cloud cloud in Cloud.CloudList)
                {
                    cloud.Position.X--;
                }

                int i = 0;
                // Update Cactus X Position
                foreach (Cactus cactus in Cactus.CactusList)
                {
                    if (!Cactus.CactusBoundingBox[i].Intersects(dinosaur.BoundingBox))
                    {
                        cactus.Position.X -= Options.IncreadingSpeedValue;

                        Rectangle currentBoudningBox = Cactus.CactusBoundingBox[i];
                        currentBoudningBox.X -= Options.IncreadingSpeedValue;
                        Cactus.CactusBoundingBox[i] = currentBoudningBox;
                        i++;
                    }
                    else
                    {
                        Options.isNewGame = false;
                        Options.GameState = GameState.GameOver;
                    }
                }

                // JUMP EVENT !
                if (dinosaur.IsJumping)
                {
                    dinosaur.WaitJump();
                }
                else
                {
                    keyState = Keyboard.GetState();
                    if (keyState.IsKeyDown(Keys.Space) || keyState.IsKeyDown(Keys.Up))
                    {
                        dinosaur.Jump();
                    }
                }
            }

            if (Options.GameState == GameState.GameOver)
            {
                delay += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (delay < 10f) { delay++; return;  }

                keyState = Keyboard.GetState();
                if (keyState.IsKeyDown(Keys.Space) || keyState.IsKeyDown(Keys.Up))
                {
                    Cactus.CactusList.Clear();
                    Cactus.CactusBoundingBox.Clear();
                    Options.GameState = GameState.GameOn;
                    Options.isNewGame = true;
                    Score.CurrentScore = 0;
                    delay = 0f;
                }
            }

            base.Update(gameTime);
        }

        float timeElapsed = 0f;
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Options.spriteBatch = spriteBatch;

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);

            backgroundSpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);

            // Draw backgroud ! Scroll Background ++

            if (Options.GameState == GameState.GameOver)
            {
                // Stop Background Movement !

                Options.IncreadingSpeedValue = 0;
                Score.NextGoal = 100;
            }
            else
            {
                if (Score.CurrentScore >= Score.NextGoal) { Options.IncreadingSpeedValue++; Score.NextGoal += 100; }
            }
            
            Options.SpeedValue += Options.IncreadingSpeedValue;
            backgroundSpriteBatch.Draw(background.Texture,new Vector2(0,0) , new Rectangle(Options.SpeedValue, 0, background.Texture.Width, background.Texture.Height), Color.White);
            score.Draw(backgroundSpriteBatch);
            backgroundSpriteBatch.End();

            // Draw All Clouds 
            foreach (Cloud cloud in Cloud.CloudList)
            {
                spriteBatch.Draw(cloud.Texture, cloud.Position, new Rectangle(0, 0, cloud.Texture.Width, cloud.Texture.Height), Color.White);
            }

            // Draw All Cactus
            foreach (Cactus cactus in Cactus.CactusList)
            {
                spriteBatch.Draw(cactus.Texture, cactus.Position, new Rectangle(0, 0, cactus.Texture.Width, cactus.Texture.Height), Color.White);
            }

            // Update Dinosaur Frame every 0.1f if it's running !
            if (!dinosaur.IsJumping && Options.GameState == GameState.GameOn)
            {
                dinosaur.DinosaurTexture = Content.Load<Texture2D>("Sprites/Player/Dinosaur");

                timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (timeElapsed > 0.1f)
                {
                    dinosaur.UpdateFrame();
                    Score.CurrentScore++;
                    timeElapsed = 0f;
                }

                //Draw Dinosaur : Frame : 0 - 40
                spriteBatch.Draw(dinosaur.DinosaurTexture, dinosaur.Position, new Rectangle(dinosaur.Frame, 0, dinosaur.DinosaurTexture.Width - 40, dinosaur.DinosaurTexture.Height), Color.White);
            }
            else
            {
                spriteBatch.Draw(dinosaur.DinosaurTexture, dinosaur.Position, new Rectangle(0, 0, dinosaur.DinosaurTexture.Width, dinosaur.DinosaurTexture.Height), Color.White);

                timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (timeElapsed > 0.1f)
                {
                    if (Options.GameState == GameState.GameOn) { Score.CurrentScore++; }
                    timeElapsed = 0f;
                }
            }

            // Draw Score on the screen
            score.Draw(spriteBatch);

            if (Options.GameState == GameState.GameOver)
            {
                // Draw Game Over on the screen

                Texture2D gameOverTexture = Content.Load<Texture2D>("Sprites/Screen/GameOver");
                Texture2D retryTexture = Content.Load<Texture2D>("Sprites/Screen/Retry");

                spriteBatch.Draw(gameOverTexture, new Vector2(215, 50),
                                 new Rectangle(0, 0, gameOverTexture.Width, gameOverTexture.Height), Color.White);
                spriteBatch.Draw(retryTexture, new Vector2(290, 80),
                                 new Rectangle(0, 0, retryTexture.Width, retryTexture.Height), Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
