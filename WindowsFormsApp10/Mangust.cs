using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp10
{
    [Serializable]
    class Mangust:Block
    {
        
        private bool exMang = false;
        public Bitmap man = new Bitmap(Image.FromFile("skull.png"));
        public Rectangle mann;


        public void draw(Graphics g)
        {

            if (!exMang)
            {
                mann = new Rectangle(x, y, width, height);
                g.DrawImage(man, mann);
                exMang = true;
            }

            else
            {
                g.DrawImage(man, mann);
            }
        }
        public void move()
        {

        }
        public void hide()
        {
            exMang = false;
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
