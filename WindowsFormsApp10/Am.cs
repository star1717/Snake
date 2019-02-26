using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp10
{
    [Serializable]
    class Am:Block
    {
        private bool exAm = false;
        private Bitmap am = new Bitmap(Image.FromFile("am1.png"));
        private Bitmap am2 = new Bitmap(Image.FromFile("am2.png"));
        //private Bitmap am1;
        public Rectangle amm;
        public bool r=true;
        public void draw(Graphics g)
        {
            if (r)
            {
                if (!exAm)
                {
                    amm = new Rectangle(x, y, width, height);
                    am.MakeTransparent();
                    g.DrawImage(am, amm);

                    exAm = true;
                }

                else
                {
                    am.MakeTransparent();
                    g.DrawImage(am, amm);

                }
                r = false;
            }
            else
            {
                if (!exAm)
                {
                    amm = new Rectangle(x, y, width, height);
                    am2.MakeTransparent();
                    g.DrawImage(am2, amm);

                    exAm = true;
                }

                else
                {
                    am2.MakeTransparent();
                    g.DrawImage(am2, amm);

                }
                r = true;
            }
        }
        public void moveRight()
        {
            amm.X += 20;
        }
        public void moveLeft()
        {
            amm.X -= 20;
        }
        public void hide()
        {
          
            exAm = false;
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
