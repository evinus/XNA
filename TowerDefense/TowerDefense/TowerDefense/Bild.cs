using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace TowerDefense
{
    class Bild
    {
        protected Texture2D textur;

        protected Vector2 position;
        protected Vector2 centrum;
        protected Vector2 hastighet;
        protected Vector2 början;
        protected float rotation;
        protected Rectangle area;

        public Vector2 Center
        {
            get { return centrum; }
        }

        public Vector2 Position
        {
            get { return position; }
        }
        public Rectangle Area
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, textur.Width, textur.Height); }
        }
       
        public Bild(Texture2D tex, Vector2 pos)
        {
            textur = tex;

            position = pos;
            hastighet = Vector2.Zero;
            centrum = new Vector2(position.X + textur.Width / 2, position.X + textur.Height / 2);
            början = new Vector2(textur.Width / 2, textur.Height / 2);
        }
        public virtual void Update(GameTime gametime)
        {
            this.centrum = new Vector2(position.X + textur.Width / 2, position.Y + textur.Height / 2);
        }
        public virtual void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(textur, centrum, null, Color.White, rotation, början, 1.0f, SpriteEffects.None, 0);
        }
        public virtual void Draw(SpriteBatch spritebatch, Color color)
        {
            spritebatch.Draw(textur, centrum, null, color, rotation, början, 1.0f, SpriteEffects.None, 0);
        }
    }
}
