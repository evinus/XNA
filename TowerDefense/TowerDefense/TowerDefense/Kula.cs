using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
    class Kula : Bild
    {
        private int skada;
        private int ålder;
        private int fart;
        
        public int Skada
        {
            get { return skada; }
        }
        public bool ÄrDöd()
        {
            return ålder > 100;
        }
        public Kula(Texture2D textur,Vector2 position,float rotation,int fart,int skada): base(textur,textur,position)
        {
            this.rotation = rotation;
            this.skada = skada;
            this.fart = fart;
        }
        public void Döda()
        {
            this.ålder = 200;
        }
        public override void Update(GameTime gametime)
        {
            ålder++;
            position += hastighet;
            base.Update(gametime);
        }
        public void SättRotation(float värde)
        {
            rotation = värde;
            hastighet = Vector2.Transform(new Vector2(0, -fart), Matrix.CreateRotationZ(rotation));
        }
    }
}
