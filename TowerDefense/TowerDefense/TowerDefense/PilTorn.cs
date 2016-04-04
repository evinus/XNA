using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefense
{
    class PilTorn : Torn
    {
        Spelare spelare;
        private MouseState föreGåendeMus;
        private MouseState musStatus;
        private int musX;
        private int musY;
        private Texture2D textur2;

        public PilTorn(Texture2D textur,Texture2D textur2, Texture2D textur3, Texture2D kultextur, Vector2 position):base(textur,textur2, textur3, kultextur,position)
        {
            this.skada = 15;
            this.kostnad = 15;
            this.radie = 200;
            
        }
        public bool Uppgradering1()
        {
            föreGåendeMus = Mouse.GetState();
            musStatus = Mouse.GetState();
            musX = musStatus.X;
            musY = musStatus.Y;
            for (int i = 0; i < spelare.tornen.Count; i++)
            {
                if (musStatus.LeftButton == ButtonState.Pressed && föreGåendeMus.LeftButton == ButtonState.Pressed)
                {
                    if (spelare.tornen[i].Area.Contains(musX, musY))
                    {
                        if (spelare.Pengar >= 20)
                        {
                            spelare.Pengar -= 20;
                            spelare.tornen[i].Skada = 30;
                            spelare.tornen[i].Radie = 100;
                            spelare.tornen[i].Textur2();
                            return true;
                        }    
                    }
                }
            }
            return false;
        }
        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
            if(kulKlocka >= 0.75f && mål != null)
            {
                Kula kula = new Kula(kulTextur, Vector2.Subtract(centrum, new Vector2(kulTextur.Width/2)), rotation, 6, skada);
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
            //Uppgradering1();
        }
    }
}
