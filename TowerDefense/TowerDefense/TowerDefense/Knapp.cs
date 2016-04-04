using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefense
{
    class Knapp : Bild
    {
        private MouseState föregåendeStatus;
        private Texture2D texturr;
        private Rectangle område;
        private ButtonState status = ButtonState.Released;
        public event EventHandler Klick;

        public Knapp(Texture2D textur, Vector2 position) : base (textur, position)
        {
            this.texturr = textur;
            this.område = new Rectangle((int)position.X, (int)position.Y, textur.Width, textur.Height);
        }
        public override void Update(GameTime gametime)
        {
            MouseState musStatus = Mouse.GetState();
            int musX = musStatus.X;
            int musY = musStatus.Y;
            bool ärMusenÖver = område.Contains(musX, musY);
            if(musStatus.LeftButton == ButtonState.Pressed && föregåendeStatus.LeftButton == ButtonState.Released)
            {
                if(ärMusenÖver == true)
                {
                    status = ButtonState.Pressed;
                }
            }
            if (musStatus.LeftButton == ButtonState.Released && föregåendeStatus.LeftButton == ButtonState.Pressed)
            {
                if(ärMusenÖver == true)
                {
                    if (Klick != null)
                        Klick(this, EventArgs.Empty);
                }
             
            }
            föregåendeStatus = musStatus;
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texturr, område, Color.White);
        }
    }
}
