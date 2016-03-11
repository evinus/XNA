using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
    class PilTorn : Torn
    {
        public PilTorn(Texture2D textur,Texture2D kultextur,Vector2 position):base(textur,kultextur,position)
        {
            this.skada = 15;
            this.kostnad = 15;
            this.radie = 80;
        }
        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
            if(kulKlocka >= 0.75f && mål != null)
            {
                Kula kula = new Kula(kulTextur, Vector2.Subtract(centrum, new Vector2(kulTextur.Width\2)), rotation, 6, skada);
                kulLista.Add(kula);
                kulKlocka = 0;
            }
            for (int i=0;i<kulLista.Count;i++)
            {
                Kula kula = kulLista[i];
                kula.SättRotation(rotation);
                kula.Update(gametime);
                if(!ÄrInomRäckhåll(kula.Center))
                {
                    kula.Döda();
                }
                if (mål != null && Vector2.Distance(kula.Center, mål.Center) <12)
                {
                    mål.Hälsa -= kula.Skada;
                    kula.Döda();
                }
                if(kula.ÄrDöd())
                {
                    kulLista.Remove(kula);
                    i--;
                }
            }
        }
    }
}
