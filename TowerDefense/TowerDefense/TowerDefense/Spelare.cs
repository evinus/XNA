using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefense
{
    class Spelare
    {
        private int pengar = 50;
        private int liv = 30;
        private List<Torn> tornen = new List<Torn>();
        private MouseState musStatus;
        private MouseState gamalStatus;
        private Texture2D tornTextur;
        private Texture2D kulTextur;

        public int Pengar
        {
            get { return pengar; }
        }
        public int Liv
        {
            get { return liv; }
        }
        private Nivå nivå;
        private string nyTornTyp;
        public string NyTornTyp
        {
            set { nyTornTyp = value; }
        }
        public Spelare(Nivå nivo,Texture2D tornTextur,Texture2D kulTextur)
        {
            this.nivå = nivo;
            this.tornTextur = tornTextur;
            this.kulTextur = kulTextur;
        }
        private int CellX;
        private int CellY;
        private int bitX;
        private int bitY;

        public void LäggTillTorn()
        {
            Torn tornAttLäggaTill = null;

            switch(nyTornTyp)
            {
                case "Pil Torn":
                    {
                        tornAttLäggaTill = new PilTorn(tornTextur, kulTextur, new Vector2(bitX, bitY));
                        break;
                    }
            }
            if (ÄrCellTom() == true && tornAttLäggaTill.Kostnad <= pengar)
            {
                tornen.Add(tornAttLäggaTill);
                pengar -= tornAttLäggaTill.Kostnad;

                nyTornTyp = string.Empty;
            }
        }
        public void Update(GameTime gameTime,List<Fiende> fiender)
        {
            musStatus = Mouse.GetState();
            CellX = (int)(musStatus.X / 32);
            CellX = (int)(musStatus.Y / 32);
            bitX = CellX * 32;
            bitY = CellY * 32;
            if (musStatus.LeftButton == ButtonState.Released && gamalStatus.LeftButton == ButtonState.Pressed)
                if (string.IsNullOrEmpty(nyTornTyp) == false)
                    LäggTillTorn();
            if(musStatus.LeftButton==ButtonState.Released&&gamalStatus.LeftButton==ButtonState.Pressed)
                if(ÄrCellTom())
                {

                }
            foreach(Torn torn in tornen)
            {
                if(torn.Mål==null)
                {
                    torn.SkaffaNärmstaFiende(fiender);
                }
                torn.Update(gameTime);
            }
            gamalStatus = musStatus;
        }
        private bool ÄrCellTom()
        {
            bool inomDistans = CellX >= 0 && CellY < nivå.Höjd;

        }
    }
}
