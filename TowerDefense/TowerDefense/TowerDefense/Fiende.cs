using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    class Fiende : Bild
    {
        protected float hälsa;
        protected bool vidliv = true;
        protected float starthälsa;
        protected float fart = 0.5f;
        protected int belöning;
        private Queue<Vector2> vägvisare = new Queue<Vector2>();

        public float Hälsa
        {
            get { return hälsa; }
            set { hälsa = value; }
        }
       public bool ÄrDöd
        {
            get { return !vidliv; }
        }
        public int Belöning
        {
            get { return belöning; }
        }
        public float DistansTillDestination
        {
            get { return Vector2.Distance(position, vägvisare.Peek()); }
        }
        public Fiende(Texture2D textur, Vector2 position, float hälsa,float fart,int belöning) : base (textur,position)
        {
            this.hälsa = hälsa;
            this.fart = fart;
            this.belöning = belöning;
            this.starthälsa = this.hälsa;
        }
        public void SättVägvisare(Queue<Vector2> vägvisare)
        {
            foreach (Vector2 vägpunkt in vägvisare)
                this.vägvisare.Enqueue(vägpunkt);
            this.position = this.vägvisare.Dequeue();
        }
        public override void Update(GameTime gametime)
        {
            base.Update(gametime);

            if (vägvisare.Count > 0)
            {
                if (DistansTillDestination < fart)
                {
                    position = vägvisare.Peek();
                    vägvisare.Dequeue();
                }
                else
                {
                    Vector2 håll = vägvisare.Peek() - position;
                    håll.Normalize();
                    hastighet = Vector2.Multiply(håll, fart);
                    position += hastighet;
                }
            }
            else
            {
                vidliv = false;
                if (hälsa <= 0)
                    vidliv = false;
            }
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            if ( vidliv)
            {
                float hälsaProcent = (float)hälsa / (float)starthälsa;
                Color färg = new Color(new Vector3(1 - hälsaProcent, 1 - hälsaProcent, 1 - hälsaProcent));
                base.Draw(spritebatch);
            }          
        }
    }
}
