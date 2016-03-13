using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TowerDefense
{
    class Våg
    {
        private int nummerAvFiender;
        private int vågNummer;
        private bool fiendeVidSlut;
        private bool skapaFieder;
        private float klocka = 0;
        private int skaptafiender = 0;
        private Nivå nivå;
        private Texture2D fiendetextur;
        private List<Fiende> fiender = new List<Fiende>();
        Spelare spelare;

        public bool Rondöver
        {
            get { return fiender.Count == 0 && skaptafiender == nummerAvFiender; }
        }
        public int Rondnummer
        {
            get { return vågNummer; }
        }
        public bool FiendeVidSlut
        {
            get { return fiendeVidSlut; }
            set { fiendeVidSlut = value; }
        }
        public List<Fiende> Fiender
        {
            get { return fiender; }
        }
        public Våg(int vågnummer, int nummeravfiender,Spelare spelare, Nivå nivå, Texture2D fiendetextur)
        {
            this.vågNummer = vågnummer;
            this.nummerAvFiender = nummeravfiender;
            this.nivå = nivå;
            this.fiendetextur = fiendetextur;
            this.spelare = spelare;
        }
        public void LäggTillFiende()
        {
            Fiende fiende = new Fiende(fiendetextur, nivå.Vägvisare.Peek(), 50,0.5f,1);
            fiende.SättVägvisare(nivå.Vägvisare);
            fiender.Add(fiende);
            klocka = 0;
            skaptafiender++;
        }
        public void Start()
        {
            skapaFieder = true;
        }
        public void Update(GameTime gametime)
        {
            if (skaptafiender == nummerAvFiender)
                skapaFieder = false;
            if(skapaFieder)
            {
                klocka += (float)gametime.ElapsedGameTime.TotalSeconds;
                if (klocka > 2)
                    LäggTillFiende();
            }
            for(int i=0;i<fiender.Count;i++)
            {
                Fiende fiende = fiender[i];
                fiende.Update(gametime);
                if(fiende.ÄrDöd)
                {
                    if(fiende.Hälsa > 0)
                    {
                        FiendeVidSlut = true;
                        spelare.Liv -= 1;
                    }
                    else
                    {
                        spelare.Pengar += fiende.Belöning;
                    }
                    fiender.Remove(fiende);
                    i--;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Fiende fiende in fiender)
            {
                fiende.Draw(spriteBatch);
            }
        }
    }
}
