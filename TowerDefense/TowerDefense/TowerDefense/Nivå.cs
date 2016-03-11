using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace TowerDefense
{
    class Nivå
    {
        private int höjd;

        public int Höjd
        {
            get { return karta.GetLength(0); }
        }
        private int bredd;
        public int Bredd
        {
            get { return karta.GetLength(1); }
            
        }
        private Queue<Vector2> vägvisare = new Queue<Vector2>();
        public Nivå()
        {
            vägvisare.Enqueue(new Vector2(2, 0) * 32);
            vägvisare.Enqueue(new Vector2(2, 1) * 32);
            vägvisare.Enqueue(new Vector2(3, 1) * 32);
            vägvisare.Enqueue(new Vector2(3, 2) * 32);
            vägvisare.Enqueue(new Vector2(4, 2) * 32);
            vägvisare.Enqueue(new Vector2(4, 4) * 32);
            vägvisare.Enqueue(new Vector2(3, 4) * 32);
            vägvisare.Enqueue(new Vector2(3, 5) * 32);
            vägvisare.Enqueue(new Vector2(2, 5) * 32);
            vägvisare.Enqueue(new Vector2(2, 7) * 32);
            vägvisare.Enqueue(new Vector2(7, 7) * 32);
        }
        public Queue<Vector2> Vägvisare
        {
            get { return vägvisare; }
        }
        int[,] karta = new int[,]
        {
           {0,0,1,0,0,0,0,0,},
           {0,0,1,1,0,0,0,0,},
           {0,0,0,1,1,0,0,0,},
           {0,0,0,0,1,0,0,0,},
           {0,0,0,1,1,0,0,0,},
           {0,0,1,1,0,0,0,0,},
           {0,0,1,0,0,0,0,0,},
           {0,0,1,1,1,1,1,1,},
        };
        private List<Texture2D> bitTextur = new List<Texture2D>();
        
        public void LäggtillTextur(Texture2D textur)
        {
            bitTextur.Add(textur);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            for(int x =0;x<Bredd; x++)
            {
                for(int y=0;y<Höjd;y++)
                {
                    int texturIndex = karta[y, x];
                    if (texturIndex == -1)
                        continue;
                    Texture2D textur = bitTextur[texturIndex];
                    spritebatch.Draw(textur, new Rectangle(x * 32, y * 32, 32, 32), Color.White);
                }
            }
        }
        public int FåIndex(int cellX,int cellY)
        {
            if (cellX < 0 || cellX > Bredd - 1 || cellY < 0 || cellY > Höjd - 1)
                return 0;
            return karta[cellY, cellX];

        }
    }
}
