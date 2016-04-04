using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    class Panel
    {
        private Texture2D textur;
        private SpriteFont font;
        private Vector2 position;
        private Vector2 textPosition;

        public Panel(Texture2D textur,SpriteFont font,Vector2 position)
        {
            this.textur = textur;
            this.font = font;
            this.position = position;
            textPosition = new Vector2(130, position.Y + 10);
        }
        public void Draw(SpriteBatch spritebatch, Spelare spelare)
        {
            spritebatch.Draw(textur, position, Color.White);
            string text = string.Format("Pengar : {0} Liv: {1}", spelare.Pengar, spelare.Liv);
            spritebatch.DrawString(font, text, textPosition, Color.White);
        }
    }
}
