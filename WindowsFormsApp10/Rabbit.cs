using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp10
{
    [Serializable]
    class Rabbit: Block
    {
        
        private Random rnd = new Random();//Для получения случайной координаты
        private bool exRab = false;
        public Bitmap rab = new Bitmap(Image.FromFile("rab.png"));
        public Rectangle rabb;       
        public void draw(Graphics g)
        {

            if (!exRab)
            {
               
                rabb = new Rectangle(x, y, width, height);
                g.DrawImage(rab, rabb);
                exRab = true;                 
            }

            else
            {
                
                g.DrawImage(rab, rabb);
               
            }
        }
        public void hide()
        {
            
            exRab = false;
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
