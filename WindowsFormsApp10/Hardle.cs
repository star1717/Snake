using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp10
{
    [Serializable]
    class Hardle:Block
    {
        public Bitmap hardl = new Bitmap(Image.FromFile("stop.png"));
        private Rectangle hard;
        public List<Rectangle> all_hard = new List<Rectangle>();
        private int exHardle=0;
        public void draw(Graphics g)
        {
               if (exHardle < 10)
               {
                   new Rectangle(x, y, width, height);
                   all_hard.Add(new Rectangle(x, y, width, height));
                   hard = new Rectangle(x, y, width, height);
                   g.DrawImage(hardl, hard);
                   exHardle++; ;               
               }
       
               else for (int i = 0; i < all_hard.Count; i++)
                {
                    hard = new Rectangle(all_hard[i].X, all_hard[i].Y, all_hard[i].Width, all_hard[i].Height);
                    g.DrawImage(hardl, hard);
                }          
        }
        public void hide(Graphics g)
        {
            //hide(hard, g);
            exHardle = 0;
        }
        public void setx(int x1)
        {
            x = x1;
        }
        public void sety(int y1)
        {
            y = y1;
        }
        public int getx()
        {
            return x;
        }
        public int gety()
        {
            return y;
        }
    }
}
