using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TowerDefense
{
    class Torn : Bild
    {
        protected int kostnad;
        protected int skada;
        protected float radie;
        protected Texture2D kulTextur;
        protected float kulKlocka;
        protected List<Kula> kulLista = new List<Kula>();

        public int Kostnad
        {
            get { return kostnad; }
        }
        public int Skada
        {
            get { return skada;}
        }
        public float Radie
        {
            get { return radie; }
        }
        protected Fiende mål;
        public Fiende Mål
        {
            get { return mål; }
        }
        public Torn (Texture2D textur,Texture2D kultextur,Vector2 position): base (textur,position)
        {
            this.kulTextur = kultextur;
        }
        public bool ÄrInomRäckhåll(Vector2 position)
        {
            if (Vector2.Distance(centrum, position) <= radie)
                return true;
            return false;
        }
        public void SkaffaNärmstaFiende(List<Fiende> fiender)
        {
            mål = null;
            float minstaAvstånd = radie;
            foreach(Fiende fiende in fiender)
            {
                if(Vector2.Distance(centrum,fiende.Center) < minstaAvstånd)
                {
                    minstaAvstånd = Vector2.Distance(centrum, fiende.Center);
                    mål = fiende;
                }
            }
        }
        protected void RiktaMotMål()
        {
            Vector2 riktning = centrum - mål.Center;
            riktning.Normalize();
            rotation = (float)Math.Atan2(-riktning.X, riktning.Y);
        }
        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
            kulKlocka += (float)gametime.ElapsedGameTime.TotalSeconds;
            if(mål !=null)
            {
                RiktaMotMål();
                if(!ÄrInomRäckhåll(mål.Center)||mål.ÄrDöd)
                {
                    mål = null;
                    kulKlocka = 0;
                }
            }
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            foreach (Kula kula in kulLista)
                kula.Draw(spritebatch);
            base.Draw(spritebatch);
        }
    }
}
