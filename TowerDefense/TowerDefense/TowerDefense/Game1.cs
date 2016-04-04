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

namespace TowerDefense
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Niv� niv� = new Niv�();
        Spelare spelare;
        V�gM�stare v�gm�stare;
        Panel panel;
        Knapp pilKnapp;
        Knapp kulKnapp;

        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = niv�.Bredd * 100;

            graphics.PreferredBackBufferHeight = niv�.H�jd * 100 + 100;
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
            Texture2D gr�s = Content.Load<Texture2D>("KartaGr�s");
            Texture2D bas = Content.Load<Texture2D>("KartaBas");
            Texture2D � = Content.Load<Texture2D>("Karta�");
            Texture2D �roterad = Content.Load<Texture2D>("Karta�Roterad");
            Texture2D �Sv�ng = Content.Load<Texture2D>("�sv�ng");
            Texture2D �Sv�ngv�nster = Content.Load<Texture2D>("�sv�ngv�nster");
            Texture2D �sv�ng90 = Content.Load<Texture2D>("�sv�ngvm90");
            Texture2D �sv�ng180 = Content.Load<Texture2D>("�sv�ngv180");
            niv�.L�ggtillTextur(gr�s);
            niv�.L�ggtillTextur(bas);
            niv�.L�ggtillTextur(�);
            niv�.L�ggtillTextur(�roterad); //3
            niv�.L�ggtillTextur(�Sv�ng);
            niv�.L�ggtillTextur(�Sv�ngv�nster);
            niv�.L�ggtillTextur(�sv�ng90);//6
            niv�.L�ggtillTextur(�sv�ng180);
            Texture2D fiendeTextur = Content.Load<Texture2D>("Motst�ndare12");
            v�gm�stare = new V�gM�stare(spelare, niv�, 10, fiendeTextur);
            Texture2D tornTextur11 = Content.Load<Texture2D>("Torn1");
            Texture2D torntTextur12 = Content.Load<Texture2D>("Torn2");
            Texture2D tornTextur13 = Content.Load<Texture2D>("Torn3");
            Texture2D torn1Kula = Content.Load<Texture2D>("Torn1Skott");
            spelare = new Spelare(niv�, tornTextur11, torntTextur12, tornTextur13, torn1Kula);
            Texture2D panelbar = Content.Load<Texture2D>("storpanel");
            SpriteFont font = Content.Load<SpriteFont>("Arial");
            panel = new Panel(panelbar, font, new Vector2(0, niv�.H�jd * 100));
            pilKnapp = new Knapp(tornTextur11, new Vector2(0, niv�.H�jd * 100));
            pilKnapp.Klick += new EventHandler(pilKnapp_klickade);

        }

        private void pilKnapp_klickade(object sender, EventArgs e)
        {
            spelare.NyTornTyp = "Pil Torn";
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
            v�gm�stare.Update(gameTime);
            spelare.Update(gameTime, v�gm�stare.Fiender);
            pilKnapp.Update(gameTime);
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
            niv�.Draw(spriteBatch);
            v�gm�stare.Draw(spriteBatch);
            spelare.Draw(spriteBatch);
            panel.Draw(spriteBatch, spelare);
            pilKnapp.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
