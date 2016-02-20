using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 
   
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Drawing drawing = new Drawing();
        //Enemy enemy1;
        //Tower tower;
        Player player;
        //Wave wave;
        WaveManager waveManager;
        Toolbar toolbar;
        Button arrowButton;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = drawing.Width * 32;

            graphics.PreferredBackBufferHeight = 32 + drawing.Height * 32;
            graphics.ApplyChanges();
            IsMouseVisible = true;
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

            // TODO: use this.Content to load your game content here
            Texture2D grass = Content.Load<Texture2D>("grass");
            Texture2D path = Content.Load<Texture2D>("path");
            drawing.addTexture(grass);
            drawing.addTexture(path);
            Texture2D enemyTexture = Content.Load<Texture2D>("ring");
            //wave = new Wave(0, 10, drawing, enemyTexture);
            //wave.Start();
            waveManager = new WaveManager(drawing, 24, enemyTexture);
            Texture2D towerTexture = Content.Load<Texture2D>("tower1");
            Texture2D bulletTexture = Content.Load<Texture2D>("bullet");
            //tower = new Tower(towerTexture, Vector2.Zero);
            player = new Player(drawing, towerTexture, bulletTexture);
            Texture2D topbar = Content.Load<Texture2D>("toolbarbit");
            SpriteFont font = Content.Load<SpriteFont>("Arial");
            toolbar = new Toolbar(topbar, font, new Vector2(0, drawing.Height * 32));
            Texture2D towerHower = Content.Load<Texture2D>("GUI\\towerhower");
            Texture2D arrowPressad = Content.Load<Texture2D>("GUI\\towerpressed");
            arrowButton = new Button(towerTexture, towerHower, arrowPressad, new Vector2(0, drawing.Height * 32));
            arrowButton.Clicked += new EventHandler(arrowButton_Clicked);
            

        }
        private void arrowButton_Clicked(object sender, EventArgs e)
        {
            player.NewTowerType = "Arrow Tower";
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            //enemy1.Update(gameTime);
            //List<Enemy> enemies = new List<Enemy>();
            //enemies.Add(enemy1);
            waveManager.Update(gameTime);
            player.Update(gameTime, waveManager.Enemies);
            arrowButton.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
            spriteBatch.Begin();

            drawing.Draw(spriteBatch);
            // enemy1.Draw(spriteBatch);
            //wave.Draw(spriteBatch);
            waveManager.Draw(spriteBatch);
            player.Draw(spriteBatch);
            toolbar.Draw(spriteBatch, player);
            arrowButton.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
