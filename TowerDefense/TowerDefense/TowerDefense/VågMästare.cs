using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
    class VågMästare
    {
        private int nummerAvVågor;
        private float tidSenasteVågen;
        private Queue<Våg> vågor = new Queue<Våg>();
        private Texture2D fiendeTextur;
        private bool vågKlar = false;
        private Nivå nivå;

        public Våg NuvarandeVåg
        {
            get { return vågor.Peek(); }
        }
        public List<Fiende> Fiender
        {
            get { return NuvarandeVåg.Fiender; }
        }
        public int Rond
        {
            get { return NuvarandeVåg.Rondnummer + 1; }
        }
        public VågMästare(Spelare spelare, Nivå nivå,int nummerAvVågor,Texture2D fiendeTextur)
        {
            this.nummerAvVågor = nummerAvVågor;
            this.fiendeTextur = fiendeTextur;
            this.nivå = nivå;
            for(int i=0;i<nummerAvVågor;i++)
            {
                int startNummerAvFiender = 6;
                int nummerModifieare = (i / 6) + 1;
                Våg våg = new Våg(i, startNummerAvFiender * nummerModifieare,spelare, nivå, fiendeTextur);
                vågor.Enqueue(våg);
            }
            StartaNästaVåg();
        }
        private void StartaNästaVåg()
        {
            if(vågor.Count>0)
            {
                vågor.Peek().Start();
                tidSenasteVågen = 0;
                vågKlar = false;
            }
        }
        public void Update(GameTime gametime)
        {
            NuvarandeVåg.Update(gametime);
            if(NuvarandeVåg.Rondöver)
            {
                vågKlar = true;
            }
            if(vågKlar)
            {
                tidSenasteVågen += (float)gametime.ElapsedGameTime.TotalSeconds;
            }
            if(tidSenasteVågen > 20.0f)
            {
                vågor.Dequeue();
                StartaNästaVåg();   
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            NuvarandeVåg.Draw(spriteBatch);
        }
    }
}
