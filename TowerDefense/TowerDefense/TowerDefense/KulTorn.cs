using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    class KulTorn : Torn
    {
        public KulTorn(Texture2D textur, Texture2D textur2, Texture2D textur3, Texture2D kultextur, Vector2 position) : base(textur, textur2, textur3, kultextur, position)
        {
            this.skada = 30;
            this.kostnad = 50;
            this.radie = 150;
        }

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
            if (kulKlocka >= 0.75f && mål != null)
            {
                Kula kula = new Kula(kulTextur, Vector2.Subtract(centrum, new Vector2(kulTextur.Width / 2)), rotation, 6, skada);
                kulLista.Add(kula);
                kulKlocka = 0;
            }
            for (int i = 0; i < kulLista.Count; i++)
            {
                Kula kula = kulLista[i];
                kula.SättRotation(rotation);
                kula.Update(gametime);
                if (!ÄrInomRäckhåll(kula.Center))
                {
                    kula.Döda();
                }
                if (mål != null && Vector2.Distance(kula.Center, mål.Center) < 12)
                {
                    mål.Hälsa -= kula.Skada;
                    kula.Döda();
                }
                if (kula.ÄrDöd())
                {
                    kulLista.Remove(kula);
                    i--;
                }
            }
            //Uppgradering1();
        }
    }
}
